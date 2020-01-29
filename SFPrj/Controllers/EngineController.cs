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
    [ServiceFilter(typeof(ModelNullAttribute))]
    [Route("api/engine")]
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
        public async Task<IActionResult> GetAll()
        {
            var engines = await _repository.Engine.GetAll();
            var enginesResult = _mapper.Map<IEnumerable<EngineDto>>(engines);
            return Ok(enginesResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var engine = await _repository.Engine.GetById(id);
            var engineResult = _mapper.Map<EngineDto>(engine);
            return Ok(engineResult);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EngineCreateDto engine)
        {
            var engineEntity = _mapper.Map<Engine>(engine);
            await _repository.Engine.Create(engineEntity);
            await _repository.SaveAsync();
            var engineCreate = _mapper.Map<EngineDto>(engineEntity);
            return CreatedAtRoute("EngineById", new { id = engineCreate.Id}, engineCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, EngineUpdateDto engine)
        {
            var engineEntity = await _repository.Engine.GetById(id);
            engineEntity = _mapper.Map(engine, engineEntity);
            _repository.Engine.Update(engineEntity);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var engineEntity = await _repository.Engine.GetById(id);
            _repository.Engine.Delete(engineEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}