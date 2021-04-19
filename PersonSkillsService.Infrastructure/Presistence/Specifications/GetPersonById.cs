using PersonSkillsService.Domain.Aggregates.Persons;
using PersonSkillsService.Domain.Aggregates.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSkillsService.Infrastructure.Presistence.Specifications
{
    public class GetPersonById: BaseSpecification<Person>
    {
        public GetPersonById(long personId)
            :base (p => p.Id == personId)
        {

            AddInclude(p => p.Skills);
        }
    }
}
