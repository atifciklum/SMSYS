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

    [Authorize]
    [Route("api/teachers")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepo _repository;
        private readonly IMapper _mapper;

        public TeacherController(ITeacherRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<Teacher>> GetTeachers()
        {
            var teacherItems = _repository.GetTeachers();

            return Ok(_mapper.Map<IEnumerable<TeacherReadDtos>>(teacherItems));
        }

        [Authorize]
        [HttpGet("{id}", Name = "GetTeacherById")]
        public ActionResult<IEnumerable<TeacherReadDtos>> GetTeacherById(int id)
        {
            var commandItem = _repository.GetTeacherById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<TeacherReadDtos>(commandItem));
            }
            return NotFound();

        }


        [Authorize]
        [HttpPost]
        public ActionResult<TeacherReadDtos> CreateTeacher(TeacherCreateDto teacherCreateDto)
        {
            var teacherModel = _mapper.Map<Teacher>(teacherCreateDto);
            _repository.CreateTeacher(teacherModel);
            _repository.SaveChanges();

            var teacherReadDtos = _mapper.Map<TeacherReadDtos>(teacherModel);

            return CreatedAtRoute(nameof(GetTeacherById), new { id = teacherReadDtos.Teacher_ID }, teacherReadDtos);
        }


        [Authorize]
        [HttpPut("{id}")]
        public ActionResult UpdateTeacher(int id, TeacherUpdateDto teacherUpdateDto)
        {
            var teacherModelFromRepo = _repository.GetTeacherById(id);
            if (teacherModelFromRepo == null)
            {
                return NotFound();

            }

            _mapper.Map(teacherUpdateDto, teacherModelFromRepo);
            _repository.UpdateTeacher(teacherModelFromRepo);
            _repository.SaveChanges();
            return NoContent();

        }


        [Authorize]
        [HttpPatch("{id}")]

        public ActionResult PartialTeacherUpdate(int id, JsonPatchDocument<TeacherUpdateDto> patchDoc)
        {
            var teacherModelFromRepo = _repository.GetTeacherById(id);
            if (teacherModelFromRepo == null)
            {
                return NotFound();

            }

            var teacherToPatch = _mapper.Map<TeacherUpdateDto>(teacherModelFromRepo);
            patchDoc.ApplyTo(teacherToPatch, ModelState);
            if (!TryValidateModel(teacherToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(teacherToPatch, teacherModelFromRepo);
            _repository.UpdateTeacher(teacherModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult DeleteTeacher(int id)
        {
            var teacherModelFromRepo = _repository.GetTeacherById(id);
            if (teacherModelFromRepo == null)
            {
                return NotFound();

            }
            _repository.DeleteTeacher(teacherModelFromRepo);
            _repository.SaveChanges();
            return NoContent();

        }

    }
}