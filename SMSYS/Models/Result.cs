using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMSYS.Models
{
    public class Result
    {
        [Key]
        [Required]
        public int Result_ID { get; set; }

        [ForeignKey("Exam_ID")]
        [Required]
        public int Exam_ID { get; set; }

        [ForeignKey("Student_ID")]
        [Required]
        public int Student_ID { get; set; }
       
       
        [Required]
        public int Marks { get; set; } 


    }
}
