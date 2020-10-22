import React from 'react'
import {Icon, Label } from 'semantic-ui-react'
import { IAffilie } from '../../../app/models/affilie'
import {format} from 'date-fns'
import local from 'date-fns/locale/fr'




const Notifications : React.FC<{ affilie: IAffilie }> = ({ affilie }) =>
{

    return (

     
           

            <>


            {affilie.cartes.map(carte=> 
            <Label.Group >
            <Icon name='address card' /> 
            {carte.disponible ?  <Label style={{color:'red'}}>Disponible</Label> : <Label>Envoyée</Label>}
            {format(carte.dateArrive, 'EEEE d MMMM yyyy', { locale: local }) }
           
            </Label.Group>
            

   
            
                )}

                </>

 
    )
  
}

export default Notifications





