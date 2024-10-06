using medicalcenter.project.api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace medicalcenter.project.api.Data.Mapping
{
    public class PacienteMapping : IEntityTypeConfiguration<PacienteEntity>
    {
        public void Configure( EntityTypeBuilder<PacienteEntity> builder )
        {
            builder.ToTable( "Pacientes" );

            builder.HasKey( x => x.Id );
            builder.Property( x => x.Nome ).IsRequired( );
            builder.Property( x => x.Telefone ).IsRequired( );
            builder.Property( x => x.Sexo ).IsRequired( );
            builder.Property( x => x.Email ).IsRequired( );
        }
    }
}