using SMSYS.Models;

namespace SMSYS.Data
{
    public class SqlResultRepo : IResultRepo
    {
        private readonly StudentContext _context;

        public SqlResultRepo(StudentContext context)
        {

            _context = context;

        }

        public IEnumerable<Result> GetResults()
        {
            return _context.Result.ToList();
        }
        public Result GetResultById(int id)
        {
            return _context.Result.FirstOrDefault(p => p.Result_ID == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);

        }

        public void CreateResult(Result result)
        {
            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }
            _context.Result.Add(result);

        }
        public void UpdateResult(Result result)
        {

        }

        public void DeleteResult(Result result)
        {
            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }
            _context.Result.Remove(result);
            _context.SaveChanges();


        }
    }
}
