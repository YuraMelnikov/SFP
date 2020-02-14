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
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ModelValidationAttribute))]
    public class SeasonController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public SeasonController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var seasons = await _repository.Season.GetAllAsync();
            var seasonsResult = _mapper.Map<IEnumerable<SeasonDto>>(seasons);
            return Ok(seasonsResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var season = await _repository.Season.GetByIdAsync(id);
            var seasonResult = _mapper.Map<SeasonDto>(season);
            return Ok(seasonResult);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SeasonCreateDto season)
        {
            var seasonEntity = _mapper.Map<Season>(season);
            await _repository.Season.AddAsync(seasonEntity);
            var seasonCreate = _mapper.Map<SeasonDto>(seasonEntity);
            return CreatedAtRoute("GetById", new { id = seasonCreate.Id }, seasonCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, LiveryUpdateDto livery)
        {
            var seasonEntity = await _repository.Season.GetByIdAsync(id);
            seasonEntity = _mapper.Map(livery, seasonEntity);
            await _repository.Season.UpdateAsync(seasonEntity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var seasonEntity = await _repository.Season.GetByIdAsync(id);
            await _repository.Season.DeleteAsync(seasonEntity);
            return NoContent();
        }
    }
}