import React from 'react';
import {Item } from 'semantic-ui-react';
import { format } from 'date-fns';
import local from 'date-fns/locale/fr';
import { IAffilie } from '../../../app/models/affilie';







const MisesAjours: React.FC<{ affilie: IAffilie }> = ({ affilie }) => {

    return (



        <Item.Group divided >

            <Item >
                <Item.Content >
                    {affilie.misAjours.map(Maj => Maj.rejetMajs.length > 0 ?

                        Maj.rejetMajs.map(rej => rej.corrigeRejets.length > 0 ?
                            (rej.corrigeRejets.map(corri =>


                                <Item.Description>
                                    {format(corri.dateCorrige, 'EEEE d MMMM yyyy', { locale: local })}
                         
                                </Item.Description>
                             


                            )

                            ) :
                            <Item.Description >
                                {rej.motif}
                            </Item.Description>



                        ) :

                        <Item.Description>
                            <b> {format(Maj.dateMaj, 'EEEE d MMMM yyyy', { locale: local })}</b><br />
                            {Maj.typeMaj} <br />
                            {Maj.info} <br />

                            <Item.Extra>
                               
                            </Item.Extra>
                        </Item.Description>




                    )
                    }
                </Item.Content>
            </Item>

        </Item.Group>













    );


}

export default MisesAjours



/*

 <Table celled color="purple" key='purple' >

                <Table.Header>
                    <Table.Row>
                        <Table.HeaderCell>Date </Table.HeaderCell>
                        <Table.HeaderCell>Type Maj</Table.HeaderCell>
                        <Table.HeaderCell>info</Table.HeaderCell>
                        <Table.HeaderCell>info1</Table.HeaderCell>

                    </Table.Row>
                </Table.Header>

                <Table.Body color="green" key='green'>

                    {affilie.misAjours.map(Maj => Maj.rejetMajs.length > 0 ?

                        Maj.rejetMajs.map(rej => rej.corrigeRejets.length > 0 ?
                            (rej.corrigeRejets.map(corri =>


                                <Table.Row key={Maj.id}>
                                    <Table.Cell>{format(Maj.dateMaj, 'EEEE d MMMM yyyy', { locale: local })}<br></br>
                                        <b>Rejetee Le  </b>: {format(rej.dateRejet, 'EEEE d MMMM yyyy', { locale: local })}
                                        <br></br>
                                        <b>Corrigee Le  </b>: {format(corri.dateCorrige, 'EEEE d MMMM yyyy', { locale: local })}
                                    </Table.Cell>
                                    <Table.Cell>{Maj.typeMaj}</Table.Cell>
                                    <Table.Cell>{Maj.info}<br></br>
                                        <b>Rejet Motif   </b>   : {rej.motif}
                                    </Table.Cell>
                                    <Table.Cell>{Maj.infoIdentifiant}</Table.Cell>
                                </Table.Row>))
                            :

                            <Table.Row key={Maj.id} style={{ color: 'red' }}>
                                <Table.Cell>{Maj.id}
                                    <Label color='red' ribbon>
                                        Rejetée
                                    </Label>
                                </Table.Cell>
                                <Table.Cell>{format(Maj.dateMaj, 'EEEE d MMMM yyyy', { locale: local })}<br></br>
                                    <b>Rejetee Le  </b>: {format(rej.dateRejet, 'EEEE d MMMM yyyy', { locale: local })}</Table.Cell>
                                <Table.Cell>{Maj.typeMaj}</Table.Cell>
                                <Table.Cell>{Maj.userMaj}</Table.Cell>
                                <Table.Cell>{Maj.info}<br></br>
                                    <b>Rejet Motif    </b>   : {rej.motif}</Table.Cell>
                                <Table.Cell>{Maj.infoIdentifiant}</Table.Cell>
                            </Table.Row>)

                        :
                        <Table.Row key={Maj.id}>
                            <Table.Cell>{Maj.id}</Table.Cell>
                            <Table.Cell>{format(Maj.dateMaj, 'EEEE d MMMM yyyy', { locale: local })}<br></br>
                            </Table.Cell>
                            <Table.Cell>{Maj.typeMaj}</Table.Cell>
                            <Table.Cell>{Maj.userMaj}</Table.Cell>
                            <Table.Cell>{Maj.info}
                            </Table.Cell>
                            <Table.Cell>{Maj.infoIdentifiant}</Table.Cell>
                        </Table.Row>


                    )}



                </Table.Body>
            </Table>*/