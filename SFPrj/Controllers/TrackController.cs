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
    [Route("api/track")]
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
        public async Task<IActionResult> GetAll()
        {
            var tracks = await _repository.Track.GetAll();
            var tracksResult = _mapper.Map<IEnumerable<RacerDto>>(tracks);
            return Ok(tracksResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var track = await _repository.Track.GetById(id);
            var trackResult = _mapper.Map<TrackDto>(track);
            return Ok(trackResult);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TrackCreateDto track)
        {
            var trackEntity = _mapper.Map<Track>(track);
            await _repository.Track.Create(trackEntity);
            await _repository.SaveAsync();
            var trackCreate = _mapper.Map<TrackDto>(trackEntity);
            return CreatedAtRoute("GetById", new { id = trackCreate.Id }, trackCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, TrackUpdateDto track)
        {
            var trackEntity = await _repository.Track.GetById(id);
            trackEntity = _mapper.Map(track, trackEntity);
            _repository.Track.Update(trackEntity);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var trackEntity = await _repository.Track.GetById(id);
            _repository.Track.Delete(trackEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}