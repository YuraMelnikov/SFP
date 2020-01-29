using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SFPrj.ActionFilters;
using Contracts;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace SFPrj.Controllers
{
    [ServiceFilter(typeof(ModelValidationAttribute))]
    [ServiceFilter(typeof(ModelNullAttribute))]
    [Route("api/chassi")]
    [ApiController]
    public class ChassiController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public ChassiController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var chassi = await _repository.Chassi.GetAll();
            var chassisResult = _mapper.Map<IEnumerable<ChassiDto>>(chassi);
            return Ok(chassisResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var chassi = await _repository.Chassi.GetById(id);
            var chassiResult = _mapper.Map<ChassiDto>(chassi);
            return Ok(chassiResult);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ChassiCreateDto chassi)
        {
            var chassiEntity = _mapper.Map<Chassi>(chassi);
            await _repository.Chassi.Create(chassiEntity);
            await _repository.SaveAsync();
            var createChassi = _mapper.Map<ChassiDto>(chassiEntity);
            return CreatedAtRoute("ChassiById", new { id = createChassi.Id }, createChassi);
        }

        [HttpPut("{id}")] 
        public async Task<IActionResult> Update(Guid id, ChassiUpdateDto chassi)
        {
            var chassiEntity = await _repository.Chassi.GetById(id);
            chassiEntity = _mapper.Map(chassi, chassiEntity);
            _repository.Chassi.Update(chassiEntity);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var chassi = await _repository.Chassi.GetById(id);
            _repository.Chassi.Delete(chassi);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}