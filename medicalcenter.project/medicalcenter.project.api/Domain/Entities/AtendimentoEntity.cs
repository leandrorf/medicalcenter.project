using medicalcenter.project.api.Domain.Entities.Base;
using medicalcenter.project.api.Domain.Enums;

namespace medicalcenter.project.api.Domain.Entities;

public class AtendimentoEntity : BaseEntity
{
    public Guid PacienteId { get; set; }
    public int NumeroSequencial { get; set; }
    public DateTime DataHoraChegada { get; set; }
    public EStatusAtendimento Status { get; set; }
}