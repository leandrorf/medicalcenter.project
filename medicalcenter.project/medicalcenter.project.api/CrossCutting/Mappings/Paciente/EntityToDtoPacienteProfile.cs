using AutoMapper;
using medicalcenter.project.api.Domain.Dto.Paciente;
using medicalcenter.project.api.Domain.Entities;

namespace medicalcenter.project.api.CrossCutting.Mappings.Paciente
{
    public class EntityToDtoPacienteProfile : Profile
    {
        public EntityToDtoPacienteProfile( )
        {
            CreateMap<PacienteEntity, PacienteDtoResponse>( ).ReverseMap( );
        }
    }
}