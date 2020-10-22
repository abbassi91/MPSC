import React, { useContext, Fragment } from 'react';
import { observer } from 'mobx-react-lite';
import AffilieListItem from './AffilieListItem';
import { RootStoreContext } from '../../../app/stores/rootStore';



  const AffilieList: React.FC = () => {
  const rootStore = useContext(RootStoreContext);
  const { affiliesByDate } = rootStore.affilieStore;

  return (


    <Fragment>
           {affiliesByDate.map(([group, affilies]) =>
           affilies.map(affilie => (   
              <AffilieListItem key={affilie.cin} affilie={affilie}/>)))
           }
    </Fragment>
 
   
  );
};

export default observer(AffilieList);
