using medicalcenter.project.api.Domain.Entities.Base;

namespace medicalcenter.project.api.Domain.Entities
{
    public class TriagemEntity : BaseEntity
    {
        public Guid AtendimentoId { get; set; }
        public Guid EspecialidadeId { get; set; }
        public string Sintomas { get; set; }
        public string PressaoArterial { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }

        //public AtendimentoEntity Atendimento { get; set; }
        //public EspecialidadeEntity Especialidade { get; set; }
    }
}