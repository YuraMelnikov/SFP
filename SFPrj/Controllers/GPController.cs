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
    [Route("api/gp")]
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
        public async Task<IActionResult> GetAll()
        {
            var gps = await _repository.GP.GetAll();
            var gpsResult = _mapper.Map<IEnumerable<GPDto>>(gps);
            return Ok(gpsResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var gp = await _repository.GP.GetById(id);
            var gpResult = _mapper.Map<GPDto>(gp);
            return Ok(gpResult);
        }

        [HttpPost]
        public async Task<IActionResult> Create(GPCreateDto gP)
        {
            var gpEntity = _mapper.Map<GP>(gP);
            await _repository.GP.Create(gpEntity);
            await _repository.SaveAsync();
            var gpCreate = _mapper.Map<GPDto>(gpEntity);
            return CreatedAtRoute("GPById", new { id = gpCreate.Id}, gpCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, GPUpdateDto gP)
        {
            var gpEntity = await _repository.GP.GetById(id);
            gpEntity = _mapper.Map(gP, gpEntity);
            _repository.GP.Update(gpEntity);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var gpEntity = await _repository.GP.GetById(id);
            _repository.GP.Delete(gpEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}