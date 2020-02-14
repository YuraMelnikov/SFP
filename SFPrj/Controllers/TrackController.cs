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
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public TrackController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tracks = await _repository.Track.GetAllAsync();
            var tracksResult = _mapper.Map<IEnumerable<RacerDto>>(tracks);
            return Ok(tracksResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var track = await _repository.Track.GetByIdAsync(id);
            var trackResult = _mapper.Map<TrackDto>(track);
            return Ok(trackResult);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TrackCreateDto track)
        {
            var trackEntity = _mapper.Map<Track>(track);
            await _repository.Track.AddAsync(trackEntity);
            var trackCreate = _mapper.Map<TrackDto>(trackEntity);
            return CreatedAtRoute("GetById", new { id = trackCreate.Id }, trackCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, TrackUpdateDto track)
        {
            var trackEntity = await _repository.Track.GetByIdAsync(id);
            trackEntity = _mapper.Map(track, trackEntity);
            await _repository.Track.UpdateAsync(trackEntity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var trackEntity = await _repository.Track.GetByIdAsync(id);
            await _repository.Track.DeleteAsync(trackEntity);
            return NoContent();
        }
    }
}