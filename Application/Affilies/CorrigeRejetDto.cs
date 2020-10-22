using System;
using System.Collections.Generic;
using Domain;

namespace Domain
{
    public partial class CorrigeRejetDto
    {
         public int id { get; set; }
        public int idRej { get; set; }
        public string UserCorrigeRejet { get; set; }
        
        public DateTime DateCorrige { get; set; }

        public int numLot { get; set; }
    
    }
}
