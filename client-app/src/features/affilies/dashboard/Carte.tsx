import React, { useState } from 'react'
import { Accordion, Icon, Label } from 'semantic-ui-react'
import { IAffilie } from '../../../app/models/affilie'
import MisAjours from '../../affilies/details/MisesAjours'
import AyantDroits from '../details/AyantDroits'
import Notifications from '../details/Notifications'



const Carte : React.FC<{ affilie: IAffilie }> = ({ affilie }) =>
{
  
  const [activeIndex,change]=useState();
  

  const handleClick = (e:any, titleProps:any) => {
    const { index } = titleProps
    const newIndex = activeIndex === index ? -1 : index
    change(newIndex)
  }
       useState(activeIndex)

    return (
      <Accordion fluid styled>
        <Accordion.Title
          active={activeIndex === 0}
          index={0}
          onClick={handleClick}
        >
          <Icon name='dropdown' />
          Liste Des Mise á jour
        </Accordion.Title>
        <Accordion.Content active={activeIndex === 0}>
        <MisAjours affilie={affilie}/>
        </Accordion.Content>

        <Accordion.Title
          active={activeIndex === 1}
          index={1}
          onClick={handleClick}
        >
          <Icon name='dropdown' />
          Avances Accordées
        </Accordion.Title>
        <Accordion.Content active={activeIndex === 1}>
          <p>
               en cours de Développement  .....
          </p>
        </Accordion.Content>

        <Accordion.Title
          active={activeIndex === 2}
          index={2}
          onClick={handleClick}
        >
          <Icon name='dropdown' />
          Ayants droits
        </Accordion.Title>
        <Accordion.Content active={activeIndex === 2}>
         <AyantDroits affilie={affilie}/>
        </Accordion.Content>


       
        <Accordion.Title
          active={activeIndex === 3}
          index={3}
          onClick={handleClick}
          
        >
           
        {affilie.cartes.length>0 ? <Label  attached='top right' circular color='red' key='red'>
              <Icon name='bell' />  {affilie.cartes.length} 
            </Label> :null}
           
             Notifications   
       
        </Accordion.Title>
      
        <Accordion.Content active={activeIndex === 3}>
          <Notifications affilie={affilie}/>
        </Accordion.Content>

      </Accordion>
    )
  
}

export default Carte






/*import React, { Component } from 'react'
import { Accordion, Card, Icon } from 'semantic-ui-react'

export default class Carte extends Component {
  state = { activeIndex: 0 }

  handleClick = (e:any, titleProps:any) => {
    const { index } = titleProps
    const { activeIndex } = this.state
    const newIndex = activeIndex === index ? -1 : index

    this.setState({ activeIndex: newIndex })
  }

  render() {
    const { activeIndex } = this.state

    return (
      <Accordion fluid styled>
        <Accordion.Title
          active={activeIndex === 0}
          index={0}
          onClick={this.handleClick}
        >
          <Icon name='dropdown' />
          Liste des cartes cnops
        </Accordion.Title>
        <Accordion.Content active={activeIndex === 0}>
        <Card
            href='#card-example-link-card'
            header='Carte N1'
            meta='01/02/2020'
            description='Disponible'
        />
            <Card
            href='#card-example-link-card'
            header='Carte N1'
            meta='01/02/2020'
            description='Disponible'
        />
            <Card
            href='#card-example-link-card'
            header='Carte N1'
            meta='01/02/2020'
            description='Disponible'
        />
            <Card
            href='#card-example-link-card'
            header='Carte N1'
            meta='01/02/2020'
            description='Disponible'
        />
        </Accordion.Content>

        <Accordion.Title
          active={activeIndex === 1}
          index={1}
          onClick={this.handleClick}
        >
          <Icon name='dropdown' />
          What kinds of dogs are there?
        </Accordion.Title>
        <Accordion.Content active={activeIndex === 1}>
          <p>
            There are many breeds of dogs. Each breed varies in size and
            temperament. Owners often select a breed of dog that they find to be
            compatible with their own lifestyle and desires from a companion.
          </p>
        </Accordion.Content>

        <Accordion.Title
          active={activeIndex === 2}
          index={2}
          onClick={this.handleClick}
        >
          <Icon name='dropdown' />
          How do you acquire a dog?
        </Accordion.Title>
        <Accordion.Content active={activeIndex === 2}>
          <p>
            Three common ways for a prospective owner to acquire a dog is from
            pet shops, private owners, or shelters.
          </p>
          <p>
            A pet shop may be the most convenient way to buy a dog. Buying a dog
            from a private owner allows you to assess the pedigree and
            upbringing of your dog before choosing to take it home. Lastly,
            finding your dog from a shelter, helps give a good home to a dog who
            may not find one so readily.
          </p>
        </Accordion.Content>
      </Accordion>
    )
  }
}*/
