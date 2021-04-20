using Microsoft.Extensions.DependencyInjection;
using PersonSkillsService.Infrastructure.Presistence;

namespace PersonSkillsService.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Метод расширения коллекции сервисов. Добавляет возможность
        /// внедрять зависимость PersonSkillContext в объекты через встроенный
        /// DI-контейнер
        /// </summary>
        /// <param name="services"></param>
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<PersonSkillsContext>(ServiceLifetime.Scoped);
        }
    }
}
