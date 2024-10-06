﻿using medicalcenter.project.api.Domain.Entities;
using medicalcenter.project.api.Domain.Interfaces.Repositories.Base;

namespace medicalcenter.project.api.Domain.Interfaces.Repositories
{
    public interface IEspecialidadeRepository : IBaseRepository<EspecialidadeEntity>
    {
        Task<EspecialidadeEntity> GetByIdAsync( Guid id );

        Task<bool> CheckExists( Guid id );
    }
}