using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application
{
    public class ConjointDto
    {

        
    
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Cin { get; set; }
        public string cinAff { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Sexe { get; set; }
        public string Observation {get;set;}

        public int Rang {get;set;}


    }
}
