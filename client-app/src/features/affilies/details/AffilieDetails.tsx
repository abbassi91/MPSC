import React, { useContext, useEffect } from 'react';
import { observer } from 'mobx-react-lite';
import { RouteComponentProps } from 'react-router';
import LoadingComponent from '../../../app/layout/LoadingComponent';
//import AffilieDetailedInfo from './AffilieDetailedInfo';
import { RootStoreContext } from '../../../app/stores/rootStore';
import { Button, Card, Grid, Header, Icon, Tab, Table,Image } from 'semantic-ui-react';
import { format } from 'date-fns';
import local from 'date-fns/locale/fr';
import Carte from '../dashboard/Carte';
import { savePdf } from '../PDF/EtatQp';

import QpPdf from '../PDF/PdfQp'
import TpPdf from '../PDF/PdfTp'


interface DetailParams {
  cin: string;
}

const AffilieyDetails: React.FC<RouteComponentProps<DetailParams>> = ({
  match,
  history
}) => {
  const rootStore = useContext(RootStoreContext);
  const { affilie, loadAffilie, loadingInitial } = rootStore.affilieStore;

  useEffect(() => {
    loadAffilie(match.params.cin);
  }, [loadAffilie, match.params.cin, history]);

  if (loadingInitial) return <LoadingComponent content='Chargement Affilie...' />;

  if (!affilie) return null;



  const panes = [
    {
      menuItem: 'Dossiers Payés', render: () => <Tab.Pane>

        <Button onClick={() => savePdf(<QpPdf affilie={affilie}  />, "Global.pdf")}> <Icon name='print' />imprimer</Button>
        <Button onClick={() => savePdf(<TpPdf affilie={affilie} />, "QP.pdf")}><Icon name='print' />Imprimer (TP)</Button>

        <Table celled color="red" key='red'>
          <Table.Header>
            <Table.Row>
              <Table.HeaderCell>N Dossier</Table.HeaderCell>
              <Table.HeaderCell>Date Paiement</Table.HeaderCell>
              <Table.HeaderCell>Fr Engage</Table.HeaderCell>
              <Table.HeaderCell>AMO</Table.HeaderCell>
              <Table.HeaderCell>MPSC</Table.HeaderCell>
              <Table.HeaderCell>TOTAL</Table.HeaderCell>
              <Table.HeaderCell>T.Dossier</Table.HeaderCell>
            </Table.Row>
          </Table.Header>
         
          <Table.Body>
            {affilie.Qps.map(qp => 
              qp.observation !== 'Med' ? (
                <Table.Row key={qp.nDossier} negative style={{ fontWeight: "bold" }}>
                  <Table.Cell>{qp.nDossier}</Table.Cell>
                  <Table.Cell>{format(qp.datePaiementReel, 'EEEE d MMMM yyyy', { locale: local })}</Table.Cell>
                  <Table.Cell>{qp.fraisEngage}</Table.Cell>
                  <Table.Cell>{qp.rembAmo}</Table.Cell>
                  <Table.Cell>{qp.rembMpsc}</Table.Cell>
                  <Table.Cell>{qp.totalRemb}</Table.Cell>
                  <Table.Cell>{qp.observation}</Table.Cell>

                </Table.Row>) : (
                  <Table.Row key={qp.nDossier} >

                    <Table.Cell>{qp.nDossier}</Table.Cell>
                    <Table.Cell>
                      {format(qp.datePaiementReel, 'EEEE d MMMM yyyy', { locale: local })}
                    </Table.Cell>
                    <Table.Cell>{qp.fraisEngage}</Table.Cell>
                    <Table.Cell>{qp.rembAmo}</Table.Cell>
                    <Table.Cell>{qp.rembMpsc}</Table.Cell>
                    <Table.Cell>{qp.totalRemb}</Table.Cell>
                    <Table.Cell>{qp.observation}</Table.Cell>
                  </Table.Row>
                )

            )}
          </Table.Body>
        </Table>

        <Table>
          <Table.Header>
            <Table.Row>
              <Table.HeaderCell></Table.HeaderCell>
              <Table.HeaderCell></Table.HeaderCell>
              <Table.HeaderCell>Total F.enTP (1)</Table.HeaderCell>
              <Table.HeaderCell>Rem.AMO TP</Table.HeaderCell>
              <Table.HeaderCell>Rem.MPSC TP</Table.HeaderCell>
              <Table.HeaderCell>Total.RemTP (2)</Table.HeaderCell>
              <Table.HeaderCell>Avance MPSC</Table.HeaderCell>
              <Table.HeaderCell>DIFF (1)-(2) </Table.HeaderCell>
            </Table.Row>
          </Table.Header>
          <Table.Body>
            <Table.Row >
              <Table.Cell>{}</Table.Cell>
              <Table.Cell>{}</Table.Cell>
              <Table.Cell>{affilie.somFreEngageTP} Dhs</Table.Cell>
              <Table.Cell>{affilie.somRemCnopsTP} Dhs</Table.Cell>
              <Table.Cell>{affilie.somRemMpscTP} Dhs</Table.Cell>
              <Table.Cell>{affilie.somRemTP} Dhs</Table.Cell>
              <Table.Cell> {affilie.someAvanceMpsc} Dhs</Table.Cell>
              <Table.Cell>
                {Math.fround(parseFloat(affilie.somFreEngageTP.toString())
                  - parseFloat(affilie.somRemTP.toString())).toFixed(2)} Dhs
          </Table.Cell>
            </Table.Row>
            {/**/}
            <Table.Row key={affilie.cin} style={{ fontWeight: "bold" }}>
              <Table.HeaderCell></Table.HeaderCell>
              <Table.HeaderCell></Table.HeaderCell>
              <Table.HeaderCell>Total F.enDI (1)</Table.HeaderCell>
              <Table.HeaderCell>Rem.AMODI</Table.HeaderCell>
              <Table.HeaderCell>Rem.MPSCDI</Table.HeaderCell>
              <Table.HeaderCell>Total.RemDI (2) </Table.HeaderCell>
              <Table.HeaderCell> </Table.HeaderCell>
              <Table.HeaderCell>DIFF (1)-(2)</Table.HeaderCell>
            </Table.Row>

            <Table.Row >
              <Table.Cell>{}</Table.Cell>
              <Table.Cell>{}</Table.Cell>
              <Table.Cell>{affilie.somFreEngage} Dhs</Table.Cell>
              <Table.Cell>{affilie.somRemCnops} Dhs</Table.Cell>
              <Table.Cell>{affilie.somRemMpsc} Dhs</Table.Cell>
              <Table.Cell>{affilie.somRem} Dhs</Table.Cell>
              <Table.Cell> </Table.Cell>
              <Table.Cell>
                {Math.fround(parseFloat(affilie.somFreEngage.toString())
                  - parseFloat(affilie.somRem.toString())).toFixed(2)} Dhs
          </Table.Cell>
            </Table.Row>

          </Table.Body>

        </Table>


      </Tab.Pane>
    },


    {
      menuItem: 'Retenues', render: () => <Tab.Pane>


        <Table celled color="green" key='green'>
          <Table.Header>
            <Table.Row>
              <Table.HeaderCell>Id Pai</Table.HeaderCell>
              <Table.HeaderCell>Date</Table.HeaderCell>
              <Table.HeaderCell>Montant</Table.HeaderCell>
              <Table.HeaderCell>303</Table.HeaderCell>
              <Table.HeaderCell>304</Table.HeaderCell>
              <Table.HeaderCell>Date.S</Table.HeaderCell>
              <Table.HeaderCell>T.Reception</Table.HeaderCell>
              <Table.HeaderCell>observation</Table.HeaderCell>
            </Table.Row>
          </Table.Header>

          <Table.Body>
            {affilie.QpMois.map(qpm =>

              qpm.typePai === 'paiement manuel' ? (
                <Table.Row key={qpm.idPai} style={{ fontWeight: "bold", color: "green" }} >

                  <Table.Cell>{qpm.idPai}</Table.Cell>
                  <Table.Cell>{format(qpm.date, 'EEEE d MMMM yyyy', { locale: local })}</Table.Cell>
                  <Table.Cell>{qpm.qp}</Table.Cell>
                  <Table.Cell>{qpm.code303}</Table.Cell>
                  <Table.Cell>{qpm.code304}</Table.Cell>
                  <Table.Cell>{format(qpm.dateSaisie, 'EEEE d MMMM yyyy', { locale: local })}</Table.Cell>
                  <Table.Cell>{qpm.typePai}</Table.Cell>
                  <Table.Cell>{qpm.observation}</Table.Cell>


                </Table.Row>) :
                (<Table.Row key={qpm.idPai}>
                  <Table.Cell>{qpm.idPai}</Table.Cell>
                  <Table.Cell>{format(qpm.date, 'EEEE d MMMM yyyy', { locale: local })}</Table.Cell>
                  <Table.Cell>{qpm.qp}</Table.Cell>
                  <Table.Cell>{qpm.code303}</Table.Cell>
                  <Table.Cell>{qpm.code304}</Table.Cell>
                  <Table.Cell>{format(qpm.dateSaisie, 'EEEE d MMMM yyyy', { locale: local })}</Table.Cell>
                  <Table.Cell>{qpm.typePai}</Table.Cell>
                  <Table.Cell>{qpm.observation}</Table.Cell>
                </Table.Row>)
            )}

          </Table.Body>
        </Table>

        <Table>
          <Table.Header>
            <Table.Row>
              <Table.HeaderCell></Table.HeaderCell>
              <Table.HeaderCell></Table.HeaderCell>
              <Table.HeaderCell>Total</Table.HeaderCell>
              <Table.HeaderCell></Table.HeaderCell>
              <Table.HeaderCell></Table.HeaderCell>
              <Table.HeaderCell>Reliquat</Table.HeaderCell>
              <Table.HeaderCell>Reste</Table.HeaderCell>
            </Table.Row>
          </Table.Header>
          <Table.Body>
            <Table.Row key={affilie.cin} style={{ fontWeight: "bold" }}>

              <Table.Cell>{}</Table.Cell>
              <Table.Cell>{}</Table.Cell>
              <Table.Cell>{affilie.totalRetenues} Dhs</Table.Cell>
              <Table.Cell>{}</Table.Cell>
              <Table.Cell>{}</Table.Cell>
              <Table.Cell style={{ color: 'red' }}>{affilie.reliquat} Dhs</Table.Cell>
              <Table.Cell>{affilie.rest} Dhs</Table.Cell>


            </Table.Row>
          </Table.Body>

        </Table>





      </Tab.Pane>
    }
  ]

  return (

      <Grid  stackable  columns={2}>
        <Grid.Column width={4}>
          <Card>
            <Card.Content>
              <Header as='h2'>
                <Image circular src='https://www.flaticon.com/svg/static/icons/svg/2922/2922704.svg' />
              </Header>
              <Card.Header>
                {affilie.nom + ' ' + affilie.prenom}
              </Card.Header>
              <Card.Meta>{affilie.cin +' / '+affilie.matricule} </Card.Meta>
     
            </Card.Content>
            </Card>
            <Carte affilie={affilie}/>
        </Grid.Column>
  
  
  
        <Grid.Column width={12}>
      
  
          <Tab panes={panes} />
  
  
        </Grid.Column>
  
      </Grid>
  
  

  
 
 
  );
};

export default observer(AffilieyDetails);
