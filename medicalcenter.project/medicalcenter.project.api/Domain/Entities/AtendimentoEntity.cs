namespace medicalcenter.project.api.Domain.Entities
{
    public class AtendimentoEntity
    {
        public Guid Id { get; set; }
        public Guid PacienteId { get; set; }
        public int NumeroSequencial { get; set; }
        public DateTime DataHoraChegada { get; set; }
        public string Status { get; set; }
    }
}
