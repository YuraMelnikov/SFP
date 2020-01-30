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
        public async Task<IActionResult> GetAll()
        {
            var types = await _repository.TypeFail.GetAll();
            var typesResult = _mapper.Map<IEnumerable<TypeFailDto>>(types);
            return Ok(typesResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var type = await _repository.TypeFail.GetById(id);
            var typeResult = _mapper.Map<TypeFailDto>(type);
            return Ok(typeResult);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TypeFailCreateDto type)
        {
            var typeEntity = _mapper.Map<TypeFail>(type);
            await _repository.TypeFail.Create(typeEntity);
            await _repository.SaveAsync();
            var typeCreate = _mapper.Map<TypeFailDto>(typeEntity);
            return CreatedAtRoute("GetById", new { id = typeCreate.Id }, typeCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id,  TypeFailUpdateDto type)
        {
            var typeEntity = await _repository.TypeFail.GetById(id);
            typeEntity = _mapper.Map(type, typeEntity);
            _repository.TypeFail.Update(typeEntity);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var typeEntity = await _repository.TypeFail.GetById(id);
            _repository.TypeFail.Delete(typeEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}