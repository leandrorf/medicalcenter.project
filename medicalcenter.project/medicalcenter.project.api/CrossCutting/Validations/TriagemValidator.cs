using FluentValidation;
using medicalcenter.project.api.Domain.Dto.Triagem;

namespace medicalcenter.project.api.CrossCutting.Validations
{
    public class TriagemValidator : AbstractValidator<TriagemDtoRequest>
    {
        public TriagemValidator( )
        {
            Validations( );
        }

        private void Validations( )
        {
            RuleFor( x => x.AtendimentoID )
                .NotEmpty( )
                .WithMessage( "O registro [AtendimentoID] é obrigatório." );

            RuleFor( x => x.EspecialidadeId )
                .NotEmpty( )
                .WithMessage( "O registro [EspecialidadeId] é obrigatório." );

            RuleFor( x => x.Sintomas )
                .NotEmpty( )
                .WithMessage( "O registro [Sintomas] é obrigatório." );

            RuleFor( x => x.PressaoArterial )
                .NotEmpty( )
                .WithMessage( "O registro [PressaoArterial] é obrigatório." );

            RuleFor( x => x.Peso )
                .NotEmpty( )
                .WithMessage( "O registro [Peso] é obrigatório." );

            RuleFor( x => x.Altura )
                .NotEmpty( )
                .WithMessage( "O registro [Altura] é obrigatório." );
        }
    }
}