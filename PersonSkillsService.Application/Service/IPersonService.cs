using PersonSkillsService.Application.DataTransfer.Commands;
using PersonSkillsService.Application.DataTransfer.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSkillsService.Application.Service
{
    public interface IPersonService
    {
        PersonDto GetPersonById(long personId);
        IEnumerable<PersonDto> GetAllPerson();
        public PersonDto UpdatePerson(long personId, SavePersonDto savePersonDto);
        public bool RemovePerson(long personId);
        public PersonDto CreatePerson(SavePersonDto savePersonDto);
    }
}
