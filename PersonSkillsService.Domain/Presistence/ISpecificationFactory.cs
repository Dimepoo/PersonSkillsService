using PersonSkillsService.Domain.Aggregates.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSkillsService.Domain.Presistence
{
    public interface ISpecificationFactory
    {
        ISpecification<Person> GetPersonById(long pesronId);
        ISpecification<Person> GetAllPerson();
        ISpecification<Person> GetPersonByName(string name);
    }
}
