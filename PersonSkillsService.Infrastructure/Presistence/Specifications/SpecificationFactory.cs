using PersonSkillsService.Domain.Aggregates.Persons;
using PersonSkillsService.Domain.Presistence;

namespace PersonSkillsService.Infrastructure.Presistence.Specifications
{
    internal class SpecificationFactory : ISpecificationFactory
    {
        public ISpecification<Person> GetPersonById(long personId) => new GetPersonById(personId);
        public ISpecification<Person> GetAllPerson() => new GetAllPerson();

        public ISpecification<Person> GetPersonByName(string name) => new GetPersonByName(name);
    }
}