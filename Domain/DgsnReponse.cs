using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public partial class DgsnReponse
    {
      
        
     
        public int id {get;set;}
        public string CinConj { get; set; }
        public DateTime DateEnvoie { get; set; }
        public DateTime DateReponse { get; set; }
        public string Reponse { get; set; }

        public int IdLotDgsn {get;set;}


        public virtual Conjoint CinConjNavigation { get; set; }
        public virtual LotDgsn IdLotDgsnNavigation { get; set; }
       

    }
}
