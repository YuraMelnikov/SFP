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
    [ServiceFilter(typeof(ModelNullAttribute))]
    [ServiceFilter(typeof(ModelValidationAttribute))]
    [Route("api/livery")]
    [ApiController]
    public class LiveryController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public LiveryController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var liverys = await _repository.Livery.GetAll();
            var liverysResult = _mapper.Map<IEnumerable<LiveryDto>>(liverys);
            return Ok(liverysResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var livery = await _repository.Livery.GetById(id);
            var liveryResult = _mapper.Map<LiveryDto>(livery);
            return Ok(liveryResult);
        }

        [HttpPost]
        public async Task<IActionResult> Create(LiveryCreateDto livery)
        {
            var liveryEntity = _mapper.Map<Livery>(livery);
            await _repository.Livery.Create(liveryEntity);
            await _repository.SaveAsync();
            var liveryCreate = _mapper.Map<LiveryDto>(liveryEntity);
            return CreatedAtRoute("LiveryById", new { id = liveryCreate.Id }, liveryCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, LiveryUpdateDto livery)
        {
            var liveryEntity = await _repository.Livery.GetById(id);
            liveryEntity = _mapper.Map(livery, liveryEntity);
            _repository.Livery.Update(liveryEntity);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var liveryEntity = await _repository.Livery.GetById(id);
            _repository.Livery.Delete(liveryEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
        
    }
}