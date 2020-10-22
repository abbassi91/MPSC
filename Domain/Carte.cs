using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public partial class Carte
    {
        
     
        public int id {get;set;}
        public string cinAff { get; set; }
        public DateTime DateArrive { get; set; }


        public DateTime DateEnvoie { get; set; }
         public string NomPoretur { get; set; }
        public string CinPorteur { get; set; }
        public bool Disponible {get;set;}
        public string UserReception { get; set; }
        public string UserEnvoie { get; set; }


        public virtual Affilie cinAffNavigation { get; set; }
        public virtual AppUser UseReceptionNavigation { get; set; }
        public virtual AppUser UserEnvoieNavigation { get; set; }

    }
}

