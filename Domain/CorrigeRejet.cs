using System;
using System.Collections.Generic;
using Domain;

namespace Domain
{
    public partial class CorrigeRejet
    {
        public int id { get; set; }
        public int idRej { get; set; }
        public string UserCorrigeRejet { get; set; }
        
        public DateTime DateCorrige { get; set; }

        public int numLot { get; set; }
    

        public virtual AppUser IdUserCorrigeRejNavigation { get; set; }
        public virtual RejetMaj idRejNavigation { get; set; }
    }
}
