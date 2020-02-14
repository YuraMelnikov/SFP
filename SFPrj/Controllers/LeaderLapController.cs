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
    [ServiceFilter(typeof(ModelValidationAttribute))]
    [Route("api/[controller]")]
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
        public async Task<IActionResult> Get()
        {
            var leaders = await _repository.LeaderLap.GetAllAsync();
            var leadersResult = _mapper.Map<IEnumerable<LeaderLapDto>>(leaders);
            return Ok(leadersResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var leader = await _repository.LeaderLap.GetByIdAsync(id);
            var leaderResult = _mapper.Map<LeaderLapDto>(leader);
            return Ok(leaderResult);
        }

        [HttpPost]
        public async Task<IActionResult> Post(LeaderLapCreateDto leader)
        {
            var leaderEntity = _mapper.Map<LeaderLap>(leader);
            await _repository.LeaderLap.AddAsync(leaderEntity);
            var leaderCreate = _mapper.Map<LeaderLapDto>(leaderEntity);
            return CreatedAtRoute("LeaderLapById", new { id = leaderCreate.Id }, leaderCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, LeaderLapUpdateDto leader)
        {
            var leaderEntry = await _repository.LeaderLap.GetByIdAsync(id);
            leaderEntry = _mapper.Map(leader, leaderEntry);
            await _repository.LeaderLap.UpdateAsync(leaderEntry);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var leaderEntry = await _repository.LeaderLap.GetByIdAsync(id);
            await _repository.LeaderLap.DeleteAsync(leaderEntry);
            return NoContent();
        }
    }
}