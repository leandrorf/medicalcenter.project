namespace medicalcenter.project.api.Domain.Entities
{
    public class TriagemEntity
    {
        public Guid Id { get; set; }
        public Guid AtendimentoID { get; set; }
        public Guid EspecialidadeId { get; set; }
        public string Sintomas { get; set; }
        public string PressaoArterial { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }
    }
}
