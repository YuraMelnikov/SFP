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
    [Route("api/manufacturer")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public ManufacturerController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var manufacturers = await _repository.Manufacturer.GetAllAsync();
            var manufacturersResult = _mapper.Map<IEnumerable<ManufacturerDto>>(manufacturers);
            return Ok(manufacturersResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var manufacturer = await _repository.Manufacturer.GetByIdAsync(id);
            var manufacturerResult = _mapper.Map<IEnumerable<ManufacturerDto>>(manufacturer);
            return Ok(manufacturerResult);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ManufacturerCreateDto manufacturer)
        {
            var manufacturerEntity = _mapper.Map<Manufacturer>(manufacturer);
            await _repository.Manufacturer.AddAsync(manufacturerEntity);
            var manufacturerCreate = _mapper.Map<ManufacturerDto>(manufacturerEntity);
            return CreatedAtRoute("GetById", new { id = manufacturerCreate.Id }, manufacturerCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, ManufacturerUpdateDto manufacturer)
        {
            var manufacturerEntity = await _repository.Manufacturer.GetByIdAsync(id);
            manufacturerEntity = _mapper.Map(manufacturer, manufacturerEntity);
            await _repository.Manufacturer.UpdateAsync(manufacturerEntity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var manufacturerEntity = await _repository.Manufacturer.GetByIdAsync(id);
            await _repository.Manufacturer.DeleteAsync(manufacturerEntity);
            return NoContent();
        }
    }
}