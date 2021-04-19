using PersonSkillsService.Domain.Aggregates.Persons;
using PersonSkillsService.Domain.Aggregates.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSkillsService.Domain.Presistence
{
    public interface IUnitOfWork
    {
        IRepository<Person> PersonRepository { get; }
        IRepository<Skill> SkillReposutory { get; }

        int Commit();
    }
}
