using AutoMapper;
using medicalcenter.project.api.Domain.Dto.Triagem;
using medicalcenter.project.api.Domain.Model;

namespace medicalcenter.project.api.CrossCutting.Mappings.Triagem
{
    public class DtoToModelTriagemProfile : Profile
    {
        public DtoToModelTriagemProfile( )
        {
            CreateMap<TriagemDtoResponse, TriagemModel>( ).ReverseMap( );
            CreateMap<TriagemDtoRequest, TriagemModel>( ).ReverseMap( );
        }
    }
}