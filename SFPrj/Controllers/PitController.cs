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
    public class PitController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public PitController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPit()
        {
            var pit = await _repository.Pit.GetAllPitAsync(trackChanges: false);
            var pitDTO = _mapper.Map<IEnumerable<PitDto>>(pit);
            return Ok(pitDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPit(Guid id)
        {
            var pit = await _repository.Pit.GetPitAsync(id, trackChanges: false);
            if (pit == null)
                return NotFound();
            else
            {
                var pitDTO = _mapper.Map<PitDto>(pit);
                return Ok(pitDTO);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePit([FromBody]PitCreateDto pit)
        {
            if (pit == null)
                return BadRequest("PitDto object is null.");
            else
            {
                var pitEntity = _mapper.Map<Pit>(pit);
                _repository.Pit.CreatePit(pitEntity);
                await _repository.SaveAsync();
                var pitToReturn = _mapper.Map<PitDto>(pitEntity);
                return CreatedAtRoute("GetPit", new { id = pitToReturn.Id }, pitToReturn);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePit(Guid id)
        {
            var pit = await _repository.Pit.GetPitAsync(id, trackChanges: false);
            if (pit == null)
            {
                return NotFound();
            }
            _repository.Pit.DeletePit(pit);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePit([FromBody] PitDto pit)
        {
            if (pit == null)
                return BadRequest("PitDto object is null");
            var pitEntity = await _repository.Pit.GetPitAsync(pit.Id, trackChanges: true);
            if (pitEntity == null)
                return NotFound();
            _mapper.Map(pit, pitEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}