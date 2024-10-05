using medicalcenter.project.api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace medicalcenter.project.api.Data.Mapping
{
    public class EspecialidadeMapping : IEntityTypeConfiguration<EspecialidadeEntity>
    {
        public void Configure( EntityTypeBuilder<EspecialidadeEntity> builder )
        {
            builder.ToTable( "Especialidades" );

            builder.HasKey( x => x.Id );
            builder.Property( x => x.Nome ).IsRequired( );
            builder.Property( x => x.Descricao );
        }
    }
}
