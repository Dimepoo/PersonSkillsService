using PersonSkillsService.Application.DataTransfer.Queries;
using PersonSkillsService.Domain.Aggregates.Skills;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSkillsService.Application.DataTransfer.Commands
{
    public class SavePersonDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public List<SaveSkillDto> Skills { get; set; }
    }
}
