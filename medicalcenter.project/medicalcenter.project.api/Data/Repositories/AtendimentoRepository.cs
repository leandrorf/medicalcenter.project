using medicalcenter.project.api.Data.Context;
using medicalcenter.project.api.Data.Repositories.Base;
using medicalcenter.project.api.Domain.Entities;
using medicalcenter.project.api.Domain.Enums;
using medicalcenter.project.api.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace medicalcenter.project.api.Data.Repositories
{
    public class AtendimentoRepository : BaseRepository<AtendimentoEntity>, IAtendimentoRepository
    {
        public AtendimentoRepository( SqlServerDbContext context )
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

        public async Task<AtendimentoEntity> GetByIdAsync( Guid id )
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

        public async Task<AtendimentoEntity> GetNextPatient( EAreasAtendimento service )
        {
            try
            {
                AtendimentoEntity entity;

                switch ( service )
                {
                    case EAreasAtendimento.Triagem:
                    {
                        entity = _DbSet.ToListAsync( ).Result
                            .Where( x => x.Status == EStatusAtendimento.AguardandoTriagem
                                    || x.Status == EStatusAtendimento.AtendimentoTriagem )
                            .MinBy( x => x.NumeroSequencial );

                        break;
                    }
                    case EAreasAtendimento.Especialista:
                    {
                        entity = _DbSet.ToListAsync( ).Result.Where( x => x.Status == EStatusAtendimento.AguardandoEspecialista ).MinBy( x => x.NumeroSequencial );

                        break;
                    }
                    default:
                    {
                        throw new Exception( "Área não identificado no sistema" );
                    }
                }

                if ( entity == null )
                {
                    throw new Exception( "Nenhum paciente para ser atendido" );
                }

                return entity;
            }
            catch ( Exception ex )
            {
                throw new Exception( ex.Message );
            }
        }

        public async Task<IEnumerable<AtendimentoEntity>> GetQueueForService( EAreasAtendimento service )
        {
            try
            {
                IEnumerable<AtendimentoEntity> entity;

                switch ( service )
                {
                    case EAreasAtendimento.Triagem:
                    {
                        entity = _DbSet.ToListAsync( ).Result.Where( x => x.Status == EStatusAtendimento.AguardandoTriagem );
                        break;
                    }
                    case EAreasAtendimento.Especialista:
                    {
                        entity = _DbSet.ToListAsync( ).Result.Where( x => x.Status == EStatusAtendimento.AguardandoTriagem );
                        break;
                    }
                    default:
                    {
                        throw new Exception( "Área não identificado no sistema" );
                    }
                }

                return entity;
            }
            catch ( Exception ex )
            {
                throw new Exception( ex.Message );
            }
        }
    }
}