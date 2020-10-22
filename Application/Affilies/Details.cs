using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Affilies
{
    public class Details
    {
      
         

            public AffilieDto Affilie { get; set; }
           

        
        public class Query : IRequest<AffilieDto> 
        { 
            public String Cin { get; set; }
            
        }

        public class Handler : IRequestHandler<Query, AffilieDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<AffilieDto> Handle(Query request, CancellationToken cancellationToken)
            {

                var affilie = await _context.Affilies.FindAsync(request.Cin);
                   

                if (affilie == null)
                    throw new RestException(HttpStatusCode.NotFound, new { affilie = "Not found" });


              AffilieDto z = _mapper.Map<Affilie, AffilieDto>(affilie);
            

                    var dossiers = from s in  z.Qps select s;
                    dossiers = dossiers.OrderBy(s => s.DatePaiementReel);
                    z.Qps=dossiers.ToList();

                    var retenues = from s in  z.qpMois select s;
                    retenues = retenues.OrderBy(s => s.Date);
                    z.qpMois=retenues.ToList();

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
                z.SomRemCnops       =  Math.Round(Double.Parse((z.SomRemCnopsTP+z.SomRemCnopsDI).ToString()),2);
                z.SomRemMpsc        =  Math.Round(Double.Parse((z.SomRemMpscTP +  z.SomRemMpscDI).ToString()),2);
                z.SomRem            =  Math.Round(Double.Parse((z.SomRemTP  +z.SomRemDI).ToString()),2);
                z.SomFreEngage      =  Math.Round(Double.Parse((z.SomFreEngageTP+z.SomFreEngageDI).ToString()),2);;
                z.NbrDossier        =  z.NbrDossierDI  +  z.NbrDossierTP   ;
                z.SomeAvanceMpsc    =  Math.Round(double.Parse(z.AvanceMpsc().ToString()),2);
                z.Somecumule        =  Math.Round(double.Parse(z.cumule().ToString()),2);

                
               

        //LES SOMMES DES RETENUES 

               
                z.TotalRetenues  =   Math.Round(Double.Parse(z.calculate(0,3,"TP").ToString()),2);
                z.Rest           =   Math.Round(Double.Parse(((z.calculate(4,0,"TP")+(z.cumule())+(z.AvanceMpsc()))-z.calculate(0,3,"TP")).ToString()),2);
                z.Reliquat       =   Math.Round(Double.Parse((z.calculate(4,0,"TP")-(z.calculate(0,4,""))).ToString()),2);
                
                if(z.cumule()>0)
                {
                      if(z.Reliquat <0 || z.Rest<=0)
                      z.Reliquat  =0;
                      if(z.Reliquat>z.Rest)
                      z.Reliquat=z.Rest;
                }
                else
                z.Reliquat=z.Rest;
              

            
           
        
            
            return z;
                

            }
        }
    }
}