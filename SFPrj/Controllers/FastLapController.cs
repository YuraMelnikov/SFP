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
    [ServiceFilter(typeof(ModelValidationAttribute))]
    [ServiceFilter(typeof(ModelNullAttribute))]
    [Route("api/fastlap")]
    [ApiController]
    public class FastLapController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public FastLapController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var fastLaps = await _repository.FastLap.GetAllAsync();
            var fastLapsResult = _mapper.Map<IEnumerable<FastLapDto>>(fastLaps);
            return Ok(fastLapsResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var fastLap = await _repository.FastLap.GetByIdAsync(id);
            var fastLapResult = _mapper.Map<FastLapDto>(fastLap);
            return Ok(fastLapResult);
        }

        [HttpPost]
        public async Task<IActionResult> Post(FastLapCreateDto fastLap)
        {
            var fastLapEntity = _mapper.Map<FastLap>(fastLap);
            await _repository.FastLap.AddAsync(fastLapEntity);
            var fastLapCreate = _mapper.Map<FastLapDto>(fastLapEntity);
            return CreatedAtRoute("FastlpaById", new { id = fastLapCreate.Id}, fastLapCreate);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, FastLapUpdateDto fastLap)
        {
            var fastLapEntity = await _repository.FastLap.GetByIdAsync(id);
            fastLapEntity = _mapper.Map(fastLap, fastLapEntity);
            await _repository.FastLap.UpdateAsync(fastLapEntity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var fastLapEntity = await _repository.FastLap.GetByIdAsync(id);
            await _repository.FastLap.DeleteAsync(fastLapEntity);
            return NoContent();
        }
    }
}