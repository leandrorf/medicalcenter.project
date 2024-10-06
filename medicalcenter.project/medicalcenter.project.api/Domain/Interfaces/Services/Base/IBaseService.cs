namespace medicalcenter.project.api.Domain.Interfaces.Services.Base
{
    public interface IBaseService<TRespose, TRequest>
    {
        Task<IEnumerable<TRespose>> GetAsync( );

        Task<TRespose> PostAsync( TRequest dto );

        Task<TRespose> PutAsync( Guid id, TRequest dto );

        Task<bool> DeleteAsync( Guid id );
    }
}