using PersonSkillsService.Domain.Aggregates.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSkillsService.Infrastructure.Presistence.Specifications
{
    public class GetAllPerson: BaseSpecification<Person>
    {
        public GetAllPerson()
            : base(p => true)
        {
            AddInclude(p => p.Skills);
        }
    }
}
