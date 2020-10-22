using System;
using System.Collections.Generic;
using Domain;
using Newtonsoft.Json;

namespace Application.Affilies
{
    public class AffilieDto
    {
        public string Matricule { get; set; }
        public string NPension { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Cin { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string CodePostale { get; set; }
        public DateTime DateNaissance {get;set;}
        public string Sexe { get; set; }
        public string Telephone { get; set; }
        public string Telephone2 { get; set; }
        public string Rib { get; set; }
        public int? Rang { get; set; }
        public int? SituationVital { get; set; }
        public string TypeAffilie { get; set; }  
        public string NumAdherent { get; set; }
        public string Email { get; set; }



        [JsonProperty("Qps")] public ICollection<QpDto> Qps { get; set; }
        [JsonProperty("Cumule")] public ICollection<CumuleDto> CumuleQps { get; set; }
        [JsonProperty("QpMois")] public ICollection<QpMoisDto> qpMois { get; set; }
        public  ICollection<AvanceMpscDto> AvanceCheques { get; set; }
        public  ICollection<MisAjourDto> MisAjours { get; set; }
        public  ICollection<CarteDto> Cartes { get; set; }
         public  ICollection<ConjointDto> Conjoints { get; set; }
          public  ICollection<EnfantDto> Enfants { get; set; }
        public double?  SomFreEngageTP { get; set; }
         public double? SomRemMpscTP { get; set; }
         public double? SomRemCnopsTP { get; set; } 
         public double? SomRemTP { get; set; } 
         public int     NbrDossierTP { get; set; }

         public double? SomFreEngageDI { get; set; }
         public double? SomRemMpscDI { get; set; }
         public double? SomRemCnopsDI { get; set; } 
         public double? SomRemDI { get; set; } 
         public int    NbrDossierDI { get; set; }

        public double? SomFreEngage { get; set; }
         public double? SomRemMpsc { get; set; }
         public double? SomRemCnops { get; set; } 
         public double? SomRem { get; set; } 
         public int    NbrDossier { get; set; }

         public double? Somecumule { get; set; } 
         public double? SomeAvanceMpsc { get; set; } 
      

        //public double? SomRet304 { get; set; }
        //public double? SomRet303 { get; set; }
        public double? TotalRetenues { get; set; }
        public double? Rest {get;set;} 
        public double? Reliquat {get;set;} 


                public double? cumule()
                {
                        double? info = 0; 
                    foreach (var item in this.CumuleQps)
                                    {
                                        info+=item.Montant ?? 0.0;
                                    }

                                    return Math.Round(double.Parse(info.ToString()),2);
                }


                   public double? AvanceMpsc()
                    {
                        double? x = 0; 
                        foreach (var item in this.AvanceCheques)
                        {
                         x+=item.MontantAv ?? 0.0;
                        }
                        return Math.Round(double.Parse(x.ToString()),2);
                    } 

 

            public  double? calculate(int a,int b,string type)
            {
             double? info = 0; 

            

             if(a==0)
             {
                 foreach (var item in this.qpMois)
                    {
                        if(b==1)
                            info+=item.Code303 ?? 0.0;
                        if(b==2)
                            info+=item.Code304 ?? 0.0;
                        if(b==3)
                        {
                            if ((item.Observation!="ANNULE RCAR") && (item.Observation!="ANNULE DRH") && (item.Observation!="ANNULE"))
                              info+=item.Qp ?? 0.0;  
                        }
                           if(b==4)
                        {
                            if ((item.TypePai=="paiement manuel"))
                              info+=item.Qp ?? 0.0;  
                        }
                          
                    }
             }

             if(a!=0)
             {
                 foreach (var item in this.Qps)
                    {
                        if(type=="TP")
                        {
                            if(item.Observation!="Med")
                            {
                                    if(a==1)
                                info+=item.RembAmo ?? 0.0;
                                    if(a==2)
                                info+=item.RembMpsc ?? 0.0;
                                    if(a==3)
                                info+=item.TotalRemb ?? 0.0;
                                    if(a==4)
                                info+=item.FraisEngage ?? 0.0;
                                    if(a==5)
                                info++;
                            }  

                        }
                        else
                        {
                               if(item.Observation=="Med")
                            {
                                    if(a==1)
                                info+=item.RembAmo ?? 0.0;
                                    if(a==2)
                                info+=item.RembMpsc ?? 0.0;
                                    if(a==3)
                                info+=item.TotalRemb ?? 0.0;
                                    if(a==4)
                                info+=item.FraisEngage ?? 0.0;
                                    if(a==5)
                                info++;
                            }  

                        }
                    
                    }
             }
            
             return info;
             
            }
       
        
    }
}