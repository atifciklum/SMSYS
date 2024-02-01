using SMSYS.Models;
namespace SMSYS.Data
{
    public interface IStudentRepo
    {
        bool SaveChanges();
        IEnumerable<Student> GetStudents();
        Student GetStudentById(int id);
        void CreateStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(Student student);
    }
}
