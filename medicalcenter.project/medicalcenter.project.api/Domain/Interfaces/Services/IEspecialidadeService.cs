using medicalcenter.project.api.Domain.Dto.Especialidade;
using medicalcenter.project.api.Domain.Interfaces.Services.Base;

namespace medicalcenter.project.api.Domain.Interfaces.Services
{
    public interface IEspecialidadeService : IBaseService<EspecialidadeDtoResponse, EspecialidadeDtoRequest>
    {
        Task<EspecialidadeDtoResponse> GetByIdAsync( Guid id );
    }
}