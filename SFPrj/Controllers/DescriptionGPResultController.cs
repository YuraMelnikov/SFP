using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entities.DataTransferObjects;
using Entities.Models;
using AutoMapper;
using SFPrj.ActionFilters;
using Contracts;

namespace SFPrj.Controllers
{
    [ServiceFilter(typeof(ModelValidationAttribute))]
    [ServiceFilter(typeof(ModelNullAttribute))]
    [Route("api/descriptiongpresult")]
    [ApiController]
    public class DescriptionGPResultController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public DescriptionGPResultController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var descriptions = await _repository.DescriptionGPResult.GetAllAsync();
            var descriptionsResult = _mapper.Map<IEnumerable<DescriptionGPResultDto>>(descriptions);
            return Ok(descriptionsResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var description = await _repository.DescriptionGPResult.GetByIdAsync(id);
            var descriptionResult = _mapper.Map<DescriptionGPResultDto>(description);
            return Ok(descriptionResult);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DescriptionGPResultCreateDto description)
        {
            var descriptionEntity = _mapper.Map<DescriptionGPResult>(description);
            await _repository.DescriptionGPResult.AddAsync(descriptionEntity);
            var descriptionCreate = _mapper.Map<DescriptionGPResultDto>(descriptionEntity);
            return CreatedAtRoute("DescriptionById", new { id = descriptionCreate.Id }, descriptionCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, DescriptionGPResultUpdateDto description)
        {
            var descriptionEntity = await _repository.DescriptionGPResult.GetByIdAsync(id);
            descriptionEntity = _mapper.Map(description, descriptionEntity);
            await _repository.DescriptionGPResult.UpdateAsync(descriptionEntity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var descriptionEntity = await _repository.DescriptionGPResult.GetByIdAsync(id);
            await _repository.DescriptionGPResult.DeleteAsync(descriptionEntity);
            return NoContent();
        }
    }
}