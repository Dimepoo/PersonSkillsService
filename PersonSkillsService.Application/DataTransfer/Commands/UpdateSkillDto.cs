using System.ComponentModel.DataAnnotations;


namespace PersonSkillsService.Application.DataTransfer.Commands
{
    public class UpdateSkillDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public byte Level { get; set; }
    }
}
