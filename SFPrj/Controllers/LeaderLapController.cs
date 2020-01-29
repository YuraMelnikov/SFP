using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
    [Route("api/leaderlap")]
    [ApiController]
    public class LeaderLapController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public LeaderLapController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var leaders = await _repository.LeaderLap.GetAll();
            var leadersResult = _mapper.Map<IEnumerable<LeaderLapDto>>(leaders);
            return Ok(leadersResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var leader = await _repository.LeaderLap.GetById(id);
            var leaderResult = _mapper.Map<LeaderLapDto>(leader);
            return Ok(leaderResult);
        }

        [HttpPost]
        public async Task<IActionResult> Create(LeaderLapCreateDto leader)
        {
            var leaderEntity = _mapper.Map<LeaderLap>(leader);
            await _repository.LeaderLap.Create(leaderEntity);
            await _repository.SaveAsync();
            var leaderCreate = _mapper.Map<LeaderLapDto>(leaderEntity);
            return CreatedAtRoute("LeaderLapById", new { id = leaderCreate.Id }, leaderCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, LeaderLapUpdateDto leader)
        {
            var leaderEntry = await _repository.LeaderLap.GetById(id);
            leaderEntry = _mapper.Map(leader, leaderEntry);
            _repository.LeaderLap.Update(leaderEntry);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var leaderEntry = await _repository.LeaderLap.GetById(id);
            _repository.LeaderLap.Delete(leaderEntry);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}