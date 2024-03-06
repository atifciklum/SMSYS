using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMSYS.Models
{
    public class Result
    {
        [Key]
        [Required]
        public int Result_ID { get; set; }


        [ForeignKey("Exam")]
        [Required]
        public int Exam_ID { get; set; }
        public Exam Exam { get; set; }

        [ForeignKey("Student")]
        [Required]
        public int Student_ID { get; set; }
        public Student Student { get; set; }

        [ForeignKey("Subject")]
        [Required]
        public int Subject_ID { get; set; }
        public Subject Subject { get; set; }

 
        [Required]
        public int Obtain_marks { get; set; }

        [Required]
        public int Total_marks { get; set; } 


    }
}
