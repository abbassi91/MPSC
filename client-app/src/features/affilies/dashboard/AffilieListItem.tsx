import React from 'react';
import { Card, Header, Icon, Item, Label, Image } from 'semantic-ui-react';
import { format } from 'date-fns';
import { IAffilie } from '../../../app/models/affilie';
import { Link } from 'react-router-dom';
import local from 'date-fns/locale/fr'

//import UTIF from 'utif'

const calculate_age = (dob1: any) => {
  var today = new Date();
  var birthDate = new Date(dob1);  // create a date object directly from `dob1` argument
  var age_now = today.getFullYear() - birthDate.getFullYear();
  var m = today.getMonth() - birthDate.getMonth();
  if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
    age_now--;
  }
  return age_now;
}





const AffilieListItem: React.FC<{ affilie: IAffilie }> = ({ affilie }) => {
  //const host = affilie.attendees.filter(x => x.isHost)[0];
  return (

    

    <Card as={Link} to={`/affilies/${affilie.cin}/dossiers`} style={{ marginTop: '1em' }}>


      {affilie.situationVital === 0 ? (<Label color='red' ribbon>
        Décédé(e)
      </Label>) : null
      }

      <Card.Content>
        <Header as='h2'>
          {affilie.sexe === 'M' ? (
            <Image circular src='https://www.flaticon.com/svg/static/icons/svg/2922/2922704.svg' />) :
            (<Image circular src='https://www.flaticon.com/svg/static/icons/svg/2922/2922579.svg' />)}
        </Header>
        <Card.Header> {affilie.nom} {affilie.prenom}</Card.Header>

        <Item.Description >
          {affilie.cin} /  {affilie.matricule}
        </Item.Description>
        <Card.Meta>
          {affilie.rest > 0 ? (
            <div>
              <b>  Rest : </b>
              <span className='date' style={{ color: "Red", fontWeight: "bold" }}>{affilie.rest}</span>
              <b>  Reliquat : </b>
              <span className='date' style={{ color: "Red", fontWeight: "bold" }}>{affilie.reliquat}</span>

            </div>

          ) : (
              null
            )}

        </Card.Meta>
        <Card.Description>
          <Icon name='map marker alternate' />
          {affilie.adresse}
        </Card.Description>

        {affilie.telephone ? (
          <Card.Description>
            <Icon name='phone' />
            {affilie.telephone}
          </Card.Description>) : null}
        {affilie.telephone2 ? (
          <Card.Description>
            <Icon name='phone' />
            {affilie.telephone2}
          </Card.Description>) : null}

        <Card.Description>
          <Icon name='info circle' />
          {format(affilie.dateNaissance, 'EEEE d MMMM yyyy', { locale: local })}

        </Card.Description>
        {affilie.email ? (
          <Card.Description>
            <Icon name='mail' />
            {affilie.email}
          </Card.Description>) : null}



      </Card.Content>
      <Card.Content extra>
        <Icon name='info circle' />
    Age     {calculate_age(format(affilie.dateNaissance, 'EEEE d MMMM yyyy'))} Ans

    </Card.Content>

    </Card>
   
  );
};

export default AffilieListItem;
