using medicalcenter.project.api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace medicalcenter.project.api.Data.Mapping
{
    public class AtendimentoMapping : IEntityTypeConfiguration<AtendimentoEntity>
    {
        public void Configure( EntityTypeBuilder<AtendimentoEntity> builder )
        {
            builder.ToTable( "Atendimentos" );

            builder.HasKey( x => x.Id );
            builder.Property( x => x.NumeroSequencial ).ValueGeneratedOnAdd( );
            builder.Property( x => x.DataHoraChegada ).IsRequired( );
            builder.Property( x => x.Status ).IsRequired( );

            builder.Property( x => x.PacienteId ).Metadata.SetAfterSaveBehavior( PropertySaveBehavior.Ignore );
            builder.Property( x => x.NumeroSequencial ).Metadata.SetAfterSaveBehavior( PropertySaveBehavior.Ignore );
            builder.Property( x => x.DataHoraChegada ).Metadata.SetAfterSaveBehavior( PropertySaveBehavior.Ignore );

            builder.HasOne<PacienteEntity>( )
                .WithMany( )
                .HasForeignKey( nameof( AtendimentoEntity.PacienteId ) )
                .IsRequired( );
        }
    }
}