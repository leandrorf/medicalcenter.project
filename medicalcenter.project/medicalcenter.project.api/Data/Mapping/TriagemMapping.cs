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

            //builder.HasOne( x => x.Especialidade ).WithMany( ).HasForeignKey( x => x.EspecialidadeId );
            //builder.HasOne( x => x.Atendimento ).WithMany( ).HasForeignKey( x => x.AtendimentoId );

            builder.HasOne<AtendimentoEntity>( )
                .WithMany( )
                .HasForeignKey( nameof( TriagemEntity.AtendimentoId ) )
                .IsRequired( );

            builder.HasOne<EspecialidadeEntity>( )
                .WithMany( )
                .HasForeignKey( nameof( TriagemEntity.EspecialidadeId ) )
                .IsRequired( );
        }
    }
}