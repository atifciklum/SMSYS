using System.ComponentModel.DataAnnotations;

namespace SMSYS.Dtos
{
    public class TeacherCreateDto
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
}
