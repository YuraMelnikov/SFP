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
        public async Task<IActionResult> GetAll()
        {
            var manufacturers = await _repository.Manufacturer.GetAll();
            var manufacturersResult = _mapper.Map<IEnumerable<ManufacturerDto>>(manufacturers);
            return Ok(manufacturersResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var manufacturer = await _repository.Manufacturer.GetById(id);
            var manufacturerResult = _mapper.Map<IEnumerable<ManufacturerDto>>(manufacturer);
            return Ok(manufacturerResult);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ManufacturerCreateDto manufacturer)
        {
            var manufacturerEntity = _mapper.Map<Manufacturer>(manufacturer);
            await _repository.Manufacturer.Create(manufacturerEntity);
            await _repository.SaveAsync();
            var manufacturerCreate = _mapper.Map<ManufacturerDto>(manufacturerEntity);
            return CreatedAtRoute("GetById", new { id = manufacturerCreate.Id }, manufacturerCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, ManufacturerUpdateDto manufacturer)
        {
            var manufacturerEntity = await _repository.Manufacturer.GetById(id);
            manufacturerEntity = _mapper.Map(manufacturer, manufacturerEntity);
            _repository.Manufacturer.Update(manufacturerEntity);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var manufacturerEntity = await _repository.Manufacturer.GetById(id);
            _repository.Manufacturer.Delete(manufacturerEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}