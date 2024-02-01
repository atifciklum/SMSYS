using AutoMapper;
using SMSYS.Dtos;
using SMSYS.Models;

namespace SMSYS.Profiles
{
    public class ExamsProfile : Profile
    {
        public ExamsProfile()
        {
            CreateMap<Exam, ExamReadDtos>();
            CreateMap<ExamCreateDto, Exam>();
            CreateMap<ExamUpdateDto, Exam>();
            CreateMap<Exam, ExamUpdateDto>();

        }
    }
}
