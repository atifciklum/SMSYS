using SMSYS.Models;

namespace SMSYS.Data
{
    public class SqlTeacherRepo : ITeacherRepo
    {
        private readonly StudentContext _context;

        public SqlTeacherRepo(StudentContext context)
        {

            _context = context;

        }

        public IEnumerable<Teacher> GetTeachers()
        {
            return _context.Teacher.ToList();
        }
        public Teacher GetTeacherById(int id)
        {
            return _context.Teacher.FirstOrDefault(p => p.Teacher_ID == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);

        }

        public void CreateTeacher(Teacher teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException(nameof(teacher));
            }
            _context.Teacher.Add(teacher);

        }
        public void UpdateTeacher(Teacher teacher)
        {

        }

        public void DeleteTeacher(Teacher teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException(nameof(teacher));
            }
            _context.Teacher.Remove(teacher);
            _context.SaveChanges();


        }
    }
}
