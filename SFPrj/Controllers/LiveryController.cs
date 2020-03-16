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
    public class LiveryController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public LiveryController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetLivery()
        {
            var livery = await _repository.Livery.GetAllLiveryAsync(trackChanges: false);
            var liveryDTO = _mapper.Map<IEnumerable<LiveryDto>>(livery);
            return Ok(liveryDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLivery(Guid id)
        {
            var livery = await _repository.Livery.GetLiveryAsync(id, trackChanges: false);
            if (livery == null)
                return NotFound();
            else
            {
                var liveryDTO = _mapper.Map<LiveryDto>(livery);
                return Ok(liveryDTO);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateLivery([FromBody]LiveryCreateDto livery)
        {
            if (livery == null)
                return BadRequest("LiveryDto object is null.");
            else
            {
                var liveryEntity = _mapper.Map<Livery>(livery);
                _repository.Livery.CreateLivery(liveryEntity);
                await _repository.SaveAsync();
                var liveryToReturn = _mapper.Map<LiveryDto>(liveryEntity);
                return CreatedAtRoute("GetLivery", new { id = liveryToReturn.Id }, liveryToReturn);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLivery(Guid id)
        {
            var livery = await _repository.Livery.GetLiveryAsync(id, trackChanges: false);
            if (livery == null)
            {
                return NotFound();
            }
            _repository.Livery.DeleteLivery(livery);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLivery([FromBody] LiveryDto livery)
        {
            if (livery == null)
                return BadRequest("LiveryDto object is null");
            var liveryEntity = await _repository.Livery.GetLiveryAsync(livery.Id, trackChanges: true);
            if (liveryEntity == null)
                return NotFound();
            _mapper.Map(livery, liveryEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}