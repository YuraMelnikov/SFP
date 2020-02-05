using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using AutoMapper;
using SFPrj.ActionFilters;
using Entities.DataTransferObjects;
using Entities.Models;
using System.Collections.Generic;

namespace SFPrj.Controllers
{
    [ServiceFilter(typeof(ModelValidationAttribute))]
    [Route("api/typecalculate")]
    [ApiController]
    public class TypeCalculateController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public TypeCalculateController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var typeCalculates = await _repository.TypeCalculate.GetAllAsync();
            var typeCalculatesResult = _mapper.Map<IEnumerable<TypeCalculateDto>>(typeCalculates);
            return Ok(typeCalculatesResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var type = await _repository.TypeCalculate.GetByIdAsync(id);
            var typeResult = _mapper.Map<TypeCalculateDto>(type);
            return Ok(typeResult);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TypeCalculateCreateDto typeCalculate)
        {
            var typeCalculateEntity = _mapper.Map<TypeCalculate>(typeCalculate);
            await _repository.TypeCalculate.AddAsync(typeCalculateEntity);
            var typeCalculateCreate = _mapper.Map<TypeCalculateDto>(typeCalculateEntity);
            return CreatedAtRoute("GetById", new { id = typeCalculateCreate.Id }, typeCalculateCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id,  TypeCalculateUpdateDto typeCalculate)
        {
            var typeCalculateEntity = await _repository.TypeCalculate.GetByIdAsync(id);
            typeCalculateEntity = _mapper.Map(typeCalculate, typeCalculateEntity);
            await _repository.TypeCalculate.UpdateAsync(typeCalculateEntity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var typeCalculateEntity = await _repository.TypeCalculate.GetByIdAsync(id);
            await _repository.TypeCalculate.DeleteAsync(typeCalculateEntity);
            return NoContent();
        }
    }
}