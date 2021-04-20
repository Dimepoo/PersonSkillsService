using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace PersonSkillsService.Application.DataTransfer.Commands
{
    /// <summary>
    /// Data Transfer Object - специальная моделей для передачи данных
    /// В данном случае - для действия создания личности
    /// </summary>
    public class SavePersonDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public List<SaveSkillDto> Skills { get; set; }
    }
}
