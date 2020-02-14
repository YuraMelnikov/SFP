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
    [Route("api/[controller]")]
    [ApiController]
    public class RacerController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public RacerController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var racers = await _repository.Racer.GetAllAsync();
            var racersResult = _mapper.Map<IEnumerable<RacerDto>>(racers);
            return Ok(racersResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var racer = await _repository.Racer.GetByIdAsync(id);
            var racerResult = _mapper.Map<RacerDto>(racer);
            return Ok(racerResult);
        }

        [HttpPost]
        public async Task<IActionResult> Post(RacerCreateDto racer)
        {
            var racerEntity = _mapper.Map<Racer>(racer);
            await _repository.Racer.AddAsync(racerEntity);
            var racerCreate = _mapper.Map<RacerDto>(racerEntity);
            return CreatedAtRoute("GetById", new { id = racerCreate.Id}, racerCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, RacerCreateDto racer)
        {
            var racerEntity = await _repository.Racer.GetByIdAsync(id);
            racerEntity = _mapper.Map(racer, racerEntity);
            await _repository.Racer.UpdateAsync(racerEntity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var racerEntity = await _repository.Racer.GetByIdAsync(id);
            await _repository.Racer.DeleteAsync(racerEntity);
            return NoContent();
        }
    }
}