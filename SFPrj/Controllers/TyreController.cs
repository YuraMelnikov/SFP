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
        public async Task<IActionResult> GetAll()
        {
            var tyres = await _repository.Tyre.GetAll();
            var tyresResult = _mapper.Map<IEnumerable<TyreDto>>(tyres);
            return Ok(tyresResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var tyre = await _repository.Tyre.GetById(id);
            var tyreResult = _mapper.Map<TyreDto>(tyre);
            return Ok(tyreResult);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TyreCreateDto tyre)
        {
            var tyreEntity = _mapper.Map<Tyre>(tyre);
            await _repository.Tyre.Create(tyreEntity);
            await _repository.SaveAsync();
            var tyreCreate = _mapper.Map<TyreDto>(tyreEntity);
            return CreatedAtRoute("GetById", new { id = tyreCreate.Id }, tyreCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id,  TyreUpdateDto tyre)
        {
            var tyreEntity = await _repository.Tyre.GetById(id);
            tyreEntity = _mapper.Map(tyre, tyreEntity);
            _repository.Tyre.Update(tyreEntity);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var tyreEntity = await _repository.Tyre.GetById(id);
            _repository.Tyre.Delete(tyreEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}