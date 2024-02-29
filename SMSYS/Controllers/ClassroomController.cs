using Microsoft.AspNetCore.Mvc;
using SMSYS.Models;
using SMSYS.Data;
using AutoMapper;
using SMSYS.Dtos;
using System.Collections.Generic;
using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;

namespace SMSYS.Controllers
{

    [Route("api/classroom")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private readonly IClassroomRepo _repository;
        private readonly IMapper _mapper;

        public ClassroomController(IClassroomRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet("getStudentResultsByClassroomId/{id}")]

        public ActionResult<IEnumerable<ClassroomResultDto>> getStudentResultsByClassroomId(int id)
        {
            Console.WriteLine(id);
            var classroomResult = _repository.getStudentResultsByClassroomId(id);

            return classroomResult.ToList();

        }


    }
}