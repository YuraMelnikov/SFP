using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entities.DataTransferObjects;
using Entities.Models;
using AutoMapper;
using Contracts;

namespace SFPrj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescriptionGPResultController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public DescriptionGPResultController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetDescriptionsGPResults()
        {
            var descriptions = await _repository.DescriptionGPResult.GetAllDescriptionGPResultAsync(trackChanges: false);
            var descriptionsDTO = _mapper.Map<IEnumerable<DescriptionGPResultDto>>(descriptions);
            return Ok(descriptionsDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDescriptionGPResult(Guid id)
        {
            var description = await _repository.DescriptionGPResult.GetDescriptionGPResultAsync(id, trackChanges: false);
            if (description == null)
                return NotFound();
            else
            {
                var descriptionDTO = _mapper.Map<DescriptionGPResultDto>(description);
                return Ok(descriptionDTO);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateDescriptionGPResult([FromBody]DescriptionGPResultCreateDto description)
        {
            if (description == null)
                return BadRequest("DescriptionGPResultCreateDto object is null.");
            else
            {
                var descriptionEntity = _mapper.Map<DescriptionGPResult>(description);
                _repository.DescriptionGPResult.CreateDescriptionGPResult(descriptionEntity);
                await _repository.SaveAsync();
                var descriptionToReturn = _mapper.Map<DescriptionGPResult>(descriptionEntity);
                return CreatedAtRoute("GetDescriptionGPResult", new { id = descriptionToReturn.Id }, descriptionToReturn);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDescriptionGPResult(Guid id)
        {
            var description = await _repository.DescriptionGPResult.GetDescriptionGPResultAsync(id, trackChanges: false);
            if (description == null)
            {
                return NotFound();
            }
            _repository.DescriptionGPResult.DeleteDescriptionGPResult(description);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDescriptionGPResult([FromBody] DescriptionGPResultUpdateDto description)
        {
            if (description == null)
                return BadRequest("DescriptionGPResultUpdateDto object is null");
            var descriptionEntity = await _repository.DescriptionGPResult.GetDescriptionGPResultAsync(description.Id, trackChanges: true);
            if (descriptionEntity == null)
                return NotFound();
            _mapper.Map(description, descriptionEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}