using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using AutoMapper;
using SFPrj.ActionFilters;
using Entities.DataTransferObjects;
using Entities.Models;

namespace SFPrj.Controllers
{
    [ServiceFilter(typeof(ModelNullAttribute))]
    [ServiceFilter(typeof(ModelValidationAttribute))]
    [Route("api/pit")]
    [ApiController]
    public class PitController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public PitController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pits = await _repository.Pit.GetAllAsync();
            var pitsResult = _mapper.Map<IEnumerable<PitDto>>(pits);
            return Ok(pitsResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var pit = await _repository.Pit.GetByIdAsync(id);
            var pitResult = _mapper.Map<PitDto>(pit);
            return Ok(pitResult);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PitCreateDto pit)
        {
            var pitEntity = _mapper.Map<Pit>(pit);
            await _repository.Pit.AddAsync(pitEntity);
            var pitCreate = _mapper.Map<PitDto>(pitEntity);
            return CreatedAtRoute("GetById", new { id = pitCreate.Id}, pitCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, PitUpdateDto pit)
        {
            var pitEntity = await _repository.Pit.GetByIdAsync(id);
            pitEntity = _mapper.Map(pit, pitEntity);
            await _repository.Pit.UpdateAsync(pitEntity);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var pitEntity = await _repository.Pit.GetByIdAsync(id);
            await _repository.Pit.DeleteAsync(pitEntity);
            return NoContent();
        }
    }
}