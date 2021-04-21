using System.ComponentModel.DataAnnotations;


namespace PersonSkillsService.Application.DataTransfer.Queries
{
    /// <summary>
    /// Data Transfer Object - специальная модель для передачи данных
    /// В данном случае - для считывания данных о навыках
    /// </summary>
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
