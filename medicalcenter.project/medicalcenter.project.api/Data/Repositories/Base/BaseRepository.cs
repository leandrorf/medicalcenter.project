using medicalcenter.project.api.Data.Context;
using medicalcenter.project.api.Domain.Entities.Base;
using medicalcenter.project.api.Domain.Interfaces.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace medicalcenter.project.api.Data.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly DbSet<T> _DbSet;
        private readonly SqlServerDbContext _Context;

        public BaseRepository( SqlServerDbContext context )
        {
            _Context = context;
            _DbSet = _Context.Set<T>( );
        }

        public async Task<IEnumerable<T>> GetAsync( )
        {
            try
            {
                return await _DbSet.ToListAsync( );
            }
            catch ( Exception ex )
            {
                throw new Exception( ex.Message );
            }
        }

        public async Task<T> PostAsync( T entity )
        {
            try
            {
                _DbSet.Add( entity );
                await _Context.SaveChangesAsync( );

                return entity;
            }
            catch ( Exception ex )
            {
                throw new Exception( ex.Message );
            }
        }

        public async Task<T> PutAsync( T entity )
        {
            try
            {
                var result = await _DbSet.SingleOrDefaultAsync( x => x.Id == entity.Id );
                _Context.Entry( result ).CurrentValues.SetValues( entity );
                await _Context.SaveChangesAsync( );

                return entity;
            }
            catch ( Exception ex )
            {
                throw new Exception( ex.Message );
            }
        }

        public async Task<bool> DeleteAsync( Guid id )
        {
            try
            {
                var result = await _DbSet.SingleOrDefaultAsync( x => x.Id == id );
                _DbSet.Remove( result );
                await _Context.SaveChangesAsync( );

                return true;
            }
            catch ( Exception ex )
            {
                throw new Exception( ex.Message );
            }
        }
    }
}