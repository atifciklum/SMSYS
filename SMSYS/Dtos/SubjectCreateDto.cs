using System.ComponentModel.DataAnnotations;

namespace SMSYS.Dtos
{
    public class SubjectCreateDto
    {
        public string Name { get; set; }
        [Required]
        public int Grade { get; set; }
        [Required]
        public string Description { get; set; }
      
    }
}
