

import React from 'react'
import {Item } from 'semantic-ui-react'
import { IAffilie } from '../../../app/models/affilie'
import { format } from 'date-fns'
import local from 'date-fns/locale/fr'




const AyantDroits: React.FC<{ affilie: IAffilie }> = ({ affilie }) => {

    return (

        <Item.Group divided>
     
            {affilie.conjoints.map(conj =>
                <Item>

                    <Item.Content verticalAlign='middle'>
                    <b>{conj.nom + ' ' + conj.prenom}</b> <br/>
                        {format(conj.dateNaissance , 'EEEE d MMMM yyyy', { locale: local }) }  <br/>
                        {conj.observation}
                    </Item.Content>




                </Item>
            )}

         
           
                <Item>
                    <Item.Content verticalAlign='middle'>
                    {affilie.enfants.map(enf =>
                     <Item.Description style={{borderBottom:'1'}}>
                        <b>{enf.nom + ' ' + enf.prenom}</b> <br/>
                        {format(enf.dateNaissance , 'EEEE d MMMM yyyy', { locale: local }) }  <br/>
                        {enf.observation}
                        </Item.Description>
                         )}
                    </Item.Content>

            

                </Item>

           



        </Item.Group>




    )

}

export default AyantDroits





