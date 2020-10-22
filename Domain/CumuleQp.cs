using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class CumuleQp
    {
        public int id { get; set; }
        public string Cin { get; set; }
        public double Montant { get; set; }
        public string Observation { get; set; }
        public string IdUser { get; set; }
        public DateTime DateAffectation { get; set; }
        public virtual Affilie CinNavigation { get; set; }
        public virtual AppUser IdUserNavigation { get; set; }
    }
}
