using System;


namespace Application
{
    public class CarteDto
    {
        
     
        public int id {get;set;}
        public string cinAff { get; set; }
        public DateTime DateArrive { get; set; }
        public DateTime DateEnvoie { get; set; }
         public string NomPoretur { get; set; }
        public string CinPorteur { get; set; }
        public bool Disponible {get;set;}
        public string UserReception { get; set; }
        public string UserEnvoie { get; set; }



    }
}

