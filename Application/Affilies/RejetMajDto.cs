using System;
using System.Collections.Generic;
using Domain;

namespace Domain
{
    public partial class RejetMajDto
    {
        public int id { get; set; }
        public string Motif { get; set; }
        public int Boite { get; set; }
        
        public DateTime DateRejet { get; set; }
        public string Observation { get; set; }
        public string UserRej { get; set; }
        public int IdMaj { get; set; }

        public ICollection<CorrigeRejetDto> CorrigeRejets { get; set; }
    }
}
