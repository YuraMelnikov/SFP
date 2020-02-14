using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using SFPrj.ActionFilters;

namespace SFPrj.Controllers
{
    [ServiceFilter(typeof(ModelValidationAttribute))]
    [Route("api/[controller]")]
    [ApiController]
    public class EngineController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public EngineController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var engines = await _repository.Engine.GetAllAsync();
            var enginesResult = _mapper.Map<IEnumerable<EngineDto>>(engines);
            return Ok(enginesResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var engine = await _repository.Engine.GetByIdAsync(id);
            var engineResult = _mapper.Map<EngineDto>(engine);
            return Ok(engineResult);
        }

        [HttpPost]
        public async Task<IActionResult> Post(EngineCreateDto engine)
        {
            var engineEntity = _mapper.Map<Engine>(engine);
            await _repository.Engine.AddAsync(engineEntity);
            var engineCreate = _mapper.Map<EngineDto>(engineEntity);
            return CreatedAtRoute("EngineById", new { id = engineCreate.Id}, engineCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, EngineUpdateDto engine)
        {
            var engineEntity = await _repository.Engine.GetByIdAsync(id);
            engineEntity = _mapper.Map(engine, engineEntity);
            await _repository.Engine.UpdateAsync(engineEntity);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var engineEntity = await _repository.Engine.GetByIdAsync(id);
            await _repository.Engine.DeleteAsync(engineEntity);
            return NoContent();
        }
    }
}