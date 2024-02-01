using SMSYS.Models;

namespace SMSYS.Data
{
    public class SqlExamRepo : IExamRepo
    {
        private readonly StudentContext _context;

        public SqlExamRepo(StudentContext context)
        {

            _context = context;

        }

        public IEnumerable<Exam> GetExams()
        {
            return _context.Exam.ToList();
        }
        public Exam GetExamById(int id)
        {
            return _context.Exam.FirstOrDefault(p => p.Exam_ID == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);

        }

        public void CreateExam(Exam exam)
        {
            if (exam == null)
            {
                throw new ArgumentNullException(nameof(exam));
            }
            _context.Exam.Add(exam);

        }
        public void UpdateExam(Exam exam)
        {

        }

        public void DeleteExam(Exam exam)
        {
            if (exam == null)
            {
                throw new ArgumentNullException(nameof(exam));
            }
            _context.Exam.Remove(exam);
            _context.SaveChanges();


        }
    }
}
