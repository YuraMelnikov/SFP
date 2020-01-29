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
        public async Task<IActionResult> GetAll()
        {
            var dnqList = await _repository.DNQ.GetAll();
            var dnqListResult = _mapper.Map<IEnumerable<DNQDto>>(dnqList);
            return Ok(dnqListResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dnq = await _repository.DNQ.GetById(id);
            var dnqResult = _mapper.Map<DNQDto>(dnq);
            return Ok(dnqResult);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DNQCreateDto dnq)
        {
            var dnqEntity = _mapper.Map<DNQ>(dnq);
            await _repository.DNQ.Create(dnqEntity);
            await _repository.SaveAsync();
            var dnqCreate = _mapper.Map<DNQDto>(dnqEntity);
            return CreatedAtRoute("DNQById", new { id = dnqCreate.Id }, dnqCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, DNQUpdateDto dnq)
        {
            var dnqEntity = await _repository.DNQ.GetById(id);
            dnqEntity = _mapper.Map(dnq, dnqEntity);
            _repository.DNQ.Update(dnqEntity);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var dnqEntity = await _repository.DNQ.GetById(id);
            _repository.DNQ.Delete(dnqEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}