using System;
using System.Collections.Generic;
using Domain;

namespace Domain
{
    public partial class MisAjour
    {
        public int Id { get; set; }
        public string CinAffilie { get; set; }
        public DateTime DateMaj { get; set; }
        public int TypeMaj { get; set; }
        public string Info { get; set; }
        public string UserMaj { get; set; }
        public int NumLotMaj { get; set; }
         public bool AvcSCarte { get; set; }
        public int NumCarte { get; set; }
        public bool EnCours { get; set; }
        public string infoIdentifiant { get; set; }

        public virtual Affilie CinAvNavigation { get; set; }
        public virtual AppUser UserMajNavigation { get; set; }
        public virtual TypeMisAjour TypeMisAjourNavigation { get; set; }
        public virtual LotMisAjour LotMisAjourNavigation { get; set; }
        public virtual ICollection<RejetMaj> RejetMajs { get; set; }
    }
}
