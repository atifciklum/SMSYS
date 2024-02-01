using AutoMapper;
using SMSYS.Dtos;
using SMSYS.Models;

namespace SMSYS.Profiles
{
    public class SubjectsProfile : Profile
    {
        public SubjectsProfile()
        {
            CreateMap<Subject, SubjectReadDto>();
            CreateMap<SubjectCreateDto, Subject>();
            CreateMap<SubjectUpdateDto, Subject>();
            CreateMap<Subject, SubjectUpdateDto>();

        }
    }
}
