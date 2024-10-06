using medicalcenter.project.api.Domain.Dto.Paciente;
using medicalcenter.project.api.Domain.Interfaces.Services.Base;

namespace medicalcenter.project.api.Domain.Interfaces.Services
{
    public interface IPacienteService : IBaseService<PacienteDtoResponse, PacienteDtoRequest>
    {
        Task<PacienteDtoResponse> GetByIdAsync( Guid id );
    }
}