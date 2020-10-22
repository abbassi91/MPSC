using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public string Bio { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<AvanceCheque> AvanceCheques { get; set; }
        public virtual ICollection<QpMois> QpMois { get; set; }
        public virtual ICollection<Qp> Qps { get; set; }
        public virtual ICollection<CumuleQp> CumuleQps { get; set; }
        public virtual ICollection<LotMisAjour> LotMisAjours { get; set; }

        public virtual ICollection<MisAjour> MisAjours { get; set; }
        public virtual ICollection<Echeance> Echeances { get; set; }
        public virtual ICollection<RejetMaj> RejetMajs { get; set; }
         public virtual ICollection<CorrigeRejet> CorrigeRejets { get; set; }
         public virtual ICollection<Carte> CartesEnvoies { get; set; }
         public virtual ICollection<Carte> CartesReceptions { get; set; }
                  public virtual ICollection<LotDgsn> UserEvoies { get; set; }
         public virtual ICollection<LotDgsn> UserDebuts { get; set; }

        
        
    }
}