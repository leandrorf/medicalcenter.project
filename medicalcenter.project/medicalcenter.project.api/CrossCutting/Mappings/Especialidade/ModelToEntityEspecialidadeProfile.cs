using AutoMapper;
using medicalcenter.project.api.Domain.Entities;
using medicalcenter.project.api.Domain.Model;

namespace medicalcenter.project.api.CrossCutting.Mappings.Especialidade
{
    public class ModelToEntityAtendimentoProfile : Profile
    {
        public ModelToEntityAtendimentoProfile( )
        {
            CreateMap<EspecialidadeModel, EspecialidadeEntity>( ).ReverseMap( );
        }
    }
}