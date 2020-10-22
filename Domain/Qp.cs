using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Qp
    {
        public string NDossier { get; set; }
        public DateTime DatePaiementTech { get; set; }
        public DateTime DatePaiementReel { get; set; }
        public string NCin { get; set; }
        public double? FraisEngage { get; set; }
        public double? RembAmo { get; set; }
        public double? RembMpsc { get; set; }
        public double? TotalRemb { get; set; }
        public string Observation { get; set; }
        public int? Rang { get; set; }
        public int? CodeEchance { get; set; }
        public string Iduser {get;set;}

        public virtual Echeance CodeEchanceNavigation { get; set; }
        public virtual Affilie NCinNavigation { get; set; }
        public virtual AppUser IduserNavigation { get; set; }

     
    }
}
