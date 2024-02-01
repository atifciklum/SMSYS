using System.ComponentModel.DataAnnotations;

namespace SMSYS.Models
{
    public class Student
    {
        [Key]
        public int Student_ID { get; set; }

        [Required]
        [MaxLength(250)]
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
}