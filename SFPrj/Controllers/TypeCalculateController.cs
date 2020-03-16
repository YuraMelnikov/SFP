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
    public class TypeCalculateController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public TypeCalculateController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTypeCalculate()
        {
            var type = await _repository.TypeCalculate.GetAllTypeCalculateAsync(trackChanges: false);
            var typeDTO = _mapper.Map<IEnumerable<TypeCalculateDto>>(type);
            return Ok(typeDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTypeCalculate(Guid id)
        {
            var type = await _repository.TypeCalculate.GetTypeCalculateAsync(id, trackChanges: false);
            if (type == null)
                return NotFound();
            else
            {
                var typeDTO = _mapper.Map<TypeCalculateDto>(type);
                return Ok(typeDTO);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTypeCalculate([FromBody]TypeCalculateCreateDto type)
        {
            if (type == null)
                return BadRequest("TypeCalculateDto object is null.");
            else
            {
                var typeEntity = _mapper.Map<TypeCalculate>(type);
                _repository.TypeCalculate.CreateTypeCalculate(typeEntity);
                await _repository.SaveAsync();
                var typeToReturn = _mapper.Map<TypeCalculateDto>(typeEntity);
                return CreatedAtRoute("GetTypeCalculate", new { id = typeToReturn.Id }, typeToReturn);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeCalculate(Guid id)
        {
            var type = await _repository.TypeCalculate.GetTypeCalculateAsync(id, trackChanges: false);
            if (type == null)
            {
                return NotFound();
            }
            _repository.TypeCalculate.DeleteTypeCalculate(type);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTypeCalculate([FromBody] TypeCalculateDto type)
        {
            if (type == null)
                return BadRequest("TypeCalculateDto object is null");
            var typeEntity = await _repository.TypeCalculate.GetTypeCalculateAsync(type.Id, trackChanges: true);
            if (typeEntity == null)
                return NotFound();
            _mapper.Map(type, typeEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}