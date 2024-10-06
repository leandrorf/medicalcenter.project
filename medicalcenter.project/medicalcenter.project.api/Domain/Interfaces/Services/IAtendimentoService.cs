using medicalcenter.project.api.Domain.Dto.Atendimento;
using medicalcenter.project.api.Domain.Entities;
using medicalcenter.project.api.Domain.Enums;
using medicalcenter.project.api.Domain.Interfaces.Services.Base;

namespace medicalcenter.project.api.Domain.Interfaces.Services
{
    public interface IAtendimentoService : IBaseService<AtendimentoDtoResponse, AtendimentoDtoRequest>
    {
        Task<AtendimentoDtoResponse> GetByIdAsync( Guid id );
        Task<AtendimentoDtoResponse> GetNextPatient( EAreasAtendimento service );
        Task<IEnumerable<AtendimentoDtoResponse>> GetQueueForService( EAreasAtendimento service );
    }
}