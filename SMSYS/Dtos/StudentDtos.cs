using System.ComponentModel.DataAnnotations;

namespace SMSYS.Dtos
{
    public class StudentCreateDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string DOB { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        public string Date_of_join { get; set; }
        [Required]
        public string Parent_Name { get; set; }
    }

    public class StudentReadDtos
    {
        public int Student_ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string DOB { get; set; }

        public string Address { get; set; }

        //public int Phone { get; set; }    

    }
    public class StudentUpdateDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string DOB { get; set; }

        [Required]
        public string Address { get; set; }
        [Required]
        public int Phone { get; set; }

    }

    public class StudentResultDto
    {
     
        public int Result_ID { get; set; }
       public ExamReadDtos ExamDetail { get; set; }

       public string Percentage { get; set; }

        public int Obtain_marks { get; set; }

        public int Total_marks { get; set; }
    }
}
