using FluentValidation;
using PersonSkillsService.Domain.Aggregates.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSkillsService.Domain.Aggregates.Skills
{
    public class Skill
    {
        public long Id { get; set; }
        public long PersonId { get; set; }

        public Person Person { get; set; }

        public string Name { get; private set; }

        public byte Level { get; set; }

        public Skill(string name, byte level)
        {
            UpdateName(name);
            UpdateLevel(level);
        }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void UpdatePerson(Person person)
        {
            PersonId = person.Id;
            Person = person;
        }

        public void UpdateLevel(byte level)
        {
            Level = level;
        }
    }
}
