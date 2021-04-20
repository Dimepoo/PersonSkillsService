using Microsoft.Extensions.DependencyInjection;
using PersonSkillsService.Application.Service;
using PersonSkillsService.Infrastructure;

namespace PersonSkillsService.Application
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Метод расширения коллекции сервисов. Добавляет возможность
        /// внедрять зависимость IPersonService, PersonService в объекты 
        /// через встроенный DI-контейнер
        /// </summary>
        /// <param name="services"></param>
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddInfrastructureServices();

            services.AddScoped<IPersonService, PersonService>();
        }
    }
}
