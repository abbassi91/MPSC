using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Affilies
{
    public class Create
    {
        public class Command : IRequest<Affilie>
        {
            public string Matricule { get; set; }
            public string NPension { get; set; }
            public string Nom { get; set; }
            public string Prenom { get; set; }
            public string Cin { get; set; }
            public DateTime DateNaissance { get; set; }
            public string Telephone { get; set; }
            public string Telephone2 { get; set; }
            public string Sexe { get; set; }
            public string Adresse { get; set; }
            public string Ville { get; set; }
            public string CodePostale { get; set; }
            public string Rib { get; set; }
            public int? Rang { get; set; }
            public string TypeAffilie { get; set; }
            public string NumAdherent { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Cin).NotEmpty().NotNull();
                //RuleFor(x => x.Matricule).NotEmpty().MinimumLength(5);
                RuleFor(x => x.Matricule).NotEmpty().MinimumLength(5);
                RuleFor(x => x.Nom).NotEmpty();
                RuleFor(x => x.Prenom).NotEmpty();
                RuleFor(x => x.Adresse).NotEmpty().MinimumLength(10);
                RuleFor(x => x.Ville).NotEmpty();
                RuleFor(x => x.TypeAffilie).Matches("[ARVO]");
                RuleFor(x => x.Sexe).Matches("[MF]");
                //NotEmpty().Matches(@"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[13-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$");
                RuleFor(x => x.DateNaissance);
                RuleFor(x => x.Rib).MaximumLength(24).MinimumLength(24).WithMessage("Le RIB DOIT CONTENIR 24 CHIFRES");
            }
        }

        public class Handler : IRequestHandler<Command,Affilie>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }



            public async Task<Affilie> Handle(Command request, CancellationToken cancellationToken)
            {

                var affilie = new Affilie
                {
                    Matricule = request.Matricule,
                    NPension=request.NPension,
                    Nom = request.Nom,
                    Prenom = request.Prenom,
                    Cin = request.Cin,
                    DateNaissance = request.DateNaissance,
                    Telephone = request.Telephone,
                    Telephone2 = request.Telephone,
                    Sexe = request.Sexe,
                    Adresse = request.Adresse,
                    Ville = request.Ville,
                    CodePostale = request.CodePostale,
                    Rib = request.Rib,
                    Rang = request.Rang,
                    TypeAffilie = request.TypeAffilie,
                    NumAdherent = request.NumAdherent,
                    SituationVital=1

                };
                 _context.Affilies.Add(affilie);

                
                  var success = await _context.SaveChangesAsync()>0;

                  if (success) return affilie;

                  throw new Exception("Problem saving changes");
            }
        }
    }
}