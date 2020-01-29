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
        public async Task<IActionResult> GetAll()
        {
            var fastLaps = await _repository.FastLap.GetAll();
            var fastLapsResult = _mapper.Map<IEnumerable<FastLapDto>>(fastLaps);
            return Ok(fastLapsResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var fastLap = await _repository.FastLap.GetById(id);
            var fastLapResult = _mapper.Map<FastLapDto>(fastLap);
            return Ok(fastLapResult);
        }

        [HttpPost]
        public async Task<IActionResult> Create(FastLapCreateDto fastLap)
        {
            var fastLapEntity = _mapper.Map<FastLap>(fastLap);
            await _repository.FastLap.Create(fastLapEntity);
            await _repository.SaveAsync();
            var fastLapCreate = _mapper.Map<FastLapDto>(fastLapEntity);
            return CreatedAtRoute("FastlpaById", new { id = fastLapCreate.Id}, fastLapCreate);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, FastLapUpdateDto fastLap)
        {
            var fastLapEntity = await _repository.FastLap.GetById(id);
            fastLapEntity = _mapper.Map(fastLap, fastLapEntity);
            _repository.FastLap.Update(fastLapEntity);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var fastLapEntity = await _repository.FastLap.GetById(id);
            _repository.FastLap.Delete(fastLapEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}