using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using AutoMapper;

namespace SFPrj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DNQController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public DNQController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetDNQs()
        {
            var dnqs = await _repository.DNQ.GetAllDNQAsync(trackChanges: false);
            var dnqsDTO = _mapper.Map<IEnumerable<DNQDto>>(dnqs);
            return Ok(dnqsDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDNQ(Guid id)
        {
            var dnq = await _repository.DNQ.GetDNQAsync(id, trackChanges: false);
            if (dnq == null)
                return NotFound();
            else
            {
                var dnqDTO = _mapper.Map<DNQDto>(dnq);
                return Ok(dnqDTO);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateDNQ([FromBody]DNQCreateDto dnq)
        {
            if (dnq == null)
                return BadRequest("DNQCreateDto object is null.");
            else
            {
                var dnqEntity = _mapper.Map<DNQ>(dnq);
                _repository.DNQ.CreateDNQ(dnqEntity);
                await _repository.SaveAsync();
                var dnqToReturn = _mapper.Map<DNQDto>(dnqEntity);
                return CreatedAtRoute("GetDNQ", new { id = dnqToReturn.Id }, dnqToReturn);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDNQ(Guid id)
        {
            var dnq = await _repository.DNQ.GetDNQAsync(id, trackChanges: false);
            if (dnq == null)
            {
                return NotFound();
            }
            _repository.DNQ.DeleteDNQ(dnq);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDNQ([FromBody] DNQUpdateDto dnq)
        {
            if (dnq == null)
                return BadRequest("DNQUpdateDto object is null");
            var dnqEntity = await _repository.DNQ.GetDNQAsync(dnq.Id, trackChanges: true);
            if (dnqEntity == null)
                return NotFound();
            _mapper.Map(dnq, dnqEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}