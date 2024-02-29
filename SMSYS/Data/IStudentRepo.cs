using SMSYS.Dtos;
using SMSYS.Models;
namespace SMSYS.Data
{
    public interface IStudentRepo
    {
        bool SaveChanges();
        IEnumerable<Student> GetStudents();
        Student GetStudentById(int id);
        void CreateStudent(Student student);

        IEnumerable<StudentResultDto> GetStudentResults();
        void UpdateStudent(Student student);
        void DeleteStudent(Student student);
    }
}
