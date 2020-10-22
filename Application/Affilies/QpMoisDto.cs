using System;

namespace Application.Affilies
{
    public class QpMoisDto
    {
        public int IdPai { get; set; }
        public string CinQp { get; set; }
        public DateTime Date { get; set; }
        public double? Qp { get; set; }
        public string Rcar { get; set; }
        public string TypePai { get; set; }
        public int? CodeEchanceQpMois { get; set; }
        public double? Code303 { get; set; }
        public double? Code304 { get; set; }
        public string IdUser { get; set; }
        public DateTime DateSaisie { get; set; }
        public string Observation { get; set; }
        public string CinPaiement { get; set; }    

    }
}