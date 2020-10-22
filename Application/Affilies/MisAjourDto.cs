

using System;
using System.Collections.Generic;
using Domain;
using Newtonsoft.Json;

namespace Application.Affilies
{
    public class MisAjourDto
    {
        public int Id { get; set; }
        public string CinAffilie { get; set; }
        public DateTime DateMaj { get; set; }
        public string TypeMaj { get; set; }
        public string Info { get; set; }
        public string UserMaj { get; set; }
        public int NumLotMaj { get; set; }
         public bool AvcSCarte { get; set; }
        public int NumCarte { get; set; }
        public bool EnCours { get; set; }
        public string infoIdentifiant { get; set; }

        public  ICollection<RejetMajDto> RejetMajs { get; set; }


    }
}