using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMSYS.Dtos
{
    public class ClassroomCreateDto
    {
        public int Classroom_ID { get; set; }

        public string Section { get; set; }

        public int Grade { get; set; }

        public int Teacher_ID { get; set; }
    }

    public class ClassroomReadDtos
    {
        public int Classroom_ID { get; set; }

        public string Section { get; set; }

        public int Grade { get; set; }

        public int Teacher_ID { get; set; }

    }
    public class ClassroomUpdateDto
    {
        public int Classroom_ID { get; set; }

        public string Section { get; set; }

        public int Grade { get; set; }

        public int Teacher_ID { get; set; }

    }

    public class ClassroomResultDtos
    {

        public int Classroom_ID { get; set; }

        public string Grade { get; set; }

        public int Student_ID { get; set; }

        public string Exam_name { get; set; }

        public string Percentage { get; set; }

        public int Obtain_marks { get; set; }

        public int Total_marks { get; set; }
    }

    public class ClassroomResultDto
    {
        public int Classroom_ID { get; set; }
        public string Classroom_Name { get; set; }
        public List<ClassStudentsDtos> StudentDetails { get; set; }
    }

    public class ClassStudentsDtos
    {
        public int Student_ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string DOB { get; set; }

        public string Address { get; set; }

        public List<StudentResultDto> studentResult { get; set; }

    }
}
