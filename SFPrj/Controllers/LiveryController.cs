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
    [Route("api/[controller]")]
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
        public async Task<IActionResult> Get()
        {
            var liverys = await _repository.Livery.GetAllAsync();
            var liverysResult = _mapper.Map<IEnumerable<LiveryDto>>(liverys);
            return Ok(liverysResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var livery = await _repository.Livery.GetByIdAsync(id);
            var liveryResult = _mapper.Map<LiveryDto>(livery);
            return Ok(liveryResult);
        }

        [HttpPost]
        public async Task<IActionResult> Post(LiveryCreateDto livery)
        {
            var liveryEntity = _mapper.Map<Livery>(livery);
            await _repository.Livery.AddAsync(liveryEntity);
            var liveryCreate = _mapper.Map<LiveryDto>(liveryEntity);
            return CreatedAtRoute("LiveryById", new { id = liveryCreate.Id }, liveryCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, LiveryUpdateDto livery)
        {
            var liveryEntity = await _repository.Livery.GetByIdAsync(id);
            liveryEntity = _mapper.Map(livery, liveryEntity);
            await _repository.Livery.UpdateAsync(liveryEntity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var liveryEntity = await _repository.Livery.GetByIdAsync(id);
            await _repository.Livery.DeleteAsync(liveryEntity);
            return NoContent();
        }
    }
}