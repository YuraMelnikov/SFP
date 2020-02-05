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
    [Route("api/typednq")]
    [ApiController]
    public class TypeDNQController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public TypeDNQController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var types = await _repository.TypeDNQ.GetAllAsync();
            var typesResult = _mapper.Map<IEnumerable<TypeDNQDto>>(types);
            return Ok(typesResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var type = await _repository.TypeDNQ.GetByIdAsync(id);
            var typeResult = _mapper.Map<TypeDNQDto>(type);
            return Ok(typeResult);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TypeDNQCreateDto type)
        {
            var typeEntity = _mapper.Map<TypeDNQ>(type);
            await _repository.TypeDNQ.AddAsync(typeEntity);
            var typeCreate = _mapper.Map<TypeDNQDto>(typeEntity);
            return CreatedAtRoute("GetById", new { id = typeCreate.Id }, typeCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id,  TypeDNQUpdateDto type)
        {
            var typeEntity = await _repository.TypeDNQ.GetByIdAsync(id);
            typeEntity = _mapper.Map(type, typeEntity);
            await _repository.TypeDNQ.UpdateAsync(typeEntity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var typeEntity = await _repository.TypeDNQ.GetByIdAsync(id);
            await _repository.TypeDNQ.DeleteAsync(typeEntity);
            return NoContent();
        }
    }
}