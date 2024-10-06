using medicalcenter.project.api.Data.Mapping;
using medicalcenter.project.api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace medicalcenter.project.api.Data.Context
{
    public class SqlServerDbContext : DbContext
    {
        private DbSet<PacienteEntity> Patient { get; set; }
        private DbSet<AtendimentoEntity> Atendimento { get; set; }
        private DbSet<TriagemEntity> Triagem { get; set; }
        private DbSet<EspecialidadeEntity> Especialidades { get; set; }

        public SqlServerDbContext( DbContextOptions<SqlServerDbContext> options )
            : base( options )
        {
        }

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {
            base.OnConfiguring( optionsBuilder );
        }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            base.OnModelCreating( modelBuilder );

            modelBuilder.Entity<PacienteEntity>( new PacienteMapping( ).Configure );
            modelBuilder.Entity<AtendimentoEntity>( new AtendimentoMapping( ).Configure );
            modelBuilder.Entity<TriagemEntity>( new TriagemMapping( ).Configure );
            modelBuilder.Entity<EspecialidadeEntity>( new EspecialidadeMapping( ).Configure );
        }
    }
}