using AutoMapper;
using medicalcenter.project.api.Domain.Dto.Atendimento;
using medicalcenter.project.api.Domain.Model;

namespace medicalcenter.project.api.CrossCutting.Mappings.Atendimento
{
    public class DtoToModelAtendimentoProfile : Profile
    {
        public DtoToModelAtendimentoProfile( )
        {
            CreateMap<AtendimentoDtoResponse, AtendimentoModel>( ).ReverseMap( );
            CreateMap<AtendimentoDtoRequest, AtendimentoModel>( ).ReverseMap( );
        }
    }
}