using AutoMapper;
using medicalcenter.project.api.Domain.Entities;
using medicalcenter.project.api.Domain.Model;

namespace medicalcenter.project.api.CrossCutting.Mappings.Atendimento
{
    public class ModelToEntityAtendimentoProfile : Profile
    {
        public ModelToEntityAtendimentoProfile( )
        {
            CreateMap<AtendimentoModel, AtendimentoEntity>( ).ReverseMap( );
        }
    }
}