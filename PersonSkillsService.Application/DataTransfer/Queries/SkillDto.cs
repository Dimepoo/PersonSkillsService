﻿using System.ComponentModel.DataAnnotations;


namespace PersonSkillsService.Application.DataTransfer.Queries
{
    public class SkillDto
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public byte Level { get; set; }


    }
}
