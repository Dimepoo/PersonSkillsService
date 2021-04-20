using PersonSkillsService.Application.DataTransfer.Commands;
using PersonSkillsService.Application.DataTransfer.Queries;
using System.Collections.Generic;


namespace PersonSkillsService.Application.Service
{
    public interface IPersonService
    {
        PersonDto GetPersonById(long personId);
        IEnumerable<PersonDto> GetAllPerson();
        public PersonDto UpdatePerson(UpdatePersonDto savePersonDto);
        public bool RemovePerson(long personId);
        public PersonDto CreatePerson(SavePersonDto updatePersonDto);
    }
}
