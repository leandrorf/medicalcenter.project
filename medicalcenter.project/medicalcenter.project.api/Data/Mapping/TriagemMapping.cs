using medicalcenter.project.api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace medicalcenter.project.api.Data.Mapping
{
    public class TriagemMapping : IEntityTypeConfiguration<TriagemEntity>
    {
        public void Configure( EntityTypeBuilder<TriagemEntity> builder )
        {
            builder.ToTable( "Triagens" );

            builder.HasKey( x => x.Id );
            builder.Property( x => x.Sintomas ).IsRequired( );
            builder.Property( x => x.Peso ).IsRequired( );
            builder.Property( x => x.Altura ).IsRequired( );

            builder.HasOne<AtendimentoEntity>( )
                .WithMany( )
                .HasForeignKey( nameof( AtendimentoEntity.Id ) )
                .IsRequired( );

            builder.HasOne<EspecialidadeEntity>( )
                .WithMany( )
                .HasForeignKey( nameof( TriagemEntity.Id ) )
                .IsRequired( );
        }
    }
}
