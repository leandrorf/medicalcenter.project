using AutoMapper;
using medicalcenter.project.api.Domain.Dto.Atendimento;
using medicalcenter.project.api.Domain.Entities;

namespace medicalcenter.project.api.CrossCutting.Mappings.Atendimento
{
    public class EntityToDtoAtendimentoProfile : Profile
    {
        public EntityToDtoAtendimentoProfile( )
        {
            CreateMap<AtendimentoEntity, AtendimentoDtoResponse>( ).ReverseMap( );
        }
    }
}