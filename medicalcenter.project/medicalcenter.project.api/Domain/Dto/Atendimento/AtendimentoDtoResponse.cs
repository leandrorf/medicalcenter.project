using medicalcenter.project.api.Domain.Dto.Base;
using medicalcenter.project.api.Domain.Enums;

namespace medicalcenter.project.api.Domain.Dto.Atendimento;

public class AtendimentoDtoResponse : BaseDto
{
    public Guid PacienteId { get; set; }
    public string PacienteNome { get; set; }
    public string NumeroSequencial { get; set; }
    public DateTime DataHoraChegada { get; set; }
    public EStatusAtendimento Status { get; set; }
}