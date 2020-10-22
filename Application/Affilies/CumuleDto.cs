using System;

namespace Application.Affilies
{
    public class CumuleDto
    {
        public int id { get; set; }
        public string Cin { get; set; }
        public double? Montant { get; set; }
        public string Observation { get; set; }
        public string IdUser { get; set; }
        public DateTime DateAffectation { get; set; }

    }

}