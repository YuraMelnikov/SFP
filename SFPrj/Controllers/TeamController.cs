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
    [Route("api/team")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public TeamController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var teams = await _repository.Team.GetAllAsync();
            var teamsResult = _mapper.Map<IEnumerable<TeamDto>>(teams);
            return Ok(teamsResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var team = await _repository.Team.GetByIdAsync(id);
            var teamResult = _mapper.Map<TeamDto>(team);
            return Ok(teamResult);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TeamCreateDto team)
        {
            var teamEntity = _mapper.Map<Team>(team);
            await _repository.Team.AddAsync(teamEntity);
            var liveryCreate = _mapper.Map<TeamDto>(teamEntity);
            return CreatedAtRoute("GetById", new { id = liveryCreate.Id }, liveryCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, TeamUpdateDto team)
        {
            var teamEntity = await _repository.Team.GetByIdAsync(id);
            teamEntity = _mapper.Map(team, teamEntity);
            await _repository.Team.UpdateAsync(teamEntity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var teamEntity = await _repository.Team.GetByIdAsync(id);
            await _repository.Team.DeleteAsync(teamEntity);
            return NoContent();
        }
    }
}