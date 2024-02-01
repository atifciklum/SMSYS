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
    [Route("api/results")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly IResultRepo _repository;
        private readonly IMapper _mapper;

        public ResultController(IResultRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<Result>> GetResults()
        {
            var resultItems = _repository.GetResults();

            return Ok(_mapper.Map<IEnumerable<ResultReadDto>>(resultItems));
        }


        [Authorize]
        [HttpGet("{id}", Name = "GetResultById")]
        public ActionResult<IEnumerable<ResultReadDto>> GetResultById(int id)
        {
            var commandItem = _repository.GetResultById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<ResultReadDto>(commandItem));
            }
            return NotFound();

        }


        [Authorize]
        [HttpPost]
        public ActionResult<ResultReadDto> CreateResult(ResultCreateDto resultCreateDto)
        {
            var resultModel = _mapper.Map<Result>(resultCreateDto);
            _repository.CreateResult(resultModel);
            _repository.SaveChanges();

            var resultReadDtos = _mapper.Map<ResultReadDto>(resultModel);

            return CreatedAtRoute(nameof(GetResultById), new { id = resultReadDtos.Subject_ID }, resultReadDtos);
        }


        [Authorize]
        [HttpPut("{id}")]
        public ActionResult UpdateResult(int id, ResultUpdateDto resultUpdateDto)
        {
            var resultModelFromRepo = _repository.GetResultById(id);
            if (resultModelFromRepo == null)
            {
                return NotFound();

            }

            _mapper.Map(resultUpdateDto, resultModelFromRepo);
            _repository.UpdateResult(resultModelFromRepo);
            _repository.SaveChanges();
            return NoContent();

        }


        [Authorize]
        [HttpPatch("{id}")]

        public ActionResult PartialResultUpdate(int id, JsonPatchDocument<ResultUpdateDto> patchDoc)
        {
            var resultModelFromRepo = _repository.GetResultById(id);
            if (resultModelFromRepo == null)
            {
                return NotFound();

            }

            var resultToPatch = _mapper.Map<ResultUpdateDto>(resultModelFromRepo);
            patchDoc.ApplyTo(resultToPatch, ModelState);
            if (!TryValidateModel(resultToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(resultToPatch, resultModelFromRepo);
            _repository.UpdateResult(resultModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }


        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult DeleteResult(int id)
        {
            var resultModelFromRepo = _repository.GetResultById(id);
            if (resultModelFromRepo == null)
            {
                return NotFound();

            }
            _repository.DeleteResult(resultModelFromRepo);
            _repository.SaveChanges();
            return NoContent();

        }

    }
}