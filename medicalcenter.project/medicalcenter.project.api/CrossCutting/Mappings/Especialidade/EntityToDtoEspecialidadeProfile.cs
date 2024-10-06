using AutoMapper;
using medicalcenter.project.api.Domain.Dto.Especialidade;
using medicalcenter.project.api.Domain.Entities;

namespace medicalcenter.project.api.CrossCutting.Mappings.Especialidade
{
    public class EntityToDtoAtendimentoProfile : Profile
    {
        public EntityToDtoAtendimentoProfile( )
        {
            CreateMap<EspecialidadeEntity, EspecialidadeDtoResponse>( ).ReverseMap( );
        }
    }
}