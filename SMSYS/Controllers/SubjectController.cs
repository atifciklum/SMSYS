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
    [Route("api/subjects")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectRepo _repository;
        private readonly IMapper _mapper;

        public SubjectController(ISubjectRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<Subject>> GetSubjects()
        {
            var subjectItems = _repository.GetSubjects();

            return Ok(_mapper.Map<IEnumerable<SubjectReadDto>>(subjectItems));
        }


        [Authorize]
        [HttpGet("{id}", Name = "GetSubjectById")]
        public ActionResult<IEnumerable<SubjectReadDto>> GetSubjectById(int id)
        {
            var commandItem = _repository.GetSubjectById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<SubjectReadDto>(commandItem));
            }
            return NotFound();

        }


        [Authorize]
        [HttpPost]
        public ActionResult<SubjectReadDto> CreateSubject(SubjectCreateDto subjectCreateDto)
        {
            var subjectModel = _mapper.Map<Subject>(subjectCreateDto);
            _repository.CreateSubject(subjectModel);
            _repository.SaveChanges();

            var subjectReadDtos = _mapper.Map<SubjectReadDto>(subjectModel);

            return CreatedAtRoute(nameof(GetSubjectById), new { id = subjectReadDtos.Subject_ID }, subjectReadDtos);
        }


        [Authorize]
        [HttpPut("{id}")]
        public ActionResult UpdateSubject(int id, SubjectUpdateDto subjectUpdateDto)
        {
            var subjectModelFromRepo = _repository.GetSubjectById(id);
            if (subjectModelFromRepo == null)
            {
                return NotFound();

            }

            _mapper.Map(subjectUpdateDto, subjectModelFromRepo);
            _repository.UpdateSubject(subjectModelFromRepo);
            _repository.SaveChanges();
            return NoContent();

        }


        [Authorize]
        [HttpPatch("{id}")]

        public ActionResult PartialSubjectUpdate(int id, JsonPatchDocument<SubjectUpdateDto> patchDoc)
        {
            var subjectModelFromRepo = _repository.GetSubjectById(id);
            if (subjectModelFromRepo == null)
            {
                return NotFound();

            }

            var subjectToPatch = _mapper.Map<SubjectUpdateDto>(subjectModelFromRepo);
            patchDoc.ApplyTo(subjectToPatch, ModelState);
            if (!TryValidateModel(subjectToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(subjectToPatch, subjectModelFromRepo);
            _repository.UpdateSubject(subjectModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }


        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult DeleteSubject(int id)
        {
            var subjectModelFromRepo = _repository.GetSubjectById(id);
            if (subjectModelFromRepo == null)
            {
                return NotFound();

            }
            _repository.DeleteSubject(subjectModelFromRepo);
            _repository.SaveChanges();
            return NoContent();

        }

    }
}