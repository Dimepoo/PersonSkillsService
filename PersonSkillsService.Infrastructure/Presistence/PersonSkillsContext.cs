using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PersonSkillsService.Domain.Aggregates.Persons;
using PersonSkillsService.Domain.Aggregates.Skills;
using PersonSkillsService.Infrastructure.Presistence.Configurations;
using System.Collections.Generic;

namespace PersonSkillsService.Infrastructure.Presistence
{
    sealed class PersonSkillsContext: DbContext
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
                    new Person("Виталий") {Id = 1},
                    new Person("Евгений") {Id = 2 },
                    new Person("Екатерина") {Id = 3}

                });

            modelBuilder.Entity<Skill>().HasData(
                new Skill[]
                {
                    new Skill("Сила", 10) {Id = 1, PersonId = 1 },
                    new Skill("Ум", 15) {Id = 2, PersonId = 2},
                    new Skill("Хитрость", 10) {Id = 3, PersonId = 3},
                    new Skill("Ловкость", 12) {Id = 4, PersonId = 1 },
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
