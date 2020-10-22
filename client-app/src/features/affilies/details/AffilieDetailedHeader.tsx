import React, { useContext } from 'react';
import { Segment, Item, Header, Button, Image } from 'semantic-ui-react';
import { observer } from 'mobx-react-lite';
import { Link } from 'react-router-dom';
import { format } from 'date-fns';
import { RootStoreContext } from '../../../app/stores/rootStore';
import { IAffilie } from '../../../app/models/affilie';

const activityImageStyle = {
  filter: 'brightness(30%)'
};

const activityImageTextStyle = {
  position: 'absolute',
  bottom: '5%',
  left: '5%',
  width: '100%',
  height: 'auto',
  color: 'white'
};

const AffilieDetailedHeader: React.FC<{ affilie: IAffilie }> = ({
  affilie
}) => {
  const rootStore = useContext(RootStoreContext);
  const { loading } = rootStore.affilieStore;
  return (
    <Segment.Group>
      <Segment basic attached='top' style={{ padding: '0' }}>
        <Segment style={activityImageTextStyle} basic>
          <Item.Group>
            <Item>
              <Item.Content>
                <Header
                  size='huge'
                  content={affilie.nom}
                  style={{ color: 'white' }}
                />
                <p>{format(affilie.dateNaissance, 'eeee do MMMM')}</p>
          
              </Item.Content>
            </Item>
          </Item.Group>
        </Segment>
      </Segment>

    </Segment.Group>
  );
};

export default observer(AffilieDetailedHeader);
