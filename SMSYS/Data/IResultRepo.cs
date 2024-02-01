using SMSYS.Models;

namespace SMSYS.Data
{
    public interface IResultRepo
    {
        bool SaveChanges();
        IEnumerable<Result> GetResults();
        Result GetResultById(int id);
        void CreateResult(Result result);
        void UpdateResult(Result result);
        void DeleteResult(Result result);
    }
}
