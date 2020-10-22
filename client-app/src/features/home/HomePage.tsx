import { Link } from 'react-router-dom';
import { RootStoreContext } from '../../app/stores/rootStore';
import LoginForm from '../user/LoginForm';
import RegisterForm from '../user/RegisterForm';
import { createMedia } from '@artsy/fresnel'
import PropTypes from 'prop-types'
import React, { useContext, useState } from 'react'
import {
  Button,
  Container,
  Header,
  Icon,
  Label,
  Menu,
  Segment,
  Sidebar,
  Visibility,
  Image, Grid, List, Divider, Item, Accordion
} from 'semantic-ui-react'


const { MediaContextProvider, Media } = createMedia({
  breakpoints: {
    mobile: 0,
    tablet: 768,
    computer: 1024,
  },
})

/* Heads up!
 * HomepageHeading uses inline styling, however it's not the best practice. Use CSS or styled
 * components for such things.
 */
const HomepageHeading = ({ mobile }: any) => (
  <Container text>


    <Header as='h1'
      inverted
      style={{
        fontSize: mobile ? '2em' : '4em',
        fontWeight: 'normal',
        marginBottom: 0,
        marginTop: mobile ? '1.5em' : '3em',
      }}>
      <Image
        size='huge'
        src='/assets/logo.png'
        alt='logo'
        style={{ marginBottom: 12 }}
      />
          Mutuelle de Prévoyance sociale des Cheminots
        </Header>

  </Container>
)

HomepageHeading.propTypes = {
  mobile: PropTypes.bool,
}

/* Heads up!
 * Neither Semantic UI nor Semantic UI React offer a responsive navbar, however, it can be implemented easily.
 * It can be more complicated, but you can create really flexible markup.
 */
const DesktopContainer = (props: any) => {


  //hideFixedMenu = () => this.setState({ fixed: false })
  //showFixedMenu = () => this.setState({ fixed: true })
  const token = window.localStorage.getItem('jwt');
  const rootStore = useContext(RootStoreContext);
  const { user, isLoggedIn } = rootStore.userStore;
  const { openModal } = rootStore.modalStore;

  const [showhideFixedMenu, setshowFixedMenu] = useState(false)
  const { children } = props


  return (
    <Media greaterThan='mobile'>
      <Visibility
        once={false}
        onBottomPassed={() => setshowFixedMenu(false)}
        onBottomPassedReverse={() => setshowFixedMenu(true)}
      >
        <Segment
          inverted
          textAlign='center'
          style={{ minHeight: 700, padding: '1em 0em' }}
          vertical
        >
          <Menu
            fixed='top'
            inverted={!showhideFixedMenu}
            pointing={!showhideFixedMenu}
            secondary={!showhideFixedMenu}
            size='large'
          >
            <Container>
              <Menu.Item as={Link} active>La MPSC</Menu.Item>
              <Menu.Item as={Link}> Adhésion</Menu.Item>
              <Menu.Item as={Link}>Prestations</Menu.Item>
              <Menu.Item as={Link}>Œuvres Sociales</Menu.Item>
              <Menu.Item as={Link}>Actualités</Menu.Item>
              <Menu.Item as={Link}>Contacts</Menu.Item>
              {isLoggedIn && user && token ? (

                <Menu.Item position='right'>
                  <Label as={Link} color='teal' basic image>
                    <Image src='/assets/logo.jpg' />  {`Welcome back ${user.displayName}`} </Label>
                  <Button as={Link} to='/affilies' inverted={!showhideFixedMenu}>
                    Go back!
                  </Button>
                </Menu.Item>

              ) : (
                  <Menu.Item position='right'>
                    <Button as={Link} onClick={() => openModal(<LoginForm />)} inverted={!showhideFixedMenu}>
                      Log in
                  </Button>
                    <Button as={Link} onClick={() => openModal(<RegisterForm />)} inverted={!showhideFixedMenu} primary={showhideFixedMenu} style={{ marginLeft: '0.5em' }}>
                      Sign Up
                  </Button>
                  </Menu.Item>)}
            </Container>
          </Menu>
          <HomepageHeading />
        </Segment>

        <Segment style={{ padding: '8em 0em' }} vertical>
        <Grid container stackable verticalAlign='middle'>
          <Grid.Row>
            <Grid.Column width={8}>
              <Header as='h3' style={{ fontSize: '2em' }}>
                We Help Companies and Companions
            </Header>
              <p style={{ fontSize: '1.33em' }}>
                We can give your company superpowers to do things that they never thought possible.
                Let us delight your customers and empower your needs... through pure data analytics.
            </p>
              <Header as='h3' style={{ fontSize: '2em' }}>
                We Make Bananas That Can Dance
            </Header>
              <p style={{ fontSize: '1.33em' }}>
                Yes that's right, you thought it was the stuff of dreams, but even bananas can be
                bioengineered.
            </p>
            </Grid.Column>
            <Grid.Column floated='right' width={6}>
              <Image bordered rounded size='large' src='/assets/placeholder.png' />
            </Grid.Column>
          </Grid.Row>
          <Grid.Row>
            <Grid.Column textAlign='center'>
              <Button size='huge'>Check Them Out</Button>
            </Grid.Column>
          </Grid.Row>
        </Grid>
      </Segment>

      <Segment style={{ padding: '0em' }} vertical>
        <Grid celled='internally' columns='equal' stackable>
          <Grid.Row textAlign='center'>
            <Grid.Column style={{ paddingBottom: '5em', paddingTop: '5em' }}>
              <Header as='h3' style={{ fontSize: '2em' }}>
                "What a Company"
            </Header>
              <p style={{ fontSize: '1.33em' }}>That is what they all say about us</p>
            </Grid.Column>
            <Grid.Column style={{ paddingBottom: '5em', paddingTop: '5em' }}>
              <Header as='h3' style={{ fontSize: '2em' }}>
                "I shouldn't have gone with their competitor."
            </Header>
              <p style={{ fontSize: '1.33em' }}>
                <Image avatar src='/assets/placeholder.png' />
                <b>Nan</b> Chief Fun Officer Acme Toys
            </p>
            </Grid.Column>
          </Grid.Row>
        </Grid>
      </Segment>

      <Segment style={{ padding: '8em 0em' }} vertical>
        <Container text>
          <Header as='h3' style={{ fontSize: '2em' }}>
            Breaking The Grid, Grabs Your Attention
        </Header>
          <p style={{ fontSize: '1.33em' }}>
            Instead of focusing on content creation and hard work, we have learned how to master the
            art of doing nothing by providing massive amounts of whitespace and generic content that
            can seem massive, monolithic and worth your attention.
        </p>
          <Button as={Link} size='large'>
            Read More
        </Button>

          <Divider
            as='h4'
            className='header'
            horizontal
            style={{ margin: '3em 0em', textTransform: 'uppercase' }}
          >
            <button>Case Studies</button>
          </Divider>

          <Header as='h3' style={{ fontSize: '2em' }}>
            Did We Tell You About Our Bananas?
        </Header>
          <p style={{ fontSize: '1.33em' }}>
            Yes I know you probably disregarded the earlier boasts as non-sequitur filler content, but
            it's really true. It took years of gene splicing and combinatory DNA research, but our
            bananas can really dance.
        </p>
          <Button as={Link} size='large'>
            I'm Still Quite Interested
        </Button>
        </Container>
      </Segment>

      <Segment inverted vertical style={{ padding: '5em 0em' }}>
        <Container>
          <Grid divided inverted stackable>
            <Grid.Row>
              <Grid.Column width={3}>
                <Header inverted as='h4' content='About' />
                <List link inverted>
                  <List.Item as={Link}>Sitemap</List.Item>
                  <List.Item as={Link}>Contact Us</List.Item>
                  <List.Item as={Link}>Religious Ceremonies</List.Item>
                  <List.Item as={Link}>Gazebo Plans</List.Item>
                </List>
              </Grid.Column>
              <Grid.Column width={3}>
                <Header inverted as='h4' content='Services' />
                <List link inverted>
                  <List.Item as={Link}>Banana Pre-Order</List.Item>
                  <List.Item as={Link}>DNA FAQ</List.Item>
                  <List.Item as={Link}>How To Access</List.Item>
                  <List.Item as={Link}>Favorite X-Men</List.Item>
                </List>
              </Grid.Column>
              <Grid.Column width={7}>
                <Header as='h4' inverted>
                  Footer Header
              </Header>
                <p>
                  Extra space for a call to action inside the footer that could help re-engage users.
              </p>
              </Grid.Column>
            </Grid.Row>
          </Grid>
        </Container>
      </Segment>
      </Visibility>

      

      {children}
    </Media>
  )
}




const MobileContainer = (props: any) => {


  const [handleToggle, sethandleToggle] = useState(false);

  const { children } = props
  const token = window.localStorage.getItem('jwt');
  const rootStore = useContext(RootStoreContext);
  const { user, isLoggedIn } = rootStore.userStore;
  const { openModal } = rootStore.modalStore;

  const [activeIndex,change]=useState();
  

  const handleClick = (e:any, titleProps:any) => {
    const { index } = titleProps
    const newIndex = activeIndex === index ? -1 : index
    change(newIndex)
  }
       useState(activeIndex)

  

  return (
    <Media at='mobile'>
      <Sidebar.Pushable className="navMenu">
        <Sidebar
          as={Menu}
          animation='overlay'
          inverted
          onHide={() => sethandleToggle(false)}
          vertical
          direction='top'

          visible={handleToggle}
        >



      <Accordion fluid styled className="navMenu">

     {/* fisrt item */}   
        <Accordion.Title id="id"
          active={activeIndex === 0}
          index={0}
          onClick={handleClick}
        >
        <Icon name='dropdown' />
          La MPSC
        </Accordion.Title>
        
        <Accordion.Content active={activeIndex === 0}>
        <Menu.Item  as={Link}>Présentation</Menu.Item>
        <Menu.Item as={Link}>Mot du Président</Menu.Item>
        <Menu.Item as={Link}>Gouvernance</Menu.Item>
        <Menu.Item as={Link}>Cadre juridique</Menu.Item>
        <Menu.Item as={Link}>Chiffres clés</Menu.Item>
        </Accordion.Content>
      {/* second item */}   
      <Accordion.Title id="id"
          active={activeIndex === 1}
          index={1}
          onClick={handleClick}
        >
        <Icon name='dropdown' />
        Adhésion
        </Accordion.Title>
        
        <Accordion.Content active={activeIndex === 1}>
        <Menu.Item as={Link}>Guide de l’adhérent</Menu.Item>
        <Menu.Item as={Link}>Conditions d’affiliation</Menu.Item>
        <Menu.Item as={Link}>Formulaire</Menu.Item>
        </Accordion.Content>
  
      </Accordion>

      <Menu.Item as={Link}>Prestations</Menu.Item>
          <Menu.Item as={Link}>Œuvres Sociales</Menu.Item>
          <Menu.Item as={Link}>Actualités</Menu.Item>
          <Menu.Item as={Link}>Contacts</Menu.Item>

        </Sidebar>

        <Sidebar.Pusher dimmed={handleToggle}>
          <Segment
            inverted
            textAlign='center'
            style={{ minHeight: 350, padding: '1em 0em' }}
            vertical
          >
            <Container>
              <Menu inverted pointing secondary size='large'>

                <Menu.Item onClick={() => sethandleToggle(true)}>
                  <Icon name='sidebar' />
                </Menu.Item>
                {isLoggedIn && user && token ? (
                  <Menu.Item f position='right'>
                    <Button as={Link} to='/affilies' inverted style={{ marginLeft: '0.5em' }}>
                      Go back
                   </Button>

                  </Menu.Item>
                ) : (<Menu.Item f position='right'>
                  <Button as={Link} onClick={() => openModal(<LoginForm />)} >
                    Log in
                    </Button>

                  <Button as={Link} onClick={() => openModal(<RegisterForm />)} inverted style={{ marginLeft: '0.5em' }}>
                    Sign Up
                    </Button>
                </Menu.Item>)
                }

              </Menu>
            </Container>
            <HomepageHeading mobile />
          </Segment>

          <Segment style={{ padding: '8em 0em' }} vertical>
            <Grid container stackable verticalAlign='middle'>
              <Grid.Row>
                <Grid.Column width={8}>
                  <Header as='h3' style={{ fontSize: '2em' }}>
                    Présentation
            </Header>
                  <p style={{ fontSize: '1.33em' }}>

                    La MPSC est un groupement à but non lucratif qui, au moyen de cotisation de leurs membres, se proposent de mener dans l’intérêt de ceux-ci ou de leur famille, une action de prévoyance, de solidarité et d’entraide tendant à la couverture des risques pouvant atteindre la personne humaine.
                 </p>
                  <Grid.Column textAlign='center'>
                    <Button color='blue' size='large'>En Savoir plus</Button>
                  </Grid.Column>
                  <Header as='h3' style={{ fontSize: '2em' }}>
                    Actualités
                 </Header>
                  <p style={{ fontSize: '1.33em' }}>

                  </p>

                </Grid.Column>
                <Grid.Column floated='right' width={6}>
                  <Item.Group>
                    <Item>
                      <Item.Image size='tiny' src='/assets/placeholder.png' />
                      <Item.Content verticalAlign='middle'>
                        <Item.Header as={Link}>الانتخابات</Item.Header>
                      </Item.Content>
                    </Item>

                    <Item>
                      <Item.Image size='tiny' src='/assets/placeholder.png' />
                      <Item.Content verticalAlign='middle'>
                        <Item.Header as={Link} content='Avis Wafa IMA Assistance' />
                      </Item.Content>
                    </Item>

                    <Item>
                      <Item.Image size='tiny' src='/assets/placeholder.png' />
                      <Item.Content as={Link} header='بلاغ التعاضدية حول الانتخابات' verticalAlign='middle' />
                    </Item>
                  </Item.Group>

                </Grid.Column>
              </Grid.Row>
              <Grid.Row>
                <Grid.Column textAlign='left'>
                  <Button color='green' size='large'>En Savoir plus</Button>
                </Grid.Column>
              </Grid.Row>
            </Grid>
          </Segment>

          <Segment style={{ padding: '0em' }} vertical>
            <Grid celled='internally' columns='equal' stackable>
              <Grid.Row textAlign='center'>
                <Grid.Column style={{ paddingBottom: '5em', paddingTop: '5em' }}>
                  <Header as='h3' style={{ fontSize: '2em' }}>
                    "What a Company"
            </Header>
                  <p style={{ fontSize: '1.33em' }}>That is what they all say about us</p>
                </Grid.Column>
                <Grid.Column style={{ paddingBottom: '5em', paddingTop: '5em' }}>
                  <Header as='h3' style={{ fontSize: '2em' }}>
                    "I shouldn't have gone with their competitor."
            </Header>
                  <p style={{ fontSize: '1.33em' }}>
                    <Image avatar src='/assets/placeholder.png' />
                    <b>Nan</b> Chief Fun Officer Acme Toys
            </p>
                </Grid.Column>
              </Grid.Row>
            </Grid>
          </Segment>

          <Segment style={{ padding: '8em 0em' }} vertical>
            <Container text>
              <Header as='h3' style={{ fontSize: '2em' }}>
                Nos 6 principes à La Mpsc
        </Header>
              <p style={{ fontSize: '1.33em' }}>
                <b>L’égalité d’accès aux soins</b> <br />
              La MPSC est à but non lucratif
              Notre vocation est d’être aux services de nos adhérents
              Pas de profit à travers les prestations servies à nos adhérents. <br />
              La non exclusion <br />
                <b>Liberté d’adhérer </b> <br />
              Liberté d’agir <br />
                <b>La bonne Gouvernance </b><br />
              Une gouvernance stable, équilibrée, compétente et bonne gestionnaire.
              Une gouvernance qui se projette vers l’avenir et qui utilise et tire profit de toutes ses ressources humaines. <br />
                <b>La Démocratie </b> <br />
              Ce sont les adhérents qui procèdent à l’élection des organes de décision. <br />
                <b>La solidarité </b><br />
              Solidarité entre ses adhérents.
              Pas de sélection médicale.
              Nous sommes fidèles à nos adhérents. <br />
                <b>La transparence </b><br />
              Une meilleure compréhension des garanties et des niveaux de prise en charge par nos membres. <br />


              </p>
              <Button as={Link} size='large'>
                Read More
        </Button>

              <Divider
                as='h4'
                className='header'
                horizontal
                style={{ margin: '3em 0em', textTransform: 'uppercase' }}
              >
                <button>Case Studies</button>
              </Divider>

              <Header as='h3' style={{ fontSize: '2em' }}>
                Chiffres Clés à fin juin 2020
             </Header>
              < List link inverted>
                      <List.Item as={Link}>  <Label as={Link} color='blue' image>
                  <Image src='/assets/placeholder.png' />
                Affiliés actifs
                <Label.Detail>7188</Label.Detail>
                </Label>
                      </List.Item>
                      <List.Item as={Link}>  <Label as={Link} color='blue' image>
                  <Image src='/assets/placeholder.png' />
                Affiliés retraités
                <Label.Detail>12035</Label.Detail>
                </Label></List.Item>
                
                      <List.Item as={Link}><Label as={Link} color='blue' image>
                  <Image src='/assets/placeholder.png' />
                Affiliés actifs
                <Label.Detail>7188</Label.Detail>
                </Label></List.Item>
                      <List.Item as={Link}>   <Label as={Link} color='blue' image>
                  <Image src='/assets/placeholder.png' />
                Conjoints
                <Label.Detail>9714</Label.Detail>
                </Label></List.Item>
                      <List.Item as={Link}>   <Label as={Link} color='blue' image>
                  <Image src='/assets/placeholder.png' />
                Enfants
                <Label.Detail>16183</Label.Detail>
                </Label></List.Item>
                      <List.Item as={Link}> <Label as={Link} color='blue' image>
                  <Image src='/assets/placeholder.png' />
                Dossiers payés
                <Label.Detail>45704</Label.Detail>
                </Label></List.Item>
                      <List.Item as={Link}>     <Label as={Link} color='blue' image>
                  <Image src='/assets/placeholder.png' />
                Dossiers payés AMO+MPSC
                <Label.Detail>27,890 Dhs</Label.Detail>
                </Label></List.Item>
        
                    </List>
              
              
                
             
             
               
           

       
              <Button as={Link} size='large'>
                I'm Still Quite Interested
        </Button>
            </Container>
          </Segment>

          <Segment inverted vertical style={{ padding: '5em 0em' }}>
            <Container>
              <Grid divided inverted stackable>
                <Grid.Row>
                  <Grid.Column width={3}>
                    <Header inverted as='h4' content='About' />
                    <List link inverted>
                      <List.Item as={Link}>Sitemap</List.Item>
                      <List.Item as={Link}>Contact Us</List.Item>

                    </List>
                  </Grid.Column>
                  <Grid.Column width={3}>
                    <Header inverted as='h4' content='Services' />
                    <List link inverted>
                      <List.Item as={Link}>Immatriculation</List.Item>
                      <List.Item as={Link}>Prise en charge</List.Item>
                      <List.Item as={Link}>Controle Médical </List.Item>
                      <List.Item as={Link}>Tiers payants</List.Item>
                    </List>
                  </Grid.Column>
                  <Grid.Column width={10}>
                    <iframe title='map' src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d1653.4535363663886!2d-6.835254141763118!3d34.02059619515366!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0xda76b88fee6e38b%3A0xa749d09ec920adc7!2sAvenue+Al+Mansour+Addahbi%2C+Rabat!5e0!3m2!1sen!2sma!4v1523034002494" width="auto" height="300" frameBorder="0" style={{ border: '0px', pointerEvents: 'none' }}/>

                  </Grid.Column>
                  <Grid.Column width={7}>


                    <Header as='h4' inverted>
                      Adresse
                    </Header>

                    <p>
                      42,Rue Al Mansour Eddahbi – Rabat -Maroc <br />

                        Tél : +212 5 37 70 43 35 <br />

                        Fax : +212 5 37 70 43 64 <br />

                        E-mail : mpsc@mpsc.com      <br />
                    </p>
                  </Grid.Column>
                </Grid.Row>
              </Grid>
            </Container>
          </Segment>
          {children}
        </Sidebar.Pusher>
      </Sidebar.Pushable>
    </Media>
  )
}




const ResponsiveContainer = ({ children }: any) => (
  /* Heads up!
   * For large applications it may not be best option to put all page into these containers at
   * they will be rendered twice for SSR.
   */

  <MediaContextProvider>
    <DesktopContainer>{children}</DesktopContainer>
    <MobileContainer>{children}</MobileContainer>
  </MediaContextProvider>
)

ResponsiveContainer.propTypes = {
  children: PropTypes.node,
}



const HomePage = () => {

  return (

    <ResponsiveContainer/>

  );
};

export default HomePage;


/*const HomePage = () => (

  <ResponsiveContainer>
    <Segment style={{ padding: '8em 0em' }} vertical>
      <Grid container stackable verticalAlign='middle'>
        <Grid.Row>
          <Grid.Column width={8}>
            <Header as='h3' style={{ fontSize: '2em' }}>
              We Help Companies and Companions
            </Header>
            <p style={{ fontSize: '1.33em' }}>
              We can give your company superpowers to do things that they never thought possible.
              Let us delight your customers and empower your needs... through pure data analytics.
            </p>
            <Header as='h3' style={{ fontSize: '2em' }}>
              We Make Bananas That Can Dance
            </Header>
            <p style={{ fontSize: '1.33em' }}>
              Yes that's right, you thought it was the stuff of dreams, but even bananas can be
              bioengineered.
            </p>
          </Grid.Column>
          <Grid.Column floated='right' width={6}>
            <Image bordered rounded size='large' src='/assets/placeholder.png' />
          </Grid.Column>
        </Grid.Row>
        <Grid.Row>
          <Grid.Column textAlign='center'>
            <Button size='huge'>Check Them Out</Button>
          </Grid.Column>
        </Grid.Row>
      </Grid>
    </Segment>

    <Segment style={{ padding: '0em' }} vertical>
      <Grid celled='internally' columns='equal' stackable>
        <Grid.Row textAlign='center'>
          <Grid.Column style={{ paddingBottom: '5em', paddingTop: '5em' }}>
            <Header as='h3' style={{ fontSize: '2em' }}>
              "What a Company"
            </Header>
            <p style={{ fontSize: '1.33em' }}>That is what they all say about us</p>
          </Grid.Column>
          <Grid.Column style={{ paddingBottom: '5em', paddingTop: '5em' }}>
            <Header as='h3' style={{ fontSize: '2em' }}>
              "I shouldn't have gone with their competitor."
            </Header>
            <p style={{ fontSize: '1.33em' }}>
              <Image avatar src='/assets/placeholder.png' />
              <b>Nan</b> Chief Fun Officer Acme Toys
            </p>
          </Grid.Column>
        </Grid.Row>
      </Grid>
    </Segment>

    <Segment style={{ padding: '8em 0em' }} vertical>
      <Container text>
        <Header as='h3' style={{ fontSize: '2em' }}>
          Breaking The Grid, Grabs Your Attention
        </Header>
        <p style={{ fontSize: '1.33em' }}>
          Instead of focusing on content creation and hard work, we have learned how to master the
          art of doing nothing by providing massive amounts of whitespace and generic content that
          can seem massive, monolithic and worth your attention.
        </p>
        <Button as={Link} size='large'>
          Read More
        </Button>

        <Divider
          as='h4'
          className='header'
          horizontal
          style={{ margin: '3em 0em', textTransform: 'uppercase' }}
        >
          <a href='#'>Case Studies</a>
        </Divider>

        <Header as='h3' style={{ fontSize: '2em' }}>
          Did We Tell You About Our Bananas?
        </Header>
        <p style={{ fontSize: '1.33em' }}>
          Yes I know you probably disregarded the earlier boasts as non-sequitur filler content, but
          it's really true. It took years of gene splicing and combinatory DNA research, but our
          bananas can really dance.
        </p>
        <Button as={Link} size='large'>
          I'm Still Quite Interested
        </Button>
      </Container>
    </Segment>

    <Segment inverted vertical style={{ padding: '5em 0em' }}>
      <Container>
        <Grid divided inverted stackable>
          <Grid.Row>
            <Grid.Column width={3}>
              <Header inverted as='h4' content='About' />
              <List link inverted>
                <List.Item as={Link}>Sitemap</List.Item>
                <List.Item as={Link}>Contact Us</List.Item>
                <List.Item as={Link}>Religious Ceremonies</List.Item>
                <List.Item as={Link}>Gazebo Plans</List.Item>
              </List>
            </Grid.Column>
            <Grid.Column width={3}>
              <Header inverted as='h4' content='Services' />
              <List link inverted>
                <List.Item as={Link}>Banana Pre-Order</List.Item>
                <List.Item as={Link}>DNA FAQ</List.Item>
                <List.Item as={Link}>How To Access</List.Item>
                <List.Item as={Link}>Favorite X-Men</List.Item>
              </List>
            </Grid.Column>
            <Grid.Column width={7}>
              <Header as='h4' inverted>
                Footer Header
              </Header>
              <p>
                Extra space for a call to action inside the footer that could help re-engage users.
              </p>
            </Grid.Column>
          </Grid.Row>
        </Grid>
      </Container>
    </Segment>
  </ResponsiveContainer>
)

export default HomePage*/



/* import React, { useContext, Fragment } from 'react';
import { Container, Segment, Header, Button, Image } from 'semantic-ui-react';
import { Link } from 'react-router-dom';
import { RootStoreContext } from '../../app/stores/rootStore';
import LoginForm from '../user/LoginForm';
import RegisterForm from '../user/RegisterForm';


const HomePage = () => {
  const token = window.localStorage.getItem('jwt');
  const rootStore = useContext(RootStoreContext);
  const { user, isLoggedIn } = rootStore.userStore;
  const {openModal} = rootStore.modalStore;
  return (
    <Segment inverted textAlign='center' vertical className='masthead'  >
      <Container text>
        <Header as='h1' inverted>
          <Image
            size='massive'
            src='/assets/logo.png'
            alt='logo'
            style={{ marginBottom: 12 }}
          />
          M P S C
        </Header>
        {isLoggedIn && user && token ? (
          <Fragment>
            <Header as='h2' inverted content={`Welcome back ${user.displayName}`} />
            <Button as={Link} to='/affilies' size='huge' inverted>
              Go to Mpsc WebApp!
            </Button>
          </Fragment>
        ) : (
          <Fragment>
          <Header as='h2' inverted content={`Welcome to MPSC`} />
          <Button onClick={() => openModal(<LoginForm />)} size='huge' inverted>
            Login
          </Button>
          <Button onClick={() => openModal(<RegisterForm />)} size='huge' inverted>
            Register
          </Button>
        </Fragment>
        )}
      </Container>
    </Segment>
  );
};

export default HomePage;
 */