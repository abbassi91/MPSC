using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Affilies
{
    public class List
    {
        public class AffilieEnvelope
        {
            public AffilieEnvelope(List<AffilieDto> affilies ,int affilieCount /*, double? totalFraisEngage, double? totalRemAmo, double? totalRemMPSC*/)
            {
                Affilies = affilies;
                AffilieCount=affilieCount;
         
               /* TotalFraisEngage = totalFraisEngage;
                TotalRemAmo = totalRemAmo;
                TotalRemMPSC = totalRemMPSC;
                TotalRem = TotalRemAmo+TotalRemMPSC;*/
            }

            public List<AffilieDto> Affilies { get; set; }
            public int AffilieCount { get; set; }
            /*public double? TotalFraisEngage { get; set; }
            public double? TotalRemAmo { get; set; }
            public double? TotalRemMPSC { get; set; }
            public double? TotalRem { get; set; }*/

        }
        public class Query : IRequest<AffilieEnvelope> 
        { 
            public Query(int? limit, int? offset,string rech)
            {
                Limit   =   limit;
                Offset  =   offset;
                Rech     =   rech;
            }
            public int? Limit { get; set; }
            public int? Offset { get; set; }
            public string Rech { get; set; }
            
        }

        public class Handler : IRequestHandler<Query, AffilieEnvelope>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
             private readonly IUserAccessor _userAccessor;
            public Handler(DataContext context, IMapper mapper,IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
                _mapper = mapper;
                _context = context;
            }

            public async Task<AffilieEnvelope> Handle(Query request, CancellationToken cancellationToken)
            {

                var queryable = _context.Affilies
                .OrderBy(x=>x.DateNaissance).AsQueryable();
                   
                   /* .Where(x => x.Cin== request.Cin)
                    .OrderBy(x => x.DateNaissance)
                    .AsQueryable();*/

             



                if(request.Rech !=null)
                queryable = queryable.Where(x => (x.Matricule==request.Rech) || x.Cin==request.Rech || (x.Nom+' '+x.Prenom).Contains(request.Rech));
                

                var affilies = await queryable
                    .Skip(request.Offset ?? 0)
                    .Take(request.Limit ?? 3).ToListAsync();

            var z = _mapper.Map<List<Affilie>, List<AffilieDto>>(affilies).ToList();

            
            
    

         foreach (var item in z)
            {
        //LES SOMMES DES DOSSIERS DE REMBOURSSEMENT 

        //DOSSIERS TP
                item.SomRemCnopsTP    =   Math.Round(Double.Parse(item.calculate(1,0,"TP").ToString()),2);
                item.SomRemMpscTP     =   Math.Round(Double.Parse(item.calculate(2,0,"TP").ToString()),2);
                item.SomRemTP         =   Math.Round(Double.Parse(item.calculate(3,0,"TP").ToString()),2);
                item.SomFreEngageTP   =   Math.Round(Double.Parse(item.calculate(4,0,"TP").ToString()),2);
                item.NbrDossierTP     =   int.Parse(item.calculate(5,0,"TP").ToString());

        //DOSSIERS INDIVIDUELS
                item.SomRemCnopsDI     =   Math.Round(Double.Parse(item.calculate(1,0,"").ToString()),2);
                item.SomRemMpscDI      =   Math.Round(Double.Parse(item.calculate(2,0,"").ToString()),2);
                item.SomRemDI          =   Math.Round(Double.Parse(item.calculate(3,0,"").ToString()),2);
                item.SomFreEngageDI    =   Math.Round(Double.Parse(item.calculate(4,0,"").ToString()),2);
                item.NbrDossierDI      =   int.Parse(item.calculate(5,0,"").ToString());

        // DOSSIERS TP + DI
                item.SomRemCnops     =  Math.Round(Double.Parse((item.SomRemCnopsTP+item.SomRemCnopsDI).ToString()),2);
                item.SomRemMpsc      =  Math.Round(Double.Parse((item.SomRemMpscTP +  item.SomRemMpscDI).ToString()),2);
                item.SomRem          =  Math.Round(Double.Parse((item.SomRemTP + item.SomRemDI).ToString()),2);
                item.SomFreEngage    =  Math.Round(Double.Parse((item.SomFreEngageTP+item.SomFreEngageDI).ToString()),2);;
                item.NbrDossier      =  item.NbrDossierDI  +  item.NbrDossierTP;
                item.SomeAvanceMpsc  =  Math.Round(double.Parse(item.AvanceMpsc().ToString()),2);
                item.Somecumule      =  Math.Round(double.Parse(item.cumule().ToString()),2);

                
               

        //LES SOMMES DES RETENUES 

               
                item.TotalRetenues  =   Math.Round(Double.Parse(item.calculate(0,3,"TP").ToString()),2);
                item.Rest           =   Math.Round(Double.Parse(((item.calculate(4,0,"TP")+(item.cumule())+(item.AvanceMpsc()))-item.calculate(0,3,"TP")).ToString()),2);
                item.Reliquat       =   Math.Round(Double.Parse((item.calculate(4,0,"TP")-(item.calculate(0,4,""))).ToString()),2);
                
                if(item.cumule()>0)
                {
                      if(item.Reliquat <0 || item.Rest<=0)
                      item.Reliquat  =0;
                      if(item.Reliquat>item.Rest)
                      item.Reliquat=item.Rest;
                }
                else
                item.Reliquat=item.Rest;
              

                 //item.SomRet303=item.calculate(0,1);
                //item.SomRet304=item.calculate(0,2);

            }
           
        
            
            return new AffilieEnvelope(z,queryable.Count());
                
                
               /* var Query_ = _context.Affilies.AsQueryable();

                  

                     var affilies_ = await Query_
                    .Skip(request.Offset ?? 0)
                    .Take(request.Limit ?? 3).ToListAsync();
            

                var x = _mapper.Map<List<Affilie>, List<AffilieDto>>(affilies_).ToList();

                return affilies_.GroupJoin(
                           _context.Qps,
                           o => o.Cin,
                           p => p.NCinNavigation.Cin,
                           (o, pg) => 
                           new AffilieEnvelope(x)).FirstOrDefault();*/
                           /*,pg
                           .Sum(p => p.FraisEngage)
                           ,pg.Sum(p => p.RembAmo)
                           ,pg.Sum(p => p.RembMpsc))).FirstOrDefault();*/
            }
        }
    }
}