using System;
using AutoMapper;
using Domain;

namespace Application.Affilies
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Affilie,AffilieDto>();
             CreateMap<Qp,QpDto>()
             .ForMember(d =>d.TotalRemb, o => o.MapFrom(s => Math.Round(double.Parse(s.TotalRemb.ToString()),2)));
             //.ForMember(d => d., o => o.MapFrom(s =>s.TotalRemb));

             CreateMap<QpMois,QpMoisDto>();
             //.ForMember(d => d.Qp, o => o.MapFrom(s => s.Qp));

             CreateMap<CumuleQp,CumuleDto>();

             CreateMap<AvanceCheque,AvanceMpscDto>();

            CreateMap<MisAjour,MisAjourDto>()
            .ForMember(d => d.TypeMaj, o => o.MapFrom(s => s.TypeMisAjourNavigation.Intitule));
           
           CreateMap<RejetMaj,RejetMajDto>();       
            CreateMap<CorrigeRejet,CorrigeRejetDto>();      

             CreateMap<Carte,CarteDto>();   
             CreateMap<Enfant,EnfantDto>();   
             CreateMap<Conjoint,ConjointDto>();   

             CreateMap<Qp,QpDtos>();

           

        }
    }
}