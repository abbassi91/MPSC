import { number, string } from "prop-types"

export interface IAffiliesEnvelope {
    affilies: IAffilie[];
    affilieCount : number;
  }
  
  export interface IAffilie 
    {
        matricule     :string;
        nPension      :string;
        nom           :string;
        prenom        :string;
        cin           :string;
        adresse       :string;
        ville         :string;
        codePostale   :string;
        dateNaissance :Date;
        sexe          :string;
        telephone     :string;
        telephone2    :string;
        rib           :string;
        rang          :number;
        situationVital:number;
        typeAffilie   :string;
        numAdherent   :string;
        email         :string;
         
        Qps            :IQp[];
        Cumules        :ICumuleQp[];
        QpMois         :IQpMois[];
        AvanceCheques  :IAvanceCheques[];
        misAjours      :IMisAjours[];
        cartes          :ICarte[];
        conjoints      :IConjoint[];
        enfants         :IEnfant[];
        
        somFreEngageTP :number;
        somRemMpscTP   :Number;
        somRemCnopsTP  :Number;
        somRemTP       :Number;
        nbrDossierT    :Number;
        somFreEngageDI :Number;
        somRemMpscDI   :Number;
        somRemCnopsDI  :Number;
        somRemDI       :Number;
        nbrDossierD    :Number;
        somFreEngage   :Number;
        somRemMpsc     :Number;
        somRemCnops    :Number;
        somRem         :Number;
        nbrDossier     :Number;
        
        somecumule     :Number;
        someAvanceMpsc :Number;

        totalRetenues  :Number;
        rest           :Number;
        reliquat       :Number;
    }
  
  
  export interface IQp {

    nDossier          :number;
    datePaiementTech  :Date;
    datePaiementReel  :Date;
    fraisEngage       :number;
    rembAmo           :number;
    rembMpsc          :number;
    totalRemb         :number;
    observation       :string;
    codeEchance       :number;
  }
  export interface ICumuleQp {

    id :number;
    cin :string;
    montant :number;
    observation :string;
    idUser :string;
    dateAffectation :Date;
  }
  export interface IQpMois {

    idPai :number;
    cinQp :string;
    date :Date;
    qp :number;
    rcar :string;
    typePai :string;
    codeEchanceQpMois :number;
    code303 :number;
    code304 :number;
    idUser :string;
    dateSaisie :Date;
    observation :string;
    cinPaiement :string;

  }

  export interface IAvanceCheques {
   idAvanceCheque :number;
   cinAv :string;
   montantAv :number;
   dateAvance :Date;
   userAvance :string;
   dateSaisie :Date;
   obser :string;
  }

  export interface ICarte
  {
    id            :number;
    cinAff        :string;
    dateArrive    :Date;
    dateEnvoie    :Date;
    nomPoretur    :string;
    cinPorteur    :string;
    disponible    :boolean;
    userReception :string;
    userEnvoie    :string;
  }

  export interface IEnfant
  {

    id :string;
    nom:string;
    prenom:string;
    cin:string;
    cinAff:string;
    dateNaissance:Date;
    sexe:string;
    observation :string;
    rang :number;
  }

  export interface IConjoint
  {

    nom :string;
    prenom :string;
    cin :string;
    cinAff :string;
    dateNaissance :Date;
    sexe :string;
    observation :string;
    rang :number;
  }

  /*export interface ITypeMisAjour {
    id :number;
    intitule :string;
   }

   export interface ILotMisAjour {
    Id          :number;
    DateDebut   :Date;
    UserDebut   :string;
    DateEnvoie  :Date;
  }*/


   export interface IMisAjours {
  
        id              :number;
        cinAffilie      :string;
        dateMaj         :Date;
        typeMaj         :string;
        info            :string;
        userMaj         :string;
        numLotMaj       :number;
        avcSCarte       :boolean;
        numCarte        :number;
        enCours         :boolean;
        infoIdentifiant :string;
        rejetMajs       :IRejetMaj[];
   }

   export interface IRejetMaj {
    id              :number;
    motif            :string;
    boite           :number;
    dateRejet       :Date;
    observation     :string;
    userRej        :string;
    idMaj          :number;
    corrigeRejets  :ICorrigeRejet[]

  }

  export interface ICorrigeRejet {
  id               :string;
  idRej            :string;
  userCorrigeRejet :string;
  dateCorrige      :string;
  numLot           :string;
  }