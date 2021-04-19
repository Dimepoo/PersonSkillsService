using Microsoft.Extensions.DependencyInjection;
using PersonSkillsService.Domain.Presistence;
using PersonSkillsService.Infrastructure.Presistence;
using PersonSkillsService.Infrastructure.Presistence.Specifications;

namespace PersonSkillsService.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<PersonSkillsContext>(ServiceLifetime.Scoped);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISpecificationFactory, SpecificationFactory>();
        }
    }
}
