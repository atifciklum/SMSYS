using SMSYS.Dtos;
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


        public IEnumerable<StudentResultDto> getAllStudentResultsByExamId(int id)
        {

            var studentResultDto = (from exam in _context.Exam
                                    join result in _context.Result on exam.Exam_ID equals result.Exam_ID
                                    join student in _context.Student on result.Student_ID equals student.Student_ID
                                    where result.Exam_ID == id
                                    select new StudentResultDto
                                    { }).ToList();
            return studentResultDto;

        }
    }
}
