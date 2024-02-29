using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMSYS.Models
{
    public class Classroom_Student
    {

        [Key]
        public int Classroom_Student_ID { get; set; }

        [ForeignKey("Classroom")]
        [Required]
        public int Classroom_ID { get; set; }

        public  Classroom Classroom { get; set; }

        [ForeignKey("Subject")]
        [Required]
        public int Subject_ID { get; set; }
        public Subject Subject { get; set; }
    }
}
