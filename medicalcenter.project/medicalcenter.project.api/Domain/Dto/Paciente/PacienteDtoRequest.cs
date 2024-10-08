namespace medicalcenter.project.api.Domain.Dto.Paciente;

public class PacienteDtoRequest
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public int Sexo { get; set; }
    public string Email { get; set; }
}