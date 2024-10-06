using medicalcenter.project.api.Data.Repositories;
using medicalcenter.project.api.Data.Repositories.Base;
using medicalcenter.project.api.Domain.Interfaces.Repositories;
using medicalcenter.project.api.Domain.Interfaces.Repositories.Base;

namespace medicalcenter.project.api.CrossCutting.DependencyInjection
{
    public static class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository( this IServiceCollection services )
        {
            services.AddScoped( typeof( IBaseRepository<> ), typeof( BaseRepository<> ) );
            services.AddScoped<IPacienteRepository, PacienteRepository>( );
            services.AddScoped<IEspecialidadeRepository, EspecialidadeRepository>( );
            services.AddScoped<IAtendimentoRepository, AtendimentoRepository>( );
            services.AddScoped<ITriagemRepository, TriagemRepository>( );
        }
    }
}