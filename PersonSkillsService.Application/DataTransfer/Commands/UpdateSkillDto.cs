using System.ComponentModel.DataAnnotations;


namespace PersonSkillsService.Application.DataTransfer.Commands
{
    /// <summary>
    /// Data Transfer Object - специальная моделей для передачи данных
    /// В данном случае - для действия обновления навыков
    /// </summary>
    public class UpdateSkillDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public byte Level { get; set; }
    }
}
