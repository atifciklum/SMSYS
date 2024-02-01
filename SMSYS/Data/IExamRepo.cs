using SMSYS.Models;
namespace SMSYS.Data
{
    public interface IExamRepo
    {
        bool SaveChanges();
        IEnumerable<Exam> GetExams();
        Exam GetExamById(int id);
        void CreateExam(Exam exam);
        void UpdateExam(Exam exam);
        void DeleteExam(Exam exam);
    }
}
