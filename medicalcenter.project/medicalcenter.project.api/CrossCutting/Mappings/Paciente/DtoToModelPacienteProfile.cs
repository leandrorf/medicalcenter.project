using AutoMapper;
using medicalcenter.project.api.Domain.Dto.Paciente;
using medicalcenter.project.api.Domain.Model;

namespace medicalcenter.project.api.CrossCutting.Mappings.Paciente
{
    public class DtoToModelPacienteProfile : Profile
    {
        public DtoToModelPacienteProfile( )
        {
            CreateMap<PacienteDtoResponse, PacienteModel>( ).ReverseMap( );
            CreateMap<PacienteDtoRequest, PacienteModel>( ).ReverseMap( );
        }
    }
}