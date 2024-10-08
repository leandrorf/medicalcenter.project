using medicalcenter.project.api.Domain.Entities.Base;

namespace medicalcenter.project.api.Domain.Entities
{
    public class PacienteEntity : BaseEntity
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public int Sexo { get; set; }
        public string Email { get; set; }
    }
}