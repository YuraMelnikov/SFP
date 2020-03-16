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
    public class TypeFinishController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public TypeFinishController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTypeFinish()
        {
            var type = await _repository.TypeFinish.GetAllTypeFinishAsync(trackChanges: false);
            var typeDTO = _mapper.Map<IEnumerable<TypeFinishDto>>(type);
            return Ok(typeDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTypeFinish(Guid id)
        {
            var type = await _repository.TypeFinish.GetTypeFinishAsync(id, trackChanges: false);
            if (type == null)
                return NotFound();
            else
            {
                var typeDTO = _mapper.Map<TypeFinishDto>(type);
                return Ok(typeDTO);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTypeFinish([FromBody]TypeFinishCreateDto type)
        {
            if (type == null)
                return BadRequest("TypeFinishDto object is null.");
            else
            {
                var typeEntity = _mapper.Map<TypeFinish>(type);
                _repository.TypeFinish.CreateTypeFinish(typeEntity);
                await _repository.SaveAsync();
                var typeToReturn = _mapper.Map<TypeFinishDto>(typeEntity);
                return CreatedAtRoute("GetTypeFinish", new { id = typeToReturn.Id }, typeToReturn);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeFinish(Guid id)
        {
            var type = await _repository.TypeFinish.GetTypeFinishAsync(id, trackChanges: false);
            if (type == null)
            {
                return NotFound();
            }
            _repository.TypeFinish.DeleteTypeFinish(type);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTypeFinish([FromBody] TypeFinishDto type)
        {
            if (type == null)
                return BadRequest("TypeFinishDto object is null");
            var typeEntity = await _repository.TypeFinish.GetTypeFinishAsync(type.Id, trackChanges: true);
            if (typeEntity == null)
                return NotFound();
            _mapper.Map(type, typeEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}