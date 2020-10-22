using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public partial class Enfant
    {
        
     
        public string id {get;set;}
        public string Nom { get; set; }
        public string Prenom { get; set; }
       // [Key, Column(Order = 1)] 
        public string Cin { get; set; }
        public string cinAff { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Sexe { get; set; }
        public string Observation {get;set;}
        public int Rang {get;set;}

        public virtual Affilie cinAffNavigation { get; set; }


    }
}

