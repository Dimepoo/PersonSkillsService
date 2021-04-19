using PersonSkillsService.Domain.Aggregates.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSkillsService.Domain.Aggregates.Persons
{
    public class Person
    {
        public long Id { get; set; }

        public string Name { get; private set; }

        public string DisplayName { get; private set; }

        public ICollection<Skill> Skills { get; set; }

        public Person(string name)
        {
            UpdateName(name);
        }

        public void UpdateName(string name)
        {
            Name = name;
            DisplayName = name;
        }

        public void UpdateSkills(ICollection<Skill> skills)
        {
            Skills = skills;
        }
    }
}
