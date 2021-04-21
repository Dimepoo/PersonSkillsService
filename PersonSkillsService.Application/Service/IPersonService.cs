using PersonSkillsService.Application.DataTransfer.Commands;
using PersonSkillsService.Application.DataTransfer.Queries;
using System.Collections.Generic;


namespace PersonSkillsService.Application.Service
{
    /// <summary>
    /// Интерфейс сервиса для обработки запросов
    /// с учетом  Data Transfer Object - специальных моделей для передачи данных
    /// </summary>
    public interface IPersonService
    {
        PersonDto GetPersonById(long personId);
        IEnumerable<PersonDto> GetAllPerson();
        public PersonDto UpdatePerson(SavePersonDto savePersonDto);
        public bool RemovePerson(long personId);
        public PersonDto CreatePerson(SavePersonDto updatePersonDto);
    }
}
