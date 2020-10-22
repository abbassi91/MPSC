using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Affilies
{
    
    
    public class ListDossier
    {
     
      public QpDtos Affilie { get; set; }
       
        public class Query : IRequest<QpDtos> 
        { 
            public Query(string cin,DateTime fromDate)
            {
                FromDate   =   fromDate;
                Cin     =   cin;
            }
            public DateTime FromDate { get; set; }
  
            public string Cin { get; set; }
            
        }

        public class Handler : IRequestHandler<Query, QpDtos>
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

            public async Task<QpDtos> Handle(Query request, CancellationToken cancellationToken)
            {

                var aff = await _context.Qps.FindAsync(request.Cin);

                  if (aff == null)
                    throw new RestException(HttpStatusCode.NotFound, new { affilie = "Not found" });
           
 
                var z = _mapper.Map<Qp, QpDtos>(aff);

                  
            


        
        //LES SOMMES DES DOSSIERS DE REMBOURSSEMENT 
        
        //DOSSIERS TP
                z.SomRemCnopsTP    =   Math.Round(Double.Parse(z.calculate(1,0,"TP").ToString()),2);
                z.SomRemMpscTP     =   Math.Round(Double.Parse(z.calculate(2,0,"TP").ToString()),2);
                z.SomRemTP         =   Math.Round(Double.Parse(z.calculate(3,0,"TP").ToString()),2);
                z.SomFreEngageTP   =   Math.Round(Double.Parse(z.calculate(4,0,"TP").ToString()),2);
                z.NbrDossierTP     =   int.Parse(z.calculate(5,0,"TP").ToString());

        //DOSSIERS INDIVIDUELS
                z.SomRemCnopsDI     =   Math.Round(Double.Parse(z.calculate(1,0,"").ToString()),2);
                z.SomRemMpscDI      =   Math.Round(Double.Parse(z.calculate(2,0,"").ToString()),2);
                z.SomRemDI          =   Math.Round(Double.Parse(z.calculate(3,0,"").ToString()),2);
                z.SomFreEngageDI    =   Math.Round(Double.Parse(z.calculate(4,0,"").ToString()),2);
                z.NbrDossierDI      =   int.Parse(z.calculate(5,0,"").ToString());

        // DOSSIERS TP + DI
                z.SomRemCnops     =  Math.Round(Double.Parse((z.SomRemCnopsTP+z.SomRemCnopsDI).ToString()),2);
                z.SomRemMpsc      =  Math.Round(Double.Parse((z.SomRemMpscTP +  z.SomRemMpscDI).ToString()),2);
                z.SomRem          =  Math.Round(Double.Parse((z.SomRemTP + z.SomRemDI).ToString()),2);
                z.SomFreEngage    =  Math.Round(Double.Parse((z.SomFreEngageTP+z.SomFreEngageDI).ToString()),2);;
                z.NbrDossier      =  z.NbrDossierDI  +  z.NbrDossierTP;
                //z.SomeAvanceMpsc  =  Math.Round(double.Parse(z.AvanceMpsc().ToString()),2);
               // z.Somecumule      =  Math.Round(double.Parse(z.cumule().ToString()),2);

                
               

 
        

            


            return z;
                
      
            }
        }
    }
}