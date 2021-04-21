using AutoMapper;
using PersonSkillsService.Application.DataTransfer.Commands;
using PersonSkillsService.Application.DataTransfer.Queries;
using PersonSkillsService.Domain.Aggregates.Persons;
using PersonSkillsService.Domain.Aggregates.Skills;

namespace PersonSkillsService.Application
{
    /// <summary>
    /// Класс, позволяющий проецировать одну модель на другую 
    /// </summary>
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // Presentation -> Domain
            CreateMap<SavePersonDto, Person>().ConstructUsing(dto => new Person {Name= dto.Name, DisplayName= dto.Name });
            CreateMap<SaveSkillDto, Skill>().ConstructUsing(dto => new Skill { Name = dto.Name, Level = dto.Level });


            // Domain -> Presentation
            CreateMap<Person, PersonDto>();
            CreateMap<Skill, SkillDto>();
        }
    }
}