using AutoMapper;
using PersonSkillsService.Application.DataTransfer.Commands;
using PersonSkillsService.Application.DataTransfer.Queries;
using PersonSkillsService.Domain.Aggregates.Persons;
using PersonSkillsService.Domain.Presistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonSkillsService.Application.Service
{
    public class PersonService : IPersonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISpecificationFactory _specificationFactory;
        private readonly IMapper _mapper;

        public PersonService(IUnitOfWork unitOfWork, ISpecificationFactory specificationFactory, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _specificationFactory = specificationFactory;
            _mapper = mapper;
        }

        public PersonDto GetPersonById(long personId)
        {
            var person =
                _unitOfWork.PersonRepository
                    .Get(_specificationFactory.GetPersonById(personId))
                    .SingleOrDefault();

            if (person == null)
                return null;

            return CreatePersonDto(person);
        }

        public IEnumerable<PersonDto> GetAllPerson()
        {
            var person = _unitOfWork.PersonRepository.Get(_specificationFactory.GetAllPerson());

            if (person == null)
                return null;
            else
                return person.Select(CreatePersonDto);
        }

        public PersonDto UpdatePerson(long personId, SavePersonDto savePersonDto)
        {
            var sameNamePerson =
                _unitOfWork.PersonRepository
                    .Get(_specificationFactory.GetPersonByName(savePersonDto.Name))
                    .SingleOrDefault();

            var sameNamePersonIsExists = sameNamePerson != null && sameNamePerson.Id != personId;
            if (sameNamePersonIsExists)
                throw new InvalidOperationException("Database already contains a person with the same name");

            var person =
                   _unitOfWork.PersonRepository
                       .Get(_specificationFactory.GetPersonById(personId))
                       .SingleOrDefault();

            if (person == null)
                return null;

            _mapper.Map(savePersonDto, person);

            _unitOfWork.PersonRepository.Update(person);
            _unitOfWork.Commit();

            return CreatePersonDto(person);
        }

        public bool RemovePerson(long personId)
        {
            var person =
                _unitOfWork.PersonRepository
                    .Get(_specificationFactory.GetPersonById(personId))
                    .SingleOrDefault();

            if (person == null)
                return false;

            _unitOfWork.PersonRepository.Remove(person);
            _unitOfWork.Commit();
            return true;
        }

        public PersonDto CreatePerson(SavePersonDto savePersonDto)
        {
            var sameNamePerson =
                _unitOfWork.PersonRepository
                    .Get(_specificationFactory.GetPersonByName(savePersonDto.Name))
                    .SingleOrDefault();

            var sameNamePersonIsExists = sameNamePerson != null;
            if (sameNamePersonIsExists)
                throw new InvalidOperationException("Database already contains a person with the same name");

            var person = _mapper.Map<SavePersonDto, Person>(savePersonDto);

            _unitOfWork.PersonRepository.Create(person);
            _unitOfWork.Commit();

            return CreatePersonDto(person);
        }

        public PersonDto CreatePersonDto(Person person)
        {
            return _mapper.Map<Person, PersonDto>(person);
        }
    }
}