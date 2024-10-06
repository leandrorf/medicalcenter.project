using medicalcenter.project.api.Domain.Enums;

namespace medicalcenter.project.api.Domain.Model;

public class AtendimentoModel
{
    private Guid id;
    private Guid pacienteId;
    private int numeroSequencial;
    private DateTime dataHoraChegada;
    private EStatusAtendimento status;

    public Guid Id { get => id; set => id = value; }
    public Guid PacienteId { get => pacienteId; set => pacienteId = value; }
    public int NumeroSequencial { get => numeroSequencial; set => numeroSequencial = value; }

    public DateTime DataHoraChegada
    {
        get
        {
            if ( dataHoraChegada == DateTime.MinValue )
            {
                dataHoraChegada = DateTime.Now;
            }

            return dataHoraChegada;
        }

        set
        {
            dataHoraChegada = value;
        }
    }

    public EStatusAtendimento Status
    {
        get
        {
            if ( status == EStatusAtendimento.None )
            {
                status = EStatusAtendimento.AguardandoTriagem;
            }

            return status;
        }

        set => status = value;
    }
}