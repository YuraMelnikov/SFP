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
    [Route("api/teamname")]
    [ApiController]
    public class TeamNameController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public TeamNameController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var teamNames = await _repository.TeamName.GetAllAsync();
            var teamNameResult = _mapper.Map<IEnumerable<TeamNameDto>>(teamNames);
            return Ok(teamNameResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var teamName = await _repository.TeamName.GetByIdAsync(id);
            var teamNameResult = _mapper.Map<TeamNameDto>(teamName);
            return Ok(teamNameResult);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TeamNameCreateDto team)
        {
            var teamNameEntity = _mapper.Map<TeamName>(team);
            await _repository.TeamName.AddAsync(teamNameEntity);
            var teamNameCreate = _mapper.Map<TeamNameDto>(teamNameEntity);
            return CreatedAtRoute("GetById", new { id = teamNameCreate.Id }, teamNameCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, TeamNameUpdateDto team)
        {
            var teamNameEntity = await _repository.TeamName.GetByIdAsync(id);
            teamNameEntity = _mapper.Map(team, teamNameEntity);
            await _repository.TeamName.UpdateAsync(teamNameEntity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var teamNameEntity = await _repository.TeamName.GetByIdAsync(id);
            await _repository.TeamName.DeleteAsync(teamNameEntity);
            return NoContent();
        }
    }
}