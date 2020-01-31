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
    [Route("api/typefail")]
    [ApiController]
    public class TypeFailController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public TypeFailController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var types = await _repository.TypeFail.GetAllAsync();
            var typesResult = _mapper.Map<IEnumerable<TypeFailDto>>(types);
            return Ok(typesResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var type = await _repository.TypeFail.GetByIdAsync(id);
            var typeResult = _mapper.Map<TypeFailDto>(type);
            return Ok(typeResult);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TypeFailCreateDto type)
        {
            var typeEntity = _mapper.Map<TypeFail>(type);
            await _repository.TypeFail.AddAsync(typeEntity);
            var typeCreate = _mapper.Map<TypeFailDto>(typeEntity);
            return CreatedAtRoute("GetById", new { id = typeCreate.Id }, typeCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id,  TypeFailUpdateDto type)
        {
            var typeEntity = await _repository.TypeFail.GetByIdAsync(id);
            typeEntity = _mapper.Map(type, typeEntity);
            await _repository.TypeFail.UpdateAsync(typeEntity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var typeEntity = await _repository.TypeFail.GetByIdAsync(id);
            await _repository.TypeFail.DeleteAsync(typeEntity);
            return NoContent();
        }
    }
}