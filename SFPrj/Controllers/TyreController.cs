using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using AutoMapper;
using SFPrj.ActionFilters;
using Entities.DataTransferObjects;
using Entities.Models;
using System.Collections.Generic;

namespace SFPrj.Controllers
{
    [ServiceFilter(typeof(ModelNullAttribute))]
    [ServiceFilter(typeof(ModelValidationAttribute))]
    [Route("api/tyre")]
    [ApiController]
    public class TyreController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public TyreController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tyres = await _repository.Tyre.GetAllAsync();
            var tyresResult = _mapper.Map<IEnumerable<TyreDto>>(tyres);
            return Ok(tyresResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var tyre = await _repository.Tyre.GetByIdAsync(id);
            var tyreResult = _mapper.Map<TyreDto>(tyre);
            return Ok(tyreResult);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TyreCreateDto tyre)
        {
            var tyreEntity = _mapper.Map<Tyre>(tyre);
            await _repository.Tyre.AddAsync(tyreEntity);
            var tyreCreate = _mapper.Map<TyreDto>(tyreEntity);
            return CreatedAtRoute("GetById", new { id = tyreCreate.Id }, tyreCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id,  TyreUpdateDto tyre)
        {
            var tyreEntity = await _repository.Tyre.GetByIdAsync(id);
            tyreEntity = _mapper.Map(tyre, tyreEntity);
            await _repository.Tyre.UpdateAsync(tyreEntity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var tyreEntity = await _repository.Tyre.GetByIdAsync(id);
            await _repository.Tyre.DeleteAsync(tyreEntity);
            return NoContent();
        }
    }
}