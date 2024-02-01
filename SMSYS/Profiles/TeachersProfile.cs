using AutoMapper;
using SMSYS.Dtos;
using SMSYS.Models;

namespace SMSYS.Profiles
{
    public class TeachersProfile : Profile
    {
        public TeachersProfile()
        {
            CreateMap<Teacher, StudentReadDtos>();
            CreateMap<TeacherCreateDto, Teacher>();
            CreateMap<TeacherUpdateDto, Teacher>();
            CreateMap<Teacher, TeacherUpdateDto>();

        }
    }
}
