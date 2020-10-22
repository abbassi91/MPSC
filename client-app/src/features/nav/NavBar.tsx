import React, { useContext, useState } from 'react';
import { Menu, Container, Dropdown, Image, Input } from 'semantic-ui-react';
import { observer } from 'mobx-react-lite';
import { NavLink, Link } from 'react-router-dom';
import { RootStoreContext } from '../../app/stores/rootStore';

const NavBar: React.FC = () => {
  const rootStore = useContext(RootStoreContext);
  const { user, logout } = rootStore.userStore;


  const {
    loadAffilies,
    setPage
    , setCin
  } = rootStore.affilieStore;
  const [loadingNext, setLoadingNext] = useState(false);


  const load = (event: any) => {

    if (event.key === "Enter" && !loadingNext) {
      setLoadingNext(true);
      setPage(0)
      loadAffilies().then(() => setLoadingNext(false));

      var field = document.createElement('input');
      field.setAttribute('type', 'text');
      document.body.appendChild(field);

      setTimeout(function () {
        field.focus();
        setTimeout(function () {
          field.setAttribute('style', 'display:none;');
        }, 1);
      }, 1);
    }

  }


  return (


    <Menu fixed='top' inverted>
      <Container>

        <Menu.Item header as={NavLink} exact to='/'>
          <img src='/assets/logo.png' alt='logo' style={{ marginRight: 10 }} />
          MPSC
        </Menu.Item>
        <Menu.Item>
          <Input as={NavLink} to='/affilies'  className='icon' icon='search' placeholder='Search...' onChange={(e) => setCin(e.target.value)} onKeyDown={(e: any) => load(e)}  />
        </Menu.Item>
        <Menu.Item name='Affilies' as={NavLink} to='/affilies' />
        <Menu.Item name='Create Affilie' as={NavLink} to='/createActivity' />
     

        {user && (
          <Menu.Item position='right'>
            <Image avatar spaced='right' src={user.image || '/assets/user.png'} />
            <Dropdown pointing='top left' text={user.displayName}>
              <Dropdown.Menu>
                <Dropdown.Item
                  as={Link}
                  to={`/profile/${user.username}`}
                  text='My profile'
                  icon='user'
                />
                <Dropdown.Item onClick={logout} text='Logout' icon='power' />
              </Dropdown.Menu>
            </Dropdown>
          </Menu.Item>
        )}
      </Container>
    </Menu>

  );
};

export default observer(NavBar);
 


