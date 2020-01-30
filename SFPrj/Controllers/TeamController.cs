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
        public async Task<IActionResult> GetAll()
        {
            var teams = await _repository.Team.GetAll();
            var teamsResult = _mapper.Map<IEnumerable<TeamDto>>(teams);
            return Ok(teamsResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var team = await _repository.Team.GetById(id);
            var teamResult = _mapper.Map<TeamDto>(team);
            return Ok(teamResult);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeamCreateDto team)
        {
            var teamEntity = _mapper.Map<Team>(team);
            await _repository.Team.Create(teamEntity);
            await _repository.SaveAsync();
            var liveryCreate = _mapper.Map<TeamDto>(teamEntity);
            return CreatedAtRoute("GetById", new { id = liveryCreate.Id }, liveryCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, TeamUpdateDto team)
        {
            var teamEntity = await _repository.Team.GetById(id);
            teamEntity = _mapper.Map(team, teamEntity);
            _repository.Team.Update(teamEntity);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var teamEntity = await _repository.Team.GetById(id);
            _repository.Team.Delete(teamEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}