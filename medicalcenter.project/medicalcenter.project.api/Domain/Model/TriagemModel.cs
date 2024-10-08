namespace medicalcenter.project.api.Domain.Model
{
    public class TriagemModel
    {
        private Guid id;
        private Guid atendimentoId;
        private Guid especialidadeId;
        private string sintomas;
        private string pressaoArterial;
        private double peso;
        private double altura;

        public Guid Id
        {
            get
            {
                if ( id == Guid.Empty )
                {
                    id = Guid.NewGuid( );
                }

                return id;
            }

            set => id = value;
        }

        public Guid AtendimentoId { get => atendimentoId; set => atendimentoId = value; }
        public Guid EspecialidadeId { get => especialidadeId; set => especialidadeId = value; }
        public string Sintomas { get => sintomas; set => sintomas = value; }
        public string PressaoArterial { get => pressaoArterial; set => pressaoArterial = value; }
        public double Peso { get => peso; set => peso = value; }
        public double Altura { get => altura; set => altura = value; }
    }
}