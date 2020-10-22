import React from 'react';
import { Placeholder, Card, Segment } from 'semantic-ui-react';




const AffilieListItemPlaceholder = () => {
  return (

  <Card style={{ marginTop: '1em' }}>
   
   


      <Segment raised>
        <Placeholder>
          <Placeholder.Header image>
            <Placeholder.Line />
            <Placeholder.Line />
          </Placeholder.Header>
          <Placeholder.Paragraph>
            <Placeholder.Line length='medium' />
            <Placeholder.Line length='short' />
          </Placeholder.Paragraph>
        </Placeholder>
      </Segment>


  </Card>



/*     <Fragment>
      <Placeholder fluid style={{ marginTop: 50 }}>
        <Segment.Group>
          <Segment style={{ minHeight: 110 }}>
            <Placeholder>
              <Placeholder.Header image>
                <Placeholder.Line />
                <Placeholder.Line />
              </Placeholder.Header>
              <Placeholder.Paragraph>
                <Placeholder.Line />
              </Placeholder.Paragraph>
            </Placeholder>
          </Segment>
          <Segment>
            <Placeholder>
              <Placeholder.Line />
              <Placeholder.Line />
            </Placeholder>
          </Segment>
          <Segment secondary style={{ minHeight: 70 }} />
          <Segment clearing>
            <Button disabled color='blue' floated='right' content='View' />
          </Segment>
        </Segment.Group>
      </Placeholder>
    </Fragment> */
  );
};
export default AffilieListItemPlaceholder;