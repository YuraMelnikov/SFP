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
        public async Task<IActionResult> GetAll()
        {
            var types = await _repository.TypeDNQ.GetAll();
            var typesResult = _mapper.Map<IEnumerable<TypeDNQDto>>(types);
            return Ok(typesResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var type = await _repository.TypeDNQ.GetById(id);
            var typeResult = _mapper.Map<TypeDNQDto>(type);
            return Ok(typeResult);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TypeDNQCreateDto type)
        {
            var typeEntity = _mapper.Map<TypeDNQ>(type);
            await _repository.TypeDNQ.Create(typeEntity);
            await _repository.SaveAsync();
            var typeCreate = _mapper.Map<TypeDNQDto>(typeEntity);
            return CreatedAtRoute("GetById", new { id = typeCreate.Id }, typeCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id,  TypeDNQUpdateDto type)
        {
            var typeEntity = await _repository.TypeDNQ.GetById(id);
            typeEntity = _mapper.Map(type, typeEntity);
            _repository.TypeDNQ.Update(typeEntity);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var typeEntity = await _repository.TypeDNQ.GetById(id);
            _repository.TypeDNQ.Delete(typeEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}