using SMSYS.Models;

namespace SMSYS.Data
{
    public class SqlSubjectRepo : ISubjectRepo
    {
        private readonly StudentContext _context;

        public SqlSubjectRepo(StudentContext context)
        {

            _context = context;

        }

        public IEnumerable<Subject> GetSubjects()
        {
            return _context.Subject.ToList();
        }
        public Subject GetSubjectById(int id)
        {
            return _context.Subject.FirstOrDefault(p => p.Subject_ID == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);

        }

        public void CreateSubject(Subject subject)
        {
            if (subject == null)
            {
                throw new ArgumentNullException(nameof(subject));
            }
            _context.Subject.Add(subject);

        }
        public void UpdateSubject(Subject subject)
        {

        }

        public void DeleteSubject(Subject subject)
        {
            if (subject == null)
            {
                throw new ArgumentNullException(nameof(subject));
            }
            _context.Subject.Remove(subject);
            _context.SaveChanges();


        }
    }
}
