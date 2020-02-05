using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using AutoMapper;
using SFPrj.ActionFilters;
using Entities.DataTransferObjects;
using Entities.Models;
using System.Collections.Generic;

namespace SFPrj.Controllers
{
    [ServiceFilter(typeof(ModelValidationAttribute))]
    [Route("api/trackconfiguration")]
    [ApiController]
    public class TrackСonfigurationController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public TrackСonfigurationController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var trackConfigurations = await _repository.TrackConfiguration.GetAllAsync();
            var trackConfigurationsResult = _mapper.Map<IEnumerable<TrackСonfigurationDto>>(trackConfigurations);
            return Ok(trackConfigurationsResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var trackConfiguration = await _repository.TrackConfiguration.GetByIdAsync(id);
            var trackConfigurationResult = _mapper.Map<TrackСonfigurationDto>(trackConfiguration);
            return Ok(trackConfigurationResult);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TrackСonfigurationCreateDto track)
        {
            var trackConfigurationEntity = _mapper.Map<TrackСonfiguration>(track);
            await _repository.TrackConfiguration.AddAsync(trackConfigurationEntity);
            var trackConfigurationCreate = _mapper.Map<TrackСonfigurationDto>(trackConfigurationEntity);
            return CreatedAtRoute("GetById", new { id = trackConfigurationCreate.Id }, trackConfigurationCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id,  TrackСonfigurationCreateDto track)
        {
            var trackConfigurationEntity = await _repository.TrackConfiguration.GetByIdAsync(id);
            trackConfigurationEntity = _mapper.Map(track, trackConfigurationEntity);
            await _repository.TrackConfiguration.UpdateAsync(trackConfigurationEntity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var trackConfigurationEntity = await _repository.TrackConfiguration.GetByIdAsync(id);
            await _repository.TrackConfiguration.DeleteAsync(trackConfigurationEntity);
            return NoContent();
        }
    }
}