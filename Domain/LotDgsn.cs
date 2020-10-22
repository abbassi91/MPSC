using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public partial class LotDgsn
    {



        public int id { get; set; }

        public string UserDebutDgsn { get; set; }
         public string UserEnvoieDgsn { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime Datefin { get; set; }



        public virtual AppUser UserDebutDgsntNavigation { get; set; }
        public virtual AppUser UserEnvoieDgsnNavigation { get; set; }
        public virtual ICollection<DgsnReponse> DgsnReponses { get; set; }



    }
}
