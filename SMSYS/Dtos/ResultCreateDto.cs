using System.ComponentModel.DataAnnotations;

namespace SMSYS.Dtos
{
    public class ResultCreateDto
    {
        [Required]
        public int Student_ID { get; set; }
        [Required]
        public int Subject_ID { get; set; }
        [Required]
        public int Exam_ID { get; set; }
        [Required]
        public int Marks { get; set; }
    }
}
