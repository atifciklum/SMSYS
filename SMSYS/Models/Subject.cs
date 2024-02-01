using System.ComponentModel.DataAnnotations;

namespace SMSYS.Models
{
    public class Subject
    {
        [Key]
        [Required]
        public int Subject_ID { get; set; }

        public string Name { get; set; }
        [Required]
        public int Grade { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
