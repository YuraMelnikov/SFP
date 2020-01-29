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
        public async Task<IActionResult> GetAll()
        {
            var pits = await _repository.Pit.GetAll();
            var pitsResult = _mapper.Map<IEnumerable<PitDto>>(pits);
            return Ok(pitsResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var pit = await _repository.Pit.GetById(id);
            var pitResult = _mapper.Map<PitDto>(pit);
            return Ok(pitResult);
        }

        [HttpPost]
        public async Task<IActionResult> Crete(PitCreateDto pit)
        {
            var pitEntity = _mapper.Map<Pit>(pit);
            await _repository.Pit.Create(pitEntity);
            await _repository.SaveAsync();
            var pitCreate = _mapper.Map<PitDto>(pitEntity);
            return CreatedAtRoute("GetById", new { id = pitCreate.Id}, pitCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, PitUpdateDto pit)
        {
            var pitEntity = await _repository.Pit.GetById(id);
            pitEntity = _mapper.Map(pit, pitEntity);
            _repository.Pit.Update(pitEntity);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var pitEntity = await _repository.Pit.GetById(id);
            _repository.Pit.Delete(pitEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}