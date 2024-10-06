namespace medicalcenter.project.api.Domain.Model
{
    public class PacienteModel
    {
        private Guid id;
        private string nome;
        private string telefone;
        private string sexo;
        private string email;

        public Guid Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public string Email { get => email; set => email = value; }
    }
}