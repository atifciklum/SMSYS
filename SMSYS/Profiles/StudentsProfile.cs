using AutoMapper;
using SMSYS.Dtos;
using SMSYS.Models;

namespace SMSYS.Profiles
{
    public class StudentsProfile : Profile
    {
        public StudentsProfile()
        {
            CreateMap<Student, StudentReadDtos>();
            CreateMap<StudentCreateDto, Student>();
            CreateMap<StudentUpdateDto , Student>();
            CreateMap<Student, StudentUpdateDto>();

        }
    }
}
