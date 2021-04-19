using Microsoft.Extensions.DependencyInjection;
using PersonSkillsService.Application.Service;
using PersonSkillsService.Infrastructure;

namespace PersonSkillsService.Application
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddInfrastructureServices();

            services.AddScoped<IPersonService, PersonService>();
        }
    }
}
