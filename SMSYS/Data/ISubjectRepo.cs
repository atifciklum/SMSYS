using SMSYS.Models;

namespace SMSYS.Data
{
  
  public interface ISubjectRepo
   {
            bool SaveChanges();
            IEnumerable<Subject> GetSubjects();
            Subject GetSubjectById(int id);
            void CreateSubject(Subject subject);
            void UpdateSubject(Subject subject);
            void DeleteSubject(Subject subject);
    }
}
