namespace medicalcenter.project.api.Domain.Dto.Triagem
{
    public class TriagemDtoRequest
    {
        public Guid AtendimentoID { get; set; }
        public Guid EspecialidadeId { get; set; }
        public string Sintomas { get; set; }
        public string PressaoArterial { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }
    }
}