using System.ComponentModel.DataAnnotations;


namespace PersonSkillsService.Application.DataTransfer.Commands
{
    /// <summary>
    /// Data Transfer Object - специальная модель для передачи данных
    /// В данном случае - для действия создания навыков
    /// </summary>
    public class SaveSkillDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public byte Level { get; set; }
    }
}
