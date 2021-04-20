using Microsoft.Extensions.DependencyInjection;
using PersonSkillsService.Infrastructure.Presistence;

namespace PersonSkillsService.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<PersonSkillsContext>(ServiceLifetime.Scoped);
        }
    }
}
