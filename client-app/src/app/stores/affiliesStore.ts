import { observable, action, computed, runInAction, reaction, toJS } from 'mobx';

import agent from '../api/agent';
import { RootStore } from './rootStore';
import { setAffilieProps } from '../common/util/util';
import { HubConnection } from '@aspnet/signalr';
import { IAffilie, IQp } from '../models/affilie';




const LIMIT = 20;

export default class AffilieStore {
  rootStore: RootStore;

  constructor(rootStore: RootStore) {
    this.rootStore = rootStore;

    reaction(
      () => this.predicate.keys(),
      () => {
        this.page = 0;
        this.affilieRegistry.clear();
        this.loadAffilies();
      }
    )
  }

  @observable affilieRegistry = new Map();
  @observable affilie: IAffilie | null = null;
  @observable qp: IQp | null = null;
  @observable loadingInitial = false;
  @observable submitting = false;
  @observable target = '';
  @observable loading = false;
  @observable.ref hubConnection: HubConnection | null = null;
  @observable affilieCount = 0;
  @observable page = 0;
  @observable cin = '';
  @observable predicate = new Map();

  @action setPredicate = (predicate: string, value: string | Date) => {
    this.predicate.clear();
    if (predicate !== 'all') {
      this.predicate.set(predicate, value);
    }
  }

  @action setCin = (cin_: string) => {
      this.cin=cin_;
  }

  @computed get axiosParams() {
    const params = new URLSearchParams();
    params.append('limit', String(LIMIT));
    params.append('cin', String(this.cin));
    params.append('offset', `${this.page ? this.page * LIMIT : 0}`);
    this.predicate.forEach((value, key) => {
      if (key === 'startDate') {
        params.append(key, value.toISOString())
      } else {
        params.append(key, value)
      }
    })
    return params;
  }

  @computed get totalPages() {
    return Math.ceil(this.affilieCount / LIMIT);
  }

  @action setPage = (page: number) => {
    this.page = page;
  }



  @computed get affiliesByDate() {
    return this.groupAffiliesByDate(
      Array.from(this.affilieRegistry.values())
    ); 
  }

  groupAffiliesByDate(affilies: IAffilie[]) {
     const sortedAffilies = affilies
    return Object.entries(
      sortedAffilies.reduce(
        (affilies, affilie) => {
          const date = affilie.dateNaissance.toISOString().split('T')[0];
          affilies[date] = affilies[date]
            ? [...affilies[date], affilie]
            : [affilie];
          return affilies;
        },
        {} as { [key: string]: IAffilie[] }
      )
    ); 
  }


sorted(qps:IQp[])
{
  const SortedQp = qps
 return Object.entries(
  SortedQp.reduce(
     (qps, qp) => {
       const date = qp.datePaiementReel.toISOString().split('T')[0];
       qps[date] = qps[date]
         ? [...qps[date], qp]
         : [qp];
       return qps;
     },
     {} as { [key: string]: IQp[] }
   )
 ); 
}




@action loadAffilies = async () => {
    if(this.page===0){  this.affilieRegistry.clear()}  
    this.loadingInitial = true;
    try {
      const affiliesEnvelope = await agent.Affilies.list(this.axiosParams);
      const {affilies, affilieCount} = affiliesEnvelope;
      runInAction('loading affilies', () => {
        affilies.forEach(affilie => {
          setAffilieProps(affilie);
          this.affilieRegistry.set(affilie.cin, affilie);
        });
        this.affilieCount = affilieCount;
        this.loadingInitial = false;
      });
    } catch (error) {
      runInAction('load affilies error', () => {
        this.loadingInitial = false;
      });
    }
  };

  getAffilie = (cin: string) => {
    return this.affilieRegistry.get(cin);
  };

  @action loadAffilie = async (cin: string) => {
    /// need solution
    this.affilieRegistry.clear();
    let affilie = this.getAffilie(cin);
    if (affilie) {
      this.affilie = affilie;
      return toJS(affilie);
    } else {
      this.loadingInitial = true;
      try {
        affilie = await agent.Affilies.details(cin);
        runInAction('getting affilie', () => {
          setAffilieProps(affilie);
          this.affilie = affilie;
          this.affilieRegistry.set(affilie.cin, affilie);
          this.loadingInitial = false;
        });
        return affilie;
      } catch (error) {
        runInAction('get affilie error', () => {
          this.loadingInitial = false;
        });
        console.log(error);
      }
    }
  };











}
