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
    [Route("api/typefinish")]
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
        public async Task<IActionResult> GetAll()
        {
            var types = await _repository.TypeFinish.GetAll();
            var typesResult = _mapper.Map<IEnumerable<TypeFinishDto>>(types);
            return Ok(typesResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var type = await _repository.TypeFinish.GetById(id);
            var typeResult = _mapper.Map<TypeFinishDto>(type);
            return Ok(typeResult);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TypeFinishCreateDto type)
        {
            var typeEntity = _mapper.Map<TypeFinish>(type);
            await _repository.TypeFinish.Create(typeEntity);
            await _repository.SaveAsync();
            var typeCreate = _mapper.Map<TypeFinishDto>(typeEntity);
            return CreatedAtRoute("GetById", new { id = typeCreate.Id }, typeCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, TypeFinishUpdateDto type)
        {
            var typeEntity = await _repository.TypeFinish.GetById(id);
            typeEntity = _mapper.Map(type, typeEntity);
            _repository.TypeFinish.Update(typeEntity);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var typeEntity = await _repository.TypeFinish.GetById(id);
            _repository.TypeFinish.Delete(typeEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}