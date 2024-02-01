using Microsoft.EntityFrameworkCore.Internal;
using SMSYS.Models;

namespace SMSYS.Data
{
    public class SqlStudentRepo : IStudentRepo
    {
        private readonly StudentContext _context;

        public SqlStudentRepo(StudentContext context) 
        {

            _context = context;
        
        }

        public IEnumerable<Student> GetStudents()
        {
           return _context.Student.ToList();
        }
        public Student GetStudentById(int id)
        {
            return _context.Student.FirstOrDefault(p => p.Student_ID == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
          
        }

        public void CreateStudent(Student student)
        {
           if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            _context.Student.Add(student);

        }
        public void UpdateStudent(Student student)
        {

        }

        public void DeleteStudent(Student student) 
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            _context.Student.Remove(student);
            _context.SaveChanges();

            


        }
    }
}
