using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMSYS.Models
{
    public class Exam
    {
        [Key]
        [Required]
        public int Exam_ID { get; set; }

        [ForeignKey("Subject")]
        [Required]
        public int Subject_ID { get; set; }
        public Subject Subject { get; set; }

        [ForeignKey("Classroom")]
        [Required]
        public int Classroom_ID { get; set; }
        public Classroom Classroom { get; set; }


        [Required]
        public string Date { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Type { get; set; }
    }
}
