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
    [Route("api/[controller]")]
    [ApiController]
    public class TypeFinishController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public TypeFinishController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var types = await _repository.TypeFinish.GetAllAsync();
            var typesResult = _mapper.Map<IEnumerable<TypeFinishDto>>(types);
            return Ok(typesResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var type = await _repository.TypeFinish.GetByIdAsync(id);
            var typeResult = _mapper.Map<TypeFinishDto>(type);
            return Ok(typeResult);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TypeFinishCreateDto type)
        {
            var typeEntity = _mapper.Map<TypeFinish>(type);
            await _repository.TypeFinish.AddAsync(typeEntity);
            await _repository.SaveAsync();
            var typeCreate = _mapper.Map<TypeFinishDto>(typeEntity);
            return CreatedAtRoute("GetById", new { id = typeCreate.Id }, typeCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, TypeFinishUpdateDto type)
        {
            var typeEntity = await _repository.TypeFinish.GetByIdAsync(id);
            typeEntity = _mapper.Map(type, typeEntity);
            await _repository.TypeFinish.UpdateAsync(typeEntity);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var typeEntity = await _repository.TypeFinish.GetByIdAsync(id);
            await _repository.TypeFinish.DeleteAsync(typeEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}