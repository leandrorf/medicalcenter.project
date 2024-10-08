using medicalcenter.project.api.Domain.Dto.Base;

namespace medicalcenter.project.api.Domain.Dto.Triagem
{
    public class TriagemDtoResponse : BaseDto
    {
        public Guid AtendimentoId { get; set; }
        public Guid EspecialidadeId { get; set; }
        public string EspecialidadeNome { get; set; }
        public string PacienteNome { get; set; }
        public string Sintomas { get; set; }
        public string PressaoArterial { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }
    }
}