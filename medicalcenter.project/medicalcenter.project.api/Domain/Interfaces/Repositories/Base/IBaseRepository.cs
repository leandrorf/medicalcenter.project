using medicalcenter.project.api.Domain.Entities.Base;

namespace medicalcenter.project.api.Domain.Interfaces.Repositories.Base
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAsync( );

        Task<T> PostAsync( T entity );

        Task<T> PutAsync( T entity );

        Task<bool> DeleteAsync( Guid id );
    }
}