using System;
using System.Collections.Generic;
using Domain;

namespace Domain
{
    public partial class TypeMisAjour
    {
          public int Id { get; set; }
           public string Intitule { get; set; }

            public virtual ICollection<MisAjour> MisAjours { get; set; }


    }
}