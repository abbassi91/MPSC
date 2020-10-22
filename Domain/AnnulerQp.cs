using System;
using System.Collections.Generic;
using Domain;

namespace Domain
{
    public partial class AnnulerQp
    {
        public int idAnnulation { get; set; }
        public int? IdPaiAnnul { get; set; }
        public string IdUserAnnul { get; set; }
        public DateTime DateAnnul { get; set; }

        public virtual QpMois IdPaiAnnulNavigation { get; set; }
        public virtual AppUser IdUserAnnulNavigation { get; set; }
    }
}
