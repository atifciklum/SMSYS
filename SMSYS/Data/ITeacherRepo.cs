using SMSYS.Models;

namespace SMSYS.Data
{
    public interface ITeacherRepo
    {
        bool SaveChanges();
        IEnumerable<Teacher> GetTeachers();
        Teacher GetTeacherById(int id);
        void CreateTeacher(Teacher teacher);
        void UpdateTeacher(Teacher teacher);
        void DeleteTeacher(Teacher teacher);
    }
}
