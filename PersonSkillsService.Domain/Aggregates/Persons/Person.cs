using PersonSkillsService.Domain.Aggregates.Skills;
using System.Collections.Generic;


namespace PersonSkillsService.Domain.Aggregates.Persons
{
    /// <summary>
    /// Модель сущности "Личность"
    /// </summary>
    public class Person
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public ICollection<Skill> Skills { get; set; }

    }
}
