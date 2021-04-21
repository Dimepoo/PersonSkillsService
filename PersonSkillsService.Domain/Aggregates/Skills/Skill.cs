using PersonSkillsService.Domain.Aggregates.Persons;

namespace PersonSkillsService.Domain.Aggregates.Skills
{
    /// <summary>
    /// Модель сущности "Навыки"
    /// </summary>
    public class Skill
    {
        public long Id { get; set; }
        public long PersonId { get; set; }

        public Person Person { get; set; }

        public string Name { get; set; }

        public byte Level { get; set; }

    }
}
