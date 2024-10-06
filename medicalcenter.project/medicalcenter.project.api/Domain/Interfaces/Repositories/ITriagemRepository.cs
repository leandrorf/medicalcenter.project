using medicalcenter.project.api.Domain.Entities;
using medicalcenter.project.api.Domain.Interfaces.Repositories.Base;

namespace medicalcenter.project.api.Domain.Interfaces.Repositories
{
    public interface ITriagemRepository : IBaseRepository<TriagemEntity>
    {
        Task<bool> CheckExists( Guid id );

        Task<TriagemEntity> GetByIdAsync( Guid id );
    }
}