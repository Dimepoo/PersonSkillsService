using PersonSkillsService.Domain.Aggregates.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSkillsService.Infrastructure.Presistence.Specifications
{
    public class GetPersonByName: BaseSpecification<Person>
    {
        public GetPersonByName(string name):
            base(p => p.Name == name)
        {

        }
    }
}
