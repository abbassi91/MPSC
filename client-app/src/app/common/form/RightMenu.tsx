import React, { useContext, useState } from 'react';
import { Dropdown, Menu, Icon, Input } from "semantic-ui-react";
import { RootStoreContext } from '../../../app/stores/rootStore';





    const RightMenu: React.FC = () => {

        const rootStore = useContext(RootStoreContext);
const {
    loadAffilies,
    loadingInitial,
    setPage,
    page,
    totalPages
    , setCin
} = rootStore.affilieStore;

const [loadingNext, setLoadingNext] = useState(false);

const load = (event: any) => {

    if (event.key === "Enter") {
        setLoadingNext(true);
        setPage(0)
        loadAffilies().then(() => setLoadingNext(false));
    }
}
        return (
            <Menu vertical>
                <Menu.Item>
                    <Input placeholder='Search...' onChange={(e) => setCin(e.target.value)} onKeyDown={(e: any) => load(e)} />
                </Menu.Item>

                <Menu.Item>
                    Home
  <Menu.Menu>
                        <Menu.Item
                            name='search'

                        >
                            Search
    </Menu.Item>
                        <Menu.Item
                            name='add'

                        >
                            Add
    </Menu.Item>
                        <Menu.Item
                            name='about'

                        >
                            Remove
    </Menu.Item>
                    </Menu.Menu>
                </Menu.Item>

                <Menu.Item name='browse'>
                    <Icon name='grid layout' />
  Browse
</Menu.Item>

                <Menu.Item
                    name='messages'

                >
                    Messages
</Menu.Item>

                <Dropdown item text='More'>
                    <Dropdown.Menu>
                        <Dropdown.Item icon='edit' text='Edit Profile' />
                        <Dropdown.Item icon='globe' text='Choose Language' />
                        <Dropdown.Item icon='settings' text='Account Settings' />
                    </Dropdown.Menu>
                </Dropdown>
            </Menu>
        );

    };

    export default RightMenu;