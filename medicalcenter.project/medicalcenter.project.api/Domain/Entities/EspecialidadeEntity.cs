using medicalcenter.project.api.Domain.Entities.Base;

namespace medicalcenter.project.api.Domain.Entities
{
    public class EspecialidadeEntity : BaseEntity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}