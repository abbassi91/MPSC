using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Affilies;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    public class AffiliesController :BaseController
    {
        private readonly IMediator _mediator;
        public AffiliesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Affilie>> Create(Create.Command command)
        {
            return await Mediator.Send(command);
        }

 
        [HttpGet]
        public async Task<ActionResult<List.AffilieEnvelope>> List(int? limit,int? offset, string cin)
        {
            return await Mediator.Send(new List.Query(limit,offset, cin));
        }

         [HttpGet("{cin}/dossiers")]
        public async Task<ActionResult<AffilieDto>> Details(String cin)
        {
            return await Mediator.Send(new Details.Query{Cin = cin});
        } 


        [HttpGet("{Rech}")]
        public async Task<ActionResult<QpDtos>> ListDossier(String Rech,DateTime date)
        {
            return await Mediator.Send(new ListDossier.Query(Rech,date));
        }
 

        
 

    
        
    }
}