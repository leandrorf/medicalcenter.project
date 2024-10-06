using AutoMapper;
using medicalcenter.project.api.Domain.Entities;
using medicalcenter.project.api.Domain.Model;

namespace medicalcenter.project.api.CrossCutting.Mappings.Paciente
{
    public class ModelToEntityPacienteProfile : Profile
    {
        public ModelToEntityPacienteProfile( )
        {
            CreateMap<PacienteModel, PacienteEntity>( ).ReverseMap( );
        }
    }
}