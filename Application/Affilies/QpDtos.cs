using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Application.Affilies
{


    public class QpDtos
    {


        [JsonProperty("Qps")] public ICollection<QpDto> Qps { get; set; }
        public int QpCount { get; set; }

        public double? SomRemCnopsTP { get; set; }
        public double? SomRemMpscTP { get; set; }
        public double? SomRemTP { get; set; }
        public double? SomFreEngageTP { get; set; }
        public double? NbrDossierTP { get; set; }
        public double? SomRemCnopsDI { get; set; }
        public double? SomRemMpscDI { get; set; }
        public double? SomRemDI { get; set; }
        public double? SomFreEngageDI { get; set; }
        public double? NbrDossierDI { get; set; }
        public double? SomRemCnops { get; set; }
        public double? SomRemMpsc { get; set; }
        public double? SomRem { get; set; }
        public double? SomFreEngage { get; set; }
        public double? NbrDossier { get; set; }
        public double? SomeAvanceMpsc { get; set; }
        public double? Somecumule { get; set; }


         public  double? calculate(int a,int b,string type)
            {
             double? info = 0; 

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