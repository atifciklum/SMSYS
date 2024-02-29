using System.ComponentModel.DataAnnotations;

namespace SMSYS.Dtos
{
    public class ExamCreateDto
    {

        [Required]
        public string Date { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Type { get; set; }
    }

    public class ExamReadDtos
    {
        [Required]
        public int Exam_ID { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Type { get; set; }
    }

    public class ExamUpdateDto
    {
        [Required]
        public string Date { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Type { get; set; }
    }





}
