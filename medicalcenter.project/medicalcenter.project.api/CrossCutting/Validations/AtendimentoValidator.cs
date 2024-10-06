using FluentValidation;
using medicalcenter.project.api.Domain.Dto.Atendimento;

namespace medicalcenter.project.api.CrossCutting.Validations
{
    public class AtendimentoValidator : AbstractValidator<AtendimentoDtoRequest>
    {
        public AtendimentoValidator( )
        {
            Validations( );
        }

        private void Validations( )
        {
            RuleFor( x => x.PacienteId )
                .NotEmpty( )
                .WithMessage( "O registro [PacienteId] é obrigatório." );
        }
    }
}