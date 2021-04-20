
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace PersonSkillsService.Application.DataTransfer.Commands
{
    public class UpdatePersonDto
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public List<UpdateSkillDto> Skills { get; set; }
    }
}
