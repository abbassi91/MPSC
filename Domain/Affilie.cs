using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public partial class Affilie
    {
        public Affilie()
        {
            AvanceCheques = new HashSet<AvanceCheque>();
            Qps = new HashSet<Qp>();
            QpMois = new HashSet<QpMois>();
            CumuleQps=new HashSet<CumuleQp>();
            MisAjours=new HashSet<MisAjour>();
            Conjoints=new HashSet<Conjoint>();
            Enfants=new HashSet<Enfant>();
            Cartes=new HashSet<Carte>();
        }

        public string Matricule { get; set; }
        public string NPension { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        [Key, Column(Order = 1)] 
        public string Cin { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Telephone { get; set; }
        public string Telephone2 { get; set; }
        public string Sexe { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string CodePostale { get; set; }
        public string Rib { get; set; }
        public int? Rang { get; set; }
        public int? SituationVital { get; set; }
        public string TypeAffilie { get; set; }  
        public string NumAdherent { get; set; }
        public string Email { get; set; }

        public virtual ICollection<AvanceCheque> AvanceCheques { get; set; }
        public virtual ICollection<Qp> Qps { get; set; }
        public virtual ICollection<QpMois> QpMois { get; set; }
        public virtual ICollection<CumuleQp> CumuleQps { get; set; }
         public virtual ICollection<MisAjour> MisAjours { get; set; }
          public virtual ICollection<Conjoint> Conjoints { get; set; }
          
          public virtual ICollection<Enfant> Enfants { get; set; }
          public virtual ICollection<Carte> Cartes { get; set; }

    }
}
