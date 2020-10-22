using System;
using System.Collections.Generic;
using Domain;

namespace Domain
{
    public partial class LotMisAjour
    {

         public LotMisAjour()
        {
            MisAjours = new HashSet<MisAjour>();
        
        }
        public int Id { get; set; }
        public DateTime DateDebut { get; set; }
        public string UserDebut { get; set; }
        public DateTime DateEnvoie { get; set; }
        
        public virtual AppUser IdUserDebutNavigation { get; set; }
        public virtual ICollection<MisAjour> MisAjours { get; set; }

    }
}
