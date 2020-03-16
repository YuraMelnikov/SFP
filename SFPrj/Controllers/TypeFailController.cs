using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using System.Collections.Generic;

namespace SFPrj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeFailController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public TypeFailController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTypeFail()
        {
            var type = await _repository.TypeFail.GetAllTypeFailAsync(trackChanges: false);
            var typeDTO = _mapper.Map<IEnumerable<TypeFailDto>>(type);
            return Ok(typeDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTypeFail(Guid id)
        {
            var type = await _repository.TypeFail.GetTypeFailAsync(id, trackChanges: false);
            if (type == null)
                return NotFound();
            else
            {
                var typeDTO = _mapper.Map<TypeFailDto>(type);
                return Ok(typeDTO);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTypeFail([FromBody]TypeFailCreateDto type)
        {
            if (type == null)
                return BadRequest("TypeFailDto object is null.");
            else
            {
                var typeEntity = _mapper.Map<TypeFail>(type);
                _repository.TypeFail.CreateTypeFail(typeEntity);
                await _repository.SaveAsync();
                var typeToReturn = _mapper.Map<TypeFailDto>(typeEntity);
                return CreatedAtRoute("GetTypeFail", new { id = typeToReturn.Id }, typeToReturn);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeFail(Guid id)
        {
            var type = await _repository.TypeFail.GetTypeFailAsync(id, trackChanges: false);
            if (type == null)
            {
                return NotFound();
            }
            _repository.TypeFail.DeleteTypeFail(type);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTypeFail([FromBody] TypeFailDto type)
        {
            if (type == null)
                return BadRequest("TypeFailDto object is null");
            var typeEntity = await _repository.TypeFail.GetTypeFailAsync(type.Id, trackChanges: true);
            if (typeEntity == null)
                return NotFound();
            _mapper.Map(type, typeEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}