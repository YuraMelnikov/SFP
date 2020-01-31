using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using AutoMapper;
using SFPrj.ActionFilters;
using Entities.DataTransferObjects;
using Entities.Models;

namespace SFPrj.Controllers
{
    [ServiceFilter(typeof(ModelValidationAttribute))]
    [ServiceFilter(typeof(ModelNullAttribute))]
    [Route("api/gpresult")]
    [ApiController]
    public class GPResultController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public GPResultController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var results = await _repository.GPResult.GetAllAsync();
            var resultsResult = _mapper.Map<IEnumerable<GPResultDto>>(results);
            return Ok(resultsResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _repository.GPResult.GetByIdAsync(id);
            var resultResult = _mapper.Map<GPResultDto>(result);
            return Ok(resultResult);
        }

        [HttpPost]
        public async Task<IActionResult> Post(GPResultCreateDto result)
        {
            var resultEntity = _mapper.Map<GPResult>(result);
            await _repository.GPResult.AddAsync(resultEntity);
            var resultCreate = _mapper.Map<GPResultDto>(resultEntity);
            return CreatedAtRoute("ResultGetById", new { id = resultCreate.Id}, resultCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, GPResultUpdateDto result)
        {
            var resultEntity = await _repository.GPResult.GetByIdAsync(id);
            resultEntity = _mapper.Map(result, resultEntity);
            await _repository.GPResult.UpdateAsync(resultEntity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var resultEntity = await _repository.GPResult.GetByIdAsync(id);
            await _repository.GPResult.DeleteAsync(resultEntity);
            return NoContent();
        }
    }
}