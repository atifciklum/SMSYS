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

    public class SubjectReadDto
    {
        [Required]
        public string Subject_ID { get; set; }

        public string Name { get; set; }
        [Required]
        public int Grade { get; set; }
        [Required]
        public string Description { get; set; }
    }

    public class SubjectUpdateDto
    {
        public string Name { get; set; }
        [Required]
        public int Grade { get; set; }
        [Required]
        public string Description { get; set; }
    }



}
