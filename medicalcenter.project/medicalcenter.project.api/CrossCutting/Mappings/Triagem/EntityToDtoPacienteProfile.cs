using AutoMapper;
using medicalcenter.project.api.Domain.Dto.Triagem;
using medicalcenter.project.api.Domain.Entities;

namespace medicalcenter.project.api.CrossCutting.Mappings.Triagem
{
    public class EntityToDtoTriagemProfile : Profile
    {
        public EntityToDtoTriagemProfile( )
        {
            CreateMap<TriagemEntity, TriagemDtoResponse>( ).ReverseMap( );
        }
    }
}