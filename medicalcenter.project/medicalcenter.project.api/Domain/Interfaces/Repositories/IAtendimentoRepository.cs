using medicalcenter.project.api.Domain.Dto.Atendimento;
using medicalcenter.project.api.Domain.Entities;
using medicalcenter.project.api.Domain.Enums;
using medicalcenter.project.api.Domain.Interfaces.Repositories.Base;

namespace medicalcenter.project.api.Domain.Interfaces.Repositories
{
    public interface IAtendimentoRepository : IBaseRepository<AtendimentoEntity>
    {
        Task<bool> CheckExists( Guid id );
        Task<AtendimentoEntity> GetByIdAsync( Guid id );
        Task<AtendimentoEntity> GetNextPatient( EAreasAtendimento service );
        Task<IEnumerable<AtendimentoEntity>> GetQueueForService( EAreasAtendimento service );
    }
}