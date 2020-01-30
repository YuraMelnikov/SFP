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
    [ServiceFilter(typeof(ModelNullAttribute))]
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
        public async Task<IActionResult> GetAll()
        {
            var trackConfigurations = await _repository.TrackConfiguration.GetAll();
            var trackConfigurationsResult = _mapper.Map<IEnumerable<TrackСonfigurationDto>>(trackConfigurations);
            return Ok(trackConfigurationsResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var trackConfiguration = await _repository.TrackConfiguration.GetById(id);
            var trackConfigurationResult = _mapper.Map<TrackСonfigurationDto>(trackConfiguration);
            return Ok(trackConfigurationResult);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TrackСonfigurationCreateDto track)
        {
            var trackConfigurationEntity = _mapper.Map<TrackСonfiguration>(track);
            await _repository.TrackConfiguration.Create(trackConfigurationEntity);
            await _repository.SaveAsync();
            var trackConfigurationCreate = _mapper.Map<TrackСonfigurationDto>(trackConfigurationEntity);
            return CreatedAtRoute("GetById", new { id = trackConfigurationCreate.Id }, trackConfigurationCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id,  TrackСonfigurationCreateDto track)
        {
            var trackConfigurationEntity = await _repository.TrackConfiguration.GetById(id);
            trackConfigurationEntity = _mapper.Map(track, trackConfigurationEntity);
            _repository.TrackConfiguration.Update(trackConfigurationEntity);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var trackConfigurationEntity = await _repository.TrackConfiguration.GetById(id);
            _repository.TrackConfiguration.Delete(trackConfigurationEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}