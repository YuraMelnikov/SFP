using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using System.Collections.Generic;

namespace SFPrj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FineController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public FineController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetFine()
        {
            var fine = await _repository.Fine.GetAllFineAsync(trackChanges: false);
            var fineDTO = _mapper.Map<IEnumerable<FineDto>>(fine);
            return Ok(fineDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFine(Guid id)
        {
            var fine = await _repository.Fine.GetFineAsync(id, trackChanges: false);
            if (fine == null)
                return NotFound();
            else
            {
                var fineDTO = _mapper.Map<FineDto>(fine);
                return Ok(fineDTO);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateFine([FromBody]FineCreateDto fine)
        {
            if (fine == null)
                return BadRequest("FineCreateDto object is null.");
            else
            {
                var fineEntity = _mapper.Map<Fine>(fine);
                _repository.Fine.CreateFine(fineEntity);
                await _repository.SaveAsync();
                var fineToReturn = _mapper.Map<FineDto>(fineEntity);
                return CreatedAtRoute("GetFine", new { id = fineToReturn.Id }, fineToReturn);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFine(Guid id)
        {
            var fine = await _repository.Fine.GetFineAsync(id, trackChanges: false);
            if (fine == null)
            {
                return NotFound();
            }
            _repository.Fine.DeleteFine(fine);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFine([FromBody] FineUpdateDto fine)
        {
            if (fine == null)
                return BadRequest("FineUpdateDto object is null");
            var fineEntity = await _repository.Fine.GetFineAsync(fine.Id, trackChanges: true);
            if (fineEntity == null)
                return NotFound();
            _mapper.Map(fine, fineEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}