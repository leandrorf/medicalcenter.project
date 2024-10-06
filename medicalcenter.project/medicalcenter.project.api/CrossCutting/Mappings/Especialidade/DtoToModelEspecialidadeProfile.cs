using AutoMapper;
using medicalcenter.project.api.Domain.Dto.Especialidade;
using medicalcenter.project.api.Domain.Model;

namespace medicalcenter.project.api.CrossCutting.Mappings.Especialidade
{
    public class DtoToModelAtendimentoProfile : Profile
    {
        public DtoToModelAtendimentoProfile( )
        {
            CreateMap<EspecialidadeDtoResponse, EspecialidadeModel>( ).ReverseMap( );
            CreateMap<EspecialidadeDtoRequest, EspecialidadeModel>( ).ReverseMap( );
        }
    }
}