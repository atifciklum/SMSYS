using SMSYS.Dtos;
using SMSYS.Models;
namespace SMSYS.Data
{
    public interface IClassroomRepo
    {
        IEnumerable<ClassroomResultDto> getStudentResultsByClassroomId(int id);
    }
}
