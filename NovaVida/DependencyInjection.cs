using NovaVidaInfra.Interfaces;
using NovaVidaInfra.Repositories;
using NovaVidaRepository.Seeds;
using NovaVidaServices.Interfaces;
using NovaVidaServices.Services;

namespace NovaVida
{
    public class DependencyInjection
    {
        public static void Register(IServiceCollection services)
        {
            RepositoryDependence(services);
            services.AddScoped<SeedsRunner>();
        }

        private static void RepositoryDependence(IServiceCollection services)
        {
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<IProfessorService, ProfessorService>();
        }
    }
}