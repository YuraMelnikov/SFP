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
    [Route("api/participant")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public ParticipantController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var participants = await _repository.Participant.GetAllAsync();
            var participantsResult = _mapper.Map<IEnumerable<ParticipantDto>>(participants);
            return Ok(participantsResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var participant = await _repository.Participant.GetByIdAsync(id);
            var participantResult = _mapper.Map<ParticipantDto>(participant);
            return Ok(participantResult);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ParticipantCreateDto participant)
        {
            var participantEntity = _mapper.Map<Participant>(participant);
            await _repository.Participant.AddAsync(participantEntity);
            var participantCreate = _mapper.Map<ParticipantDto>(participantEntity);
            return CreatedAtRoute("GetById", new { id = participantCreate.Id }, participantCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id , ParticipantUpdateDto participant)
        {
            var participantEntity = await _repository.Participant.GetByIdAsync(id);
            participantEntity = _mapper.Map(participant, participantEntity);
            await _repository.Participant.UpdateAsync(participantEntity);
            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var participantEntity = await _repository.Participant.GetByIdAsync(id);
            await _repository.Participant.DeleteAsync(participantEntity);
            return NoContent();
        }
    }
}