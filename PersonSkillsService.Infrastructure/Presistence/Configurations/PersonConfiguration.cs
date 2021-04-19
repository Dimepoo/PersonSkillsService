using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonSkillsService.Domain.Aggregates.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSkillsService.Infrastructure.Presistence.Configurations
{
    /// <summary>
    /// Класс инкапсулирующий настройки для моделей и их свойств. Конкретно этот - для модели Person
    /// </summary>
    class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons");

            //Переопределили первичный ключ
            builder.HasKey(p => p.Id);
            //Делаем свойство обязательным, генерируем значение при добавление строки
            builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd().UseHiLo();

            //Делаем свойства обязательными
            builder.Property(p => p.Name).IsRequired();
        }
    }
}
