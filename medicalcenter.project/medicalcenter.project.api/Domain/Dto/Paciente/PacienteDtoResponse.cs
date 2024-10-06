namespace medicalcenter.project.api.Domain.Dto.Paciente
{
    public class PacienteDtoResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
    }
}