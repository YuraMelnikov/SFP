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
    [Route("api/typednq")]
    [ApiController]
    public class TypeDNQController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public TypeDNQController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTypeDNQ()
        {
            var type = await _repository.TypeDNQ.GetAllTypeDNQAsync(trackChanges: false);
            var typeDTO = _mapper.Map<IEnumerable<TypeDNQDto>>(type);
            return Ok(typeDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTypeDNQ(Guid id)
        {
            var type = await _repository.TypeDNQ.GetTypeDNQAsync(id, trackChanges: false);
            if (type == null)
                return NotFound();
            else
            {
                var typeDTO = _mapper.Map<TypeDNQDto>(type);
                return Ok(typeDTO);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTypeDNQ([FromBody]TypeDNQCreateDto type)
        {
            if (type == null)
                return BadRequest("TypeDNQDto object is null.");
            else
            {
                var typeEntity = _mapper.Map<TypeDNQ>(type);
                _repository.TypeDNQ.CreateTypeDNQ(typeEntity);
                await _repository.SaveAsync();
                var typeToReturn = _mapper.Map<TypeDNQDto>(typeEntity);
                return CreatedAtRoute("GetTypeDNQ", new { id = typeToReturn.Id }, typeToReturn);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeDNQ(Guid id)
        {
            var type = await _repository.TypeDNQ.GetTypeDNQAsync(id, trackChanges: false);
            if (type == null)
            {
                return NotFound();
            }
            _repository.TypeDNQ.DeleteTypeDNQ(type);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTypeDNQ([FromBody] TypeDNQDto type)
        {
            if (type == null)
                return BadRequest("TypeDNQDto object is null");
            var typeEntity = await _repository.TypeDNQ.GetTypeDNQAsync(type.Id, trackChanges: true);
            if (typeEntity == null)
                return NotFound();
            _mapper.Map(type, typeEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}