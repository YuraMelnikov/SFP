using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace SFPrj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FailController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public FailController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetFail()
        {
            var fail = await _repository.Fail.GetAllFailAsync(trackChanges: false);
            var failDTO = _mapper.Map<IEnumerable<FailDto>>(fail);
            return Ok(failDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFail(Guid id)
        {
            var fail = await _repository.Fail.GetFailAsync(id, trackChanges: false);
            if (fail == null)
                return NotFound();
            else
            {
                var failDTO = _mapper.Map<FailDto>(fail);
                return Ok(failDTO);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateFail([FromBody]FailCreateDto fail)
        {
            if (fail == null)
                return BadRequest("FailCreateDto object is null.");
            else
            {
                var failEntity = _mapper.Map<Fail>(fail);
                _repository.Fail.CreateFail(failEntity);
                await _repository.SaveAsync();
                var failToReturn = _mapper.Map<FailDto>(failEntity);
                return CreatedAtRoute("GetFail", new { id = failToReturn.Id }, failToReturn);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFail(Guid id)
        {
            var fail = await _repository.Fail.GetFailAsync(id, trackChanges: false);
            if (fail == null)
            {
                return NotFound();
            }
            _repository.Fail.DeleteFail(fail);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFail([FromBody] FailUpdateDto fail)
        {
            if (fail == null)
                return BadRequest("FailUpdateDto object is null");
            var failEntity = await _repository.Fail.GetFailAsync(fail.Id, trackChanges: true);
            if (failEntity == null)
                return NotFound();
            _mapper.Map(fail, failEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}