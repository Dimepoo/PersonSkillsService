using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PersonSkillsService.Domain.Aggregates.Persons;
using PersonSkillsService.Domain.Aggregates.Skills;
using PersonSkillsService.Infrastructure.Presistence.Configurations;

namespace PersonSkillsService.Infrastructure.Presistence
{
    /// <summary>
    /// Класс, определяющий контекст данных,
    /// используемый для взаимодействия с БД
    /// </summary>
    public class PersonSkillsContext: DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Person> Persons { get; set; }

        public PersonSkillsContext(IConfiguration configuration) : base()
        {
            _configuration = configuration;

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().HasData(
                new Person[]
                {
                    new Person{Id = 1, Name = "Виталий", DisplayName="Виталий"},
                    new Person{Id = 2, Name="Евгений", DisplayName="Евгений" },
                    new Person{Id = 3, Name="Екатерина", DisplayName="Екатерина"}

                });

            modelBuilder.Entity<Skill>().HasData(
                new Skill[]
                {
                    new Skill{Id = 1, Name= "Сила", PersonId = 1, Level = 10 },
                    new Skill{Id = 2, Name="Ум", PersonId = 2, Level = 15},
                    new Skill{ Id = 3, Name = "Хитрость", PersonId = 3, Level = 10 },
                    new Skill{Id = 4, Name="Ловкость", PersonId = 1, Level = 12 },
                });


            modelBuilder.Entity<Skill>()
                .HasOne(p => p.Person)
                .WithMany(t => t.Skills)
                .HasForeignKey(p => p.PersonId);

            modelBuilder.ApplyConfiguration(new PersonConfiguration());

            modelBuilder.Entity<Person>()
                .HasIndex(p => p.Name)
                .IsUnique();

            modelBuilder.Entity<Skill>()
                .HasOne(skill => skill.Person)
                .WithMany(person => person.Skills)
                .OnDelete(DeleteBehavior.Cascade);



        }
    }
}
