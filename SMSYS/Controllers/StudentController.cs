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

    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepo _repository;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            var studentItems = _repository.GetStudents();

            return Ok(_mapper.Map<IEnumerable<StudentReadDtos>>(studentItems));
        }

        [Authorize]
        [HttpGet("{id}", Name = "GetStudentById")]
        public ActionResult<IEnumerable<StudentReadDtos>> GetStudentById(int id)
        {
            var studentItem = _repository.GetStudentById(id);
            if (studentItem != null)
            {
                return Ok(_mapper.Map<StudentReadDtos>(studentItem));
            }
            return NotFound();

        }

        [Authorize]
        [HttpPost]
        public ActionResult<StudentReadDtos> CreateStudent(StudentCreateDto studentCreateDto)
        {
            var studentModel = _mapper.Map<Student>(studentCreateDto);
            _repository.CreateStudent(studentModel);
            _repository.SaveChanges();

            var studentReadDtos = _mapper.Map<StudentReadDtos>(studentModel);

            return CreatedAtRoute(nameof(GetStudentById), new { id = studentReadDtos.Subject_ID }, studentReadDtos);
        }

        [Authorize]
        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, StudentUpdateDto studentUpdateDto) 
        {
            var studentModelFromRepo = _repository.GetStudentById(id);
            if (studentModelFromRepo == null)
            {
                return NotFound();

            }

            _mapper.Map(studentUpdateDto, studentModelFromRepo);
            _repository.UpdateStudent(studentModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        
        }
        [Authorize]
        [HttpPatch("{id}")]

        public ActionResult PartialStudentUpdate(int id , JsonPatchDocument<StudentUpdateDto> patchDoc) 
        {
            var studentModelFromRepo = _repository.GetStudentById(id);
            if (studentModelFromRepo == null)
            {
                return NotFound();

            }

            var studentToPatch = _mapper.Map<StudentUpdateDto>(studentModelFromRepo);
            patchDoc.ApplyTo(studentToPatch, ModelState);
            if (!TryValidateModel(studentToPatch)) 
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(studentToPatch, studentModelFromRepo);
            _repository.UpdateStudent(studentModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult DeleteStudent(int id) 
        {
            var studentModelFromRepo = _repository.GetStudentById(id);
            if (studentModelFromRepo == null)
            {
                return NotFound();

            }
            _repository.DeleteStudent(studentModelFromRepo);
            _repository.SaveChanges();
            return NoContent();

        }

    }
}