using medicalcenter.project.api.Domain.Dto.Triagem;
using medicalcenter.project.api.Domain.Interfaces.Services.Base;

namespace medicalcenter.project.api.Domain.Interfaces.Services
{
    public interface ITriagemService : IBaseService<TriagemDtoResponse, TriagemDtoRequest>
    {
        Task<TriagemDtoResponse> GetByIdAsync( Guid id );
    }
}