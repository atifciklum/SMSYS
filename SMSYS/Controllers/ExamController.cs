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
  
    [Route("api/exams")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamRepo _repository;
        private readonly IMapper _mapper;

        public ExamController(IExamRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
 
        [HttpGet]
        public ActionResult<IEnumerable<Exam>> GetExams()
        {
            var examItems = _repository.GetExams();

            return Ok(_mapper.Map<IEnumerable<ExamReadDtos>>(examItems));
        }


        [Authorize]
        [HttpGet("{id}", Name = "GetExamById")]
        public ActionResult<IEnumerable<ExamReadDtos>> GetExamById(int id)
        {
            var commandItem = _repository.GetExamById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<ExamReadDtos>(commandItem));
            }
            return NotFound();

        }
     
        [HttpPost]
        public ActionResult<ExamReadDtos> CreateExam(ExamCreateDto examCreateDto)
        {
            var examModel = _mapper.Map<Exam>(examCreateDto);
            _repository.CreateExam(examModel);
            _repository.SaveChanges();

            var examReadDtos = _mapper.Map<ExamReadDtos>(examModel);

            return CreatedAtRoute(nameof(GetExamById), new { id = examReadDtos.Exam_ID }, examReadDtos);
        }
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult UpdateExam(int id, ExamUpdateDto examUpdateDto)
        {
            var examModelFromRepo = _repository.GetExamById(id);
            if (examModelFromRepo == null)
            {
                return NotFound();

            }

            _mapper.Map(examUpdateDto, examModelFromRepo);
            _repository.UpdateExam(examModelFromRepo);
            _repository.SaveChanges();
            return NoContent();

        }
        [Authorize]
        [HttpPatch("{id}")]

        public ActionResult PartialExamUpdate(int id, JsonPatchDocument<ExamUpdateDto> patchDoc)
        {
            var examModelFromRepo = _repository.GetExamById(id);
            if (examModelFromRepo == null)
            {
                return NotFound();

            }

            var examToPatch = _mapper.Map<ExamUpdateDto>(examModelFromRepo);
            patchDoc.ApplyTo(examToPatch, ModelState);
            if (!TryValidateModel(examToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(examToPatch, examModelFromRepo);
            _repository.UpdateExam(examModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult DeleteExam(int id)
        {
            var examModelFromRepo = _repository.GetExamById(id);
            if (examModelFromRepo == null)
            {
                return NotFound();

            }
            _repository.DeleteExam(examModelFromRepo);
            _repository.SaveChanges();
            return NoContent();

        }

        [HttpGet("getAllStudentResultsByExamId/{id}")]

        public ActionResult<IEnumerable<StudentResultDto>> getAllStudentResultsByExamId(int id)
        {
            var StudentResultsByExamId = _repository.getAllStudentResultsByExamId(id);

            return StudentResultsByExamId.ToList();

        }

    }
}