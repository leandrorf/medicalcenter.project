﻿using medicalcenter.project.api.Data.Context;
using medicalcenter.project.api.Data.Repositories.Base;
using medicalcenter.project.api.Domain.Entities;
using medicalcenter.project.api.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace medicalcenter.project.api.Data.Repositories
{
    public class EspecialidadeRepository : BaseRepository<EspecialidadeEntity>, IEspecialidadeRepository
    {
        public EspecialidadeRepository( SqlServerDbContext context )
            : base( context )
        {
        }

        public async Task<bool> CheckExists( Guid id )
        {
            try
            {
                return await _DbSet.AnyAsync( x => x.Id == id );
            }
            catch ( Exception ex )
            {
                throw new Exception( ex.Message );
            }
        }

        public async Task<EspecialidadeEntity> GetByIdAsync( Guid id )
        {
            try
            {
                return await _DbSet.FirstAsync( x => x.Id == id );
            }
            catch ( Exception ex )
            {
                throw new Exception( ex.Message );
            }
        }
    }
}