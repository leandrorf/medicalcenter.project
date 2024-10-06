using medicalcenter.project.api.Domain.Dto.Base;

namespace medicalcenter.project.api.Domain.Dto.Especialidade;

public class EspecialidadeDtoResponse : BaseDto
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
}