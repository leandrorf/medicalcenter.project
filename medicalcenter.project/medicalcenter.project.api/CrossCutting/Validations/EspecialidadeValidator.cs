using FluentValidation;
using medicalcenter.project.api.Domain.Dto.Especialidade;

namespace medicalcenter.project.api.CrossCutting.Validations
{
    public class EspecialidadeValidator : AbstractValidator<EspecialidadeDtoRequest>
    {
        public EspecialidadeValidator( )
        {
            Validations( );
        }

        private void Validations( )
        {
            RuleFor( x => x.Nome )
                .NotEmpty( )
                .WithMessage( "O registro [Nome] é obrigatório." );

            RuleFor( x => x.Descricao )
                .NotEmpty( )
                .WithMessage( "O registro [Descricao] é obrigatório." );
        }
    }
}