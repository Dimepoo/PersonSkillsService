using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace PersonSkillsService.Application.DataTransfer.Queries
{
    /// <summary>
    /// Data Transfer Object - специальная моделей для передачи данных
    /// В данном случае - для считывания данных о личности
    /// </summary>
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
