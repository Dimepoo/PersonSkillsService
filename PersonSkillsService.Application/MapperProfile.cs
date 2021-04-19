using AutoMapper;
using PersonSkillsService.Application.DataTransfer.Commands;
using PersonSkillsService.Application.DataTransfer.Queries;
using PersonSkillsService.Domain.Aggregates.Persons;
using PersonSkillsService.Domain.Aggregates.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSkillsService.Application
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // Presentation -> Domain
            CreateMap<SavePersonDto, Person>().ConstructUsing(dto => new Person(dto.Name));
            CreateMap<SaveSkillDto, Skill>().ConstructUsing(dto => new Skill(dto.Name, dto.Level));

            // Domain -> Presentation
            CreateMap<Person, PersonDto>();
            CreateMap<Skill, SkillDto>();
        }
    }
}