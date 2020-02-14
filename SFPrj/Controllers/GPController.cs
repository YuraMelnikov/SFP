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
    public class GPController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public GPController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var gps = await _repository.GP.GetAllAsync();
            var gpsResult = _mapper.Map<IEnumerable<GPDto>>(gps);
            return Ok(gpsResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var gp = await _repository.GP.GetByIdAsync(id);
            var gpResult = _mapper.Map<GPDto>(gp);
            return Ok(gpResult);
        }

        [HttpPost]
        public async Task<IActionResult> Post(GPCreateDto gP)
        {
            var gpEntity = _mapper.Map<GP>(gP);
            await _repository.GP.AddAsync(gpEntity);
            var gpCreate = _mapper.Map<GPDto>(gpEntity);
            return CreatedAtRoute("GPById", new { id = gpCreate.Id}, gpCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, GPUpdateDto gP)
        {
            var gpEntity = await _repository.GP.GetByIdAsync(id);
            gpEntity = _mapper.Map(gP, gpEntity);
            await _repository.GP.UpdateAsync(gpEntity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var gpEntity = await _repository.GP.GetByIdAsync(id);
            await _repository.GP.DeleteAsync(gpEntity);
            return NoContent();
        }
    }
}