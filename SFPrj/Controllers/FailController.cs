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
    public class FailController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public FailController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var fails = await _repository.Fail.GetAllAsync();
            var failsResult = _mapper.Map<IEnumerable<FailDto>>(fails);
            return Ok(failsResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var fail = await _repository.Fail.GetByIdAsync(id);
            var failResult = _mapper.Map<FailDto>(fail);
            return Ok(failResult);
        }

        [HttpPost]
        public async Task<IActionResult> Post(FailCreateDto fail)
        {
            var failEntity = _mapper.Map<Fail>(fail);
            await _repository.Fail.AddAsync(failEntity);
            var failCreate = _mapper.Map<FailDto>(failEntity);
            return CreatedAtRoute("FailById", new { id = failCreate}, failCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, FailCreateDto fail)
        {
            var failEntity = await _repository.Fail.GetByIdAsync(id);
            failEntity = _mapper.Map(fail, failEntity);
            await _repository.Fail.UpdateAsync(failEntity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var failEntity = await _repository.Fail.GetByIdAsync(id);
            await _repository.Fail.DeleteAsync(failEntity);
            return NoContent();
        }
    }
}