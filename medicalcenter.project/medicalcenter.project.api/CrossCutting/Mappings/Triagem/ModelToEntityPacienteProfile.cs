using AutoMapper;
using medicalcenter.project.api.Domain.Entities;
using medicalcenter.project.api.Domain.Model;

namespace medicalcenter.project.api.CrossCutting.Mappings.Triagem
{
    public class ModelToEntityTriagemProfile : Profile
    {
        public ModelToEntityTriagemProfile( )
        {
            CreateMap<TriagemModel, TriagemEntity>( ).ReverseMap( );
        }
    }
}