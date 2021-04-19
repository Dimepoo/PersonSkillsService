using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSkillsService.Application.DataTransfer.Commands
{
    public class SaveSkillDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public byte Level { get; set; }
    }
}
