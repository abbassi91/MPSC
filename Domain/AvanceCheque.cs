using System;
using System.Collections.Generic;
using Domain;

namespace Domain
{
    public partial class AvanceCheque
    {
        public int IdAvanceCheque { get; set; }
        public string CinAv { get; set; }
        public double MontantAv { get; set; }
        public DateTime DateAvance { get; set; }
        public string UserAvance { get; set; }
        public DateTime DateSaisie { get; set; }
        public string Obser { get; set; }

        public virtual Affilie CinAvNavigation { get; set; }
        public virtual AppUser UserAvanceNavigation { get; set; }
    }
}
