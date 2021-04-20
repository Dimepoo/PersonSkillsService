
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace PersonSkillsService.Application.DataTransfer.Commands
{
    /// <summary>
    /// Data Transfer Object - специальная моделей для передачи данных
    /// В данном случае - для действия обновления личности
    /// </summary>
    public class UpdatePersonDto
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public List<UpdateSkillDto> Skills { get; set; }
    }
}
