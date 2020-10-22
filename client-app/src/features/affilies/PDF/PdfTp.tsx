import React from 'react';
import { IAffilie } from '../../../app/models/affilie';
import { Document, Page, Text, View, StyleSheet, Image } from '@react-pdf/renderer'
import { observer } from 'mobx-react-lite';
import { format } from 'date-fns'
import local from 'date-fns/locale/fr'


const PdfTp: React.FC<{ affilie: IAffilie }> = ({ affilie }) => {


    const styles = StyleSheet.create({
        page: {
            fontFamily: 'Helvetica',
            fontSize: 9,
            lineHeight: 1.5,
            fontWeight: `normal`,
            flexDirection: 'column',
            borderWidth: 0.5,
            paddingLeft: 8,
            paddingRight: 8,
            paddingBottom: 30,
            paddingTop: 10,
        },
        logo: {
            width: 250,
            height: 100,
            alignItems: 'center',
        },
        row: {
            flexDirection: 'row',
            borderColor: '#E1E1E1',
            borderBottomWidth: 0.5,
            alignItems: 'center',
            height: 24,
            fontStyle: 'bold',
        },
        columnTable: {
            flexDirection: 'column',
            width: '14.28%',
            textAlign: 'center',
            paddingLeft: 8,
            fontSize: 10,
        },
        columnTableMed: {
            flexDirection: 'column',
            width: '14.28%',
            textAlign: 'center',
            color: '#4E4E4E',
            paddingLeft: 8,
        },
        top: {

            flexDirection: 'column',
            width: '32%',
            textAlign: 'center',
            paddingLeft: 2,
        },
        topContaint: {
            border: 0.5,
            flexDirection: 'row',
            alignItems: 'center',
            height: 75,
            fontStyle: 'bold',
            paddingRight: 30,
            marginBottom: 8,

        },
        TableHeader: {
            flexDirection: 'column',
            width: '14.28%',
            textAlign: 'center',
            paddingLeft: 8,
            paddingTop: 8,
            backgroundColor: '#EBEBEB',
            fontStyle: 'bold',
            textTransform: 'uppercase',
        },
        aff1: {

            flexDirection: 'column',
            width: '70%',
            textAlign: 'left',
            paddingLeft: 2,
        },
        Titre: {

            flexDirection: 'column',
            width: '70%',
            textAlign: 'left',
            paddingLeft: 2,
            color: 'red',
            fontStyle: 'bold',
            fontSize: 12,
        },
        Titre2: {

            flexDirection: 'column',
            width: '70%',
            textAlign: 'left',
            paddingLeft: 2,
            color: 'green',
            fontStyle: 'bold',
            fontSize: 12,
        },

        aff: {

            flexDirection: 'column',
            width: '15%',
            textAlign: 'left',
            paddingLeft: 2,
        },
        affContaint: {
            flexDirection: 'row',
            alignItems: 'center',
            height: 20,
            fontStyle: 'bold',
            paddingRight: 10,

        },
        title: {
            flexDirection: 'row',
            alignItems: 'center',
            height: 20,
            fontStyle: 'bold',
            marginTop: 15,
        },
        Tablefooter: {
            flexDirection: 'column',
            width: '14.28%',
            textAlign: 'center',
            paddingLeft: 8,
            paddingTop: 8,
            backgroundColor: '#EBEBEB',
            fontStyle: 'bold',
        },
        rowFooter: {
            flexDirection: 'row',
            alignItems: 'center',
            height: 24,
            fontWeight: 900,
        },
        columnVide: {
            flexDirection: 'column',
            width: '28.59%',
            textAlign: 'left',
            paddingLeft: 8,
            paddingTop: 8,
            backgroundColor: '#EBEBEB',
        },
        columnTableRetenue: {
            flexDirection: 'column',
            width: '16.66%',
            textAlign: 'center',
            paddingLeft: 8,
        },
        TableHeaderRetenue: {
            flexDirection: 'column',
            width: '16.66%',
            textAlign: 'center',
            paddingLeft: 8,
            paddingTop: 8,
            backgroundColor: '#EBEBEB',
            fontWeight: `bold`,
        },
        columnVideRetenue: {
            flexDirection: 'column',
            width: '33.32%',
            textAlign: 'left',
            paddingLeft: 8,
            paddingTop: 8,
            backgroundColor: '#EBEBEB',
        },
        pageNumber: {
            position: 'absolute',
            fontSize: 10,
            bottom: 10,
            left: 0,
            right: 0,
            textAlign: 'center',
            color: 'grey',
        },
        Message: {
            marginTop: 20,
            fontSize: 10,
            textAlign: 'left',
        },
        LingeMessage: {
            paddingBottom: 4,
        },
        LingeMessageGra: {
            fontSize: 12,
        },

    });


    const today = new Date();

    return (
        <Document>
            <Page size="A4" style={styles.page}>

                <View style={styles.topContaint}>
                    <Text style={styles.top}>Dossiers TP (SUIVIS DES AVANCES)</Text>
                    <Image style={styles.logo} src='/assets/logo_.png' />
                    <Text style={styles.top}> {format(today, 'EEEE d MMMM yyyy', { locale: local })}</Text>
                </View>

                <View style={styles.affContaint}>
                    <Text style={styles.aff} >Nom Et Prenom</Text>
                    <Text style={styles.aff1} >{affilie.nom + ' ' + affilie.prenom}</Text>
                </View>
                <View style={styles.affContaint}>
                    <Text style={styles.aff} >Immatriculation </Text>
                    <Text style={styles.aff1} >{affilie.cin + ' / ' + affilie.matricule}</Text>
                </View>
                <View style={styles.affContaint}>
                    <Text style={styles.aff} >Adresse</Text>
                    <Text style={styles.aff1} >{affilie.adresse + ' ' + affilie.ville + ' ' + affilie.codePostale}</Text>
                </View>

                <View style={styles.title}>
                    <Text style={styles.Titre2} >Liste Des Avances</Text>
                </View>

                <View style={styles.row}>
                    <Text style={styles.TableHeader}>N Dossier</Text>
                    <Text style={styles.TableHeader}>DATE Pai</Text>
                    <Text style={styles.TableHeader}>Fr.Engage</Text>
                    <Text style={styles.TableHeader}>R.CNOPS</Text>
                    <Text style={styles.TableHeader}>R.MPSC</Text>
                    <Text style={styles.TableHeader}>Total.R</Text>
                    <Text style={styles.TableHeader}>Nature.Dos</Text>
                </View>

                {affilie.Qps.map(qp => qp.observation !== 'Med' ? (<View style={styles.row} key={qp.nDossier} wrap={false}>
                    <Text style={styles.columnTable}>{qp.nDossier}</Text>
                    <Text style={styles.columnTable}>{format(qp.datePaiementReel, 'dd/MM/yyyy', { locale: local })}</Text>
                    <Text style={styles.columnTable}>{qp.fraisEngage}</Text>
                    <Text style={styles.columnTable}>{qp.rembAmo} </Text>
                    <Text style={styles.columnTable}>{qp.rembMpsc} </Text>
                    <Text style={styles.columnTable}>{qp.totalRemb} </Text>
                    <Text style={styles.columnTable}>{qp.observation} </Text>

                </View>) :null

                )}

                <View style={styles.rowFooter}  wrap={false} >
                    <Text style={styles.columnVide}>1-Sous Totaux Des Avances (TP)</Text>
                    <Text style={styles.Tablefooter}>{affilie.somFreEngageTP} Dhs</Text>
                    <Text style={styles.Tablefooter}>{affilie.somRemCnopsTP} Dhs</Text>
                    <Text style={styles.Tablefooter}>{affilie.somRemMpscTP} Dhs</Text>
                    <Text style={styles.Tablefooter}>{affilie.somRemTP} Dhs</Text>
                </View>
                <View style={styles.rowFooter}  wrap={false}>
                    <Text style={styles.columnVide}>2-QP Classique</Text>

                    <Text style={styles.Tablefooter}>{affilie.somecumule} Dhs</Text>

                </View>
                <View style={styles.rowFooter}  wrap={false}>
                    <Text style={styles.columnVide}>3-Avance MPSC</Text>

                    <Text style={styles.Tablefooter}>{affilie.someAvanceMpsc} Dhs</Text>
                </View>
                <View style={styles.rowFooter}  wrap={false}>
                    <Text style={styles.columnVide}>4-Total avance (1+2+3)</Text>

                    <Text style={styles.Tablefooter}>{(parseFloat(affilie.somFreEngageTP.toString()) + parseFloat(affilie.somecumule.toString()) + parseFloat(affilie.someAvanceMpsc.toString())).toFixed(2)} Dhs</Text>
                </View>



                {/*les retenues */}
                <View wrap={false}>
                    <View style={styles.title} >
                        <Text style={styles.Titre} >Liste Des Retenues Effectuees</Text>
                    </View>

                    <View style={styles.row} wrap={false}>
                        <Text style={styles.TableHeaderRetenue}>Date.operation</Text>
                        <Text style={styles.TableHeaderRetenue}>Type.Retenue</Text>
                        <Text style={styles.TableHeaderRetenue}>Montant</Text>
                        <Text style={styles.TableHeaderRetenue}>Code 303</Text>
                        <Text style={styles.TableHeaderRetenue}>Code 304</Text>
                        <Text style={styles.TableHeaderRetenue}>Observation</Text>
                    </View>

                    {affilie.QpMois.map(re =>
                        <View style={styles.row} key={re.idPai} wrap={false}>
                            <Text style={styles.columnTableRetenue}>{format(re.date, 'dd/MM/yyyy', { locale: local })}</Text>
                            <Text style={styles.columnTableRetenue}>{re.typePai}</Text>
                            <Text style={styles.columnTableRetenue}>{re.qp}</Text>
                            <Text style={styles.columnTableRetenue}>{re.code303} </Text>
                            <Text style={styles.columnTableRetenue}>{re.code304} </Text>
                            <Text style={styles.columnTableRetenue}>{re.observation} </Text>
                        </View>
                    )

                    }

                </View>

                <View wrap={false}>
                    <View style={styles.rowFooter} >
                        <Text style={styles.columnVideRetenue}>Total Des Retenues</Text>

                        <Text style={styles.TableHeaderRetenue}>{affilie.totalRetenues} Dhs</Text>


                    </View>
                    <View style={styles.rowFooter} >
                        <Text style={styles.columnVideRetenue}>Rest</Text>

                        <Text style={styles.TableHeaderRetenue}>{affilie.rest} Dhs</Text>

                    </View>
                    <View style={styles.rowFooter}>
                        <Text style={styles.columnVideRetenue}>Reliquat á regle</Text>

                        <Text style={styles.TableHeaderRetenue}>{affilie.reliquat} Dhs</Text>
                    </View>
                </View>

                {affilie.reliquat > 0 ? (
                    <View style={styles.Message} wrap={false}>
                        <Text style={styles.LingeMessageGra}>* RELIQUAT A REGLER DES AVANCES DEJA ACCORDEES (Avis N°1)  {affilie.reliquat} DH  </Text>
                        <Text style={styles.LingeMessage}>Dans le cadre de la pratique du Tiers payant,des prises en charges et des avances,qui vous ont été accordées par la Mutuelle de Prévoyance Sociale des Cheminots.</Text>
                        <Text style={styles.LingeMessage}>Priére de trouver Ci-dessus,la situation de vos quotes part classiques,ansi que le montant des avances qui vous ont été accordées et que la CNOPS vous a déjà remboursées dans le cadre de lAMO </Text>
                        <Text style={styles.LingeMessage}>Pour pouvoir donner suite à vos futures demandes davance,priére de procéder au réglement, et dans limmédiat,des avances déjà encaissées </Text>
                        <Text style={styles.LingeMessage}>LE COMPTE BANCAIRE DE LA MPSC A CREDITER EST </Text>
                        <Text style={styles.LingeMessageGra}>ATTIJARI WAFABANK agence EXPANSION sous N 007 810 0000001515001579 18</Text>
                    </View>) : null



                }

                <Text style={styles.pageNumber} render={({ pageNumber, totalPages }) => (
                    `${pageNumber} / ${totalPages}`
                )} fixed />


            </Page>
        </Document>
    );


};

export default observer(PdfTp);