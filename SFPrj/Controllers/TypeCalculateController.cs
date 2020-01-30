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
    [ServiceFilter(typeof(ModelNullAttribute))]
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
        public async Task<IActionResult> GetAll()
        {
            var typeCalculates = await _repository.TypeCalculate.GetAll();
            var typeCalculatesResult = _mapper.Map<IEnumerable<TypeCalculateDto>>(typeCalculates);
            return Ok(typeCalculatesResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var type = await _repository.TypeCalculate.GetById(id);
            var typeResult = _mapper.Map<TypeCalculateDto>(type);
            return Ok(typeResult);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TypeCalculateCreateDto typeCalculate)
        {
            var typeCalculateEntity = _mapper.Map<TypeCalculate>(typeCalculate);
            await _repository.TypeCalculate.Create(typeCalculateEntity);
            await _repository.SaveAsync();
            var typeCalculateCreate = _mapper.Map<TypeCalculateDto>(typeCalculateEntity);
            return CreatedAtRoute("GetById", new { id = typeCalculateCreate.Id }, typeCalculateCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id,  TypeCalculateUpdateDto typeCalculate)
        {
            var typeCalculateEntity = await _repository.TypeCalculate.GetById(id);
            typeCalculateEntity = _mapper.Map(typeCalculate, typeCalculateEntity);
            _repository.TypeCalculate.Update(typeCalculateEntity);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var typeCalculateEntity = await _repository.TypeCalculate.GetById(id);
            _repository.TypeCalculate.Delete(typeCalculateEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}