using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace PersonSkillsService.Application.DataTransfer.Queries
{
    public class PersonDto
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public List<SkillDto> Skills { get; set; }
    }
}
