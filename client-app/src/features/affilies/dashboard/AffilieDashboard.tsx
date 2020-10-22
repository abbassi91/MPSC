import React, { useContext, useEffect, useState } from 'react';
import { Grid } from 'semantic-ui-react';
import AffilieList from './AffilieList';
import { observer } from 'mobx-react-lite';
import { RootStoreContext } from '../../../app/stores/rootStore';
import InfiniteScroll from 'react-infinite-scroller';
import AffilieListItemPlaceholder from './AffilieListItemPlaceholder';




const AffilieDashboard: React.FC = () => {
  const rootStore = useContext(RootStoreContext);
  const {
    loadAffilies,
    loadingInitial,
    setPage,
    page,
    totalPages
  } = rootStore.affilieStore;
  const [loadingNext, setLoadingNext] = useState(false);

  const handleGetNext = () => {
    setLoadingNext(true);
    setPage(page + 1);
    loadAffilies().then(() => setLoadingNext(false));
  
  };


  useEffect(() => {
    loadAffilies();
  }, [loadAffilies]);


console.log(page)

  return (


    <Grid stackable columns={2}>
  

      <Grid.Column width={12}>
      {loadingInitial && page===0 ? <AffilieListItemPlaceholder /> :(
            <InfiniteScroll
              pageStart={0}
              loadMore={handleGetNext}
              hasMore={!loadingNext && page + 1 < totalPages}
              initialLoad={false}
            >
              <AffilieList />

            </InfiniteScroll>
      )}

          {
            loadingNext?<AffilieListItemPlaceholder />:''
          }

        

      </Grid.Column>

      <Grid.Column width={4}>


     
      </Grid.Column>
    </Grid>


















  );
};

export default observer(AffilieDashboard);
