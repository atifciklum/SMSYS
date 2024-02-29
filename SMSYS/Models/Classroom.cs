using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMSYS.Models
{
    public class Classroom
    {
        [Key]
        public int Classroom_ID { get; set; }

        [Required]
        public int Student_ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Section { get; set; }
    }
}
