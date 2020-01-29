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
        public async Task<IActionResult> GetAll()
        {
            var descriptions = await _repository.DescriptionGPResult.GetAll();
            var descriptionsResult = _mapper.Map<IEnumerable<DescriptionGPResultDto>>(descriptions);
            return Ok(descriptionsResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var description = await _repository.DescriptionGPResult.GetById(id);
            var descriptionResult = _mapper.Map<DescriptionGPResultDto>(description);
            return Ok(descriptionResult);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DescriptionGPResultCreateDto description)
        {
            var descriptionEntity = _mapper.Map<DescriptionGPResult>(description);
            await _repository.DescriptionGPResult.Create(descriptionEntity);
            await _repository.SaveAsync();
            var descriptionCreate = _mapper.Map<DescriptionGPResultDto>(descriptionEntity);
            return CreatedAtRoute("DescriptionById", new { id = descriptionCreate.Id }, descriptionCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, DescriptionGPResultUpdateDto description)
        {
            var descriptionEntity = await _repository.DescriptionGPResult.GetById(id);
            descriptionEntity = _mapper.Map(description, descriptionEntity);
            _repository.DescriptionGPResult.Update(descriptionEntity);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var descriptionEntity = await _repository.DescriptionGPResult.GetById(id);
            _repository.DescriptionGPResult.Delete(descriptionEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}