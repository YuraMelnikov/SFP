using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using AutoMapper;
using SFPrj.ActionFilters;

namespace SFPrj.Controllers
{
    [ServiceFilter(typeof(ModelValidationAttribute))]
    [ServiceFilter(typeof(ModelNullAttribute))]
    [Route("api/dnq")]
    [ApiController]
    public class DNQController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public DNQController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var dnqList = await _repository.DNQ.GetAllAsync();
            var dnqListResult = _mapper.Map<IEnumerable<DNQDto>>(dnqList);
            return Ok(dnqListResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dnq = await _repository.DNQ.GetByIdAsync(id);
            var dnqResult = _mapper.Map<DNQDto>(dnq);
            return Ok(dnqResult);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DNQCreateDto dnq)
        {
            var dnqEntity = _mapper.Map<DNQ>(dnq);
            await _repository.DNQ.AddAsync(dnqEntity);
            var dnqCreate = _mapper.Map<DNQDto>(dnqEntity);
            return CreatedAtRoute("DNQById", new { id = dnqCreate.Id }, dnqCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, DNQUpdateDto dnq)
        {
            var dnqEntity = await _repository.DNQ.GetByIdAsync(id);
            dnqEntity = _mapper.Map(dnq, dnqEntity);
            await _repository.DNQ.UpdateAsync(dnqEntity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var dnqEntity = await _repository.DNQ.GetByIdAsync(id);
            await _repository.DNQ.DeleteAsync(dnqEntity);
            return NoContent();
        }
    }
}