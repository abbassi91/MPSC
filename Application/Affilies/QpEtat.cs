using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Affilies
{
    public class QpEtat : IRequest<List<Affilie>>
    {

        public class Query : IRequest<List<Affilie>>
        {
            public string Cin {get;set;}
        }

        public class Handler : IRequestHandler<Query, List<Affilie>>
        {
            private readonly DataContext _context;
   
            public Handler(DataContext context, IMapper mapper)
            {
            
                _context = context;
            }

            public async Task<List<Affilie>> Handle(Query request, CancellationToken cancellationToken)
            {
                var dossier = await _context.Affilies.Include(x=>x.Qps).ToListAsync();

                return dossier;


            }
        }



    }
}