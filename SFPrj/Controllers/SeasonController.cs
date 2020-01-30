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
    [Route("api/season")]
    [ApiController]
    [ServiceFilter(typeof(ModelNullAttribute))]
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
        public async Task<IActionResult> GetAll()
        {
            var seasons = await _repository.Season.GetAll();
            var seasonsResult = _mapper.Map<IEnumerable<SeasonDto>>(seasons);
            return Ok(seasonsResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var season = await _repository.Season.GetById(id);
            var seasonResult = _mapper.Map<SeasonDto>(season);
            return Ok(seasonResult);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SeasonCreateDto season)
        {
            var seasonEntity = _mapper.Map<Season>(season);
            await _repository.Season.Create(seasonEntity);
            await _repository.SaveAsync();
            var seasonCreate = _mapper.Map<SeasonDto>(seasonEntity);
            return CreatedAtRoute("GetById", new { id = seasonCreate.Id }, seasonCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, LiveryUpdateDto livery)
        {
            var seasonEntity = await _repository.Season.GetById(id);
            seasonEntity = _mapper.Map(livery, seasonEntity);
            _repository.Season.Update(seasonEntity);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var seasonEntity = await _repository.Season.GetById(id);
            _repository.Season.Delete(seasonEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}