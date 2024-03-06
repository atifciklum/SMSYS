using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMSYS.Models
{
    public class Exam
    {
        [Key]
        [Required]
        public int Exam_ID { get; set; }

        [Required]
        public string Date { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Type { get; set; }
    }
}
