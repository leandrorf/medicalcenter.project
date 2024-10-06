using FluentValidation;
using medicalcenter.project.api.Domain.Dto.Paciente;

namespace medicalcenter.project.api.CrossCutting.Validations
{
    public class PacienteValidator : AbstractValidator<PacienteDtoRequest>
    {
        public PacienteValidator( )
        {
            Validations( );
        }

        private void Validations( )
        {
            RuleFor( x => x.Nome )
                .NotEmpty( )
                .WithMessage( "O registro [Nome] é obrigatório." );

            RuleFor( x => x.Email )
                .NotEmpty( )
                .WithMessage( "O registro [Email] é obrigatório." );

            RuleFor( x => x.Sexo )
                .NotEmpty( )
                .WithMessage( "O registro [Sexo] é obrigatório." );

            RuleFor( x => x.Telefone )
                .NotEmpty( )
                .WithMessage( "O registro [Telefone] é obrigatório." );
        }
    }
}