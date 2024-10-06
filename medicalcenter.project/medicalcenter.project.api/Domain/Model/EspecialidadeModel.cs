namespace medicalcenter.project.api.Domain.Model
{
    public class EspecialidadeModel
    {
        private Guid id;
        private string nome;
        private string descricao;

        public Guid Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Descricao { get => descricao; set => descricao = value; }
    }
}