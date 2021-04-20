﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


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
