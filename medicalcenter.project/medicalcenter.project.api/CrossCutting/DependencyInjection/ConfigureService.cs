using FluentValidation;
using medicalcenter.project.api.Domain.Interfaces.Services;
using medicalcenter.project.api.Services;

namespace medicalcenter.project.api.CrossCutting.DependencyInjection
{
    public static class ConfigureService
    {
        public static void ConfigureDependenciesService( this IServiceCollection services )
        {
            services.AddAutoMapper( AppDomain.CurrentDomain.GetAssemblies( ) );

            services.AddValidatorsFromAssemblies( AppDomain.CurrentDomain.GetAssemblies( ) );

            services.AddTransient<IPacienteService, PacienteService>( );
            services.AddTransient<IAtendimentoService, AtendimentoService>( );
            services.AddTransient<IEspecialidadeService, EspecialidadeService>( );
            services.AddTransient<ITriagemService, TriagemService>( );
        }
    }
}