using AutoMapper;
using PersonSkillsService.Application.DataTransfer.Commands;
using PersonSkillsService.Application.DataTransfer.Queries;
using PersonSkillsService.Domain.Aggregates.Persons;
using PersonSkillsService.Domain.Presistence;
using PersonSkillsService.Infrastructure.Presistence;
using PersonSkillsService.Infrastructure.Presistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonSkillsService.Application.Service
{
    public class PersonService : IPersonService
    {
        private readonly IMapper _mapper;
        IRepository<Person> _repository;

        public PersonService(IMapper mapper, PersonSkillsContext context)
        {
            _repository = new SQLPersonRepository(context);
            _mapper = mapper;
        }


        public PersonDto GetPersonById(long personId)
        {
            var person = _repository.GetById(personId);

            if (person == null)
                return null;

            return CreatePersonDto(person);
        }

        public IEnumerable<PersonDto> GetAllPerson()
        {
            var person = _repository.GetAll();

            if (person == null)
                return null;
            else
                return person.Select(CreatePersonDto);
        }

        public PersonDto UpdatePerson(UpdatePersonDto updatePersonDto)
        {
            var sameNamePerson = _repository.GetByName(updatePersonDto.Name);

            var sameNamePersonIsExists = sameNamePerson != null && sameNamePerson.Id != updatePersonDto.Id;
            if (sameNamePersonIsExists)
                throw new InvalidOperationException("Database already contains a person with the same name");

            var person = _repository.GetById(updatePersonDto.Id);

            if (person == null)
                return null;

            _mapper.Map(updatePersonDto, person);

            _repository.Update(person);
            _repository.Save();

            return CreatePersonDto(person);
        }

        public bool RemovePerson(long personId)
        {
            var person = _repository.GetById(personId);

            if (person == null)
                return false;

            _repository.Remove(person);
            _repository.Save();
            return true;
        }

        public PersonDto CreatePerson(SavePersonDto savePersonDto)
        {
            var sameNamePerson = _repository.GetByName(savePersonDto.Name);

            var sameNamePersonIsExists = sameNamePerson != null;
            if (sameNamePersonIsExists)
                throw new InvalidOperationException("Database already contains a person with the same name");

            var person = _mapper.Map<SavePersonDto, Person>(savePersonDto);

            _repository.Create(person);
            _repository.Save();

            return CreatePersonDto(person);
        }

        public PersonDto CreatePersonDto(Person person)
        {
            return _mapper.Map<Person, PersonDto>(person);
        }
    }
}