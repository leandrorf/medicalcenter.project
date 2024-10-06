using System.ComponentModel.DataAnnotations;

namespace medicalcenter.project.api.Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}