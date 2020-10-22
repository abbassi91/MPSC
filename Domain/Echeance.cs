using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Echeance
    {
        public Echeance()
        {
            Qp = new HashSet<Qp>();
            QpMois = new HashSet<QpMois>();
        }

        public int CodeEchance { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
         public string User { get; set; }

         public virtual AppUser IdUserDebutNavigation { get; set; }
        public virtual ICollection<Qp> Qp { get; set; }
        public virtual ICollection<QpMois> QpMois { get; set; }
    }
}
