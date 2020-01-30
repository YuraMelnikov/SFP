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
    [Route("api/racer")]
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
        public async Task<IActionResult> GetAll()
        {
            var racers = await _repository.Racer.GetAll();
            var racersResult = _mapper.Map<IEnumerable<RacerDto>>(racers);
            return Ok(racersResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var racer = await _repository.Racer.GetById(id);
            var racerResult = _mapper.Map<RacerDto>(racer);
            return Ok(racerResult);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RacerCreateDto racer)
        {
            var racerEntity = _mapper.Map<Racer>(racer);
            await _repository.Racer.Create(racerEntity);
            await _repository.SaveAsync();
            var racerCreate = _mapper.Map<RacerDto>(racerEntity);
            return CreatedAtRoute("GetById", new { id = racerCreate.Id}, racerCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, RacerCreateDto racer)
        {
            var racerEntity = await _repository.Racer.GetById(id);
            racerEntity = _mapper.Map(racer, racerEntity);
            _repository.Racer.Update(racerEntity);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var racerEntity = await _repository.Racer.GetById(id);
            _repository.Racer.Delete(racerEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}