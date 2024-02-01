using AutoMapper;
using SMSYS.Dtos;
using SMSYS.Models;

namespace SMSYS.Profiles
{
    public class ResultsProfile : Profile
    {
        public ResultsProfile()
        {
            CreateMap<Result, ResultReadDto>();
            CreateMap<ResultCreateDto, Result>();
            CreateMap<ResultUpdateDto, Result>();
            CreateMap<Result, ResultUpdateDto>();

        }

    }
}
