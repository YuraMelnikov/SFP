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
    [ServiceFilter(typeof(ModelNullAttribute))]
    [Route("api/qualification")]
    [ApiController]
    public class QualificationController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public QualificationController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var qualifications = await _repository.Qualification.GetAllAsync();
            var qualificationsResult = _mapper.Map<IEnumerable<QualificationDto>>(qualifications);
            return Ok(qualificationsResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var qualification = await _repository.Qualification.GetByIdAsync(id);
            var qualificationReasult = _mapper.Map<QualificationDto>(qualification);
            return Ok(qualificationReasult);
        }

        [HttpPost]
        public async Task<IActionResult> Post(QualificationCreateDto qualification)
        {
            var qualificationEntity = _mapper.Map<Qualification>(qualification);
            await _repository.Qualification.AddAsync(qualificationEntity);
            var qualificationCreate = _mapper.Map<QualificationDto>(qualificationEntity);
            return CreatedAtRoute("GetById", new { id = qualificationCreate.Id }, qualificationCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, QualificationUpdateDto qualification)
        {
            var qualificationEntity = await _repository.Qualification.GetByIdAsync(id);
            qualificationEntity = _mapper.Map(qualification, qualificationEntity);
            await _repository.Qualification.UpdateAsync(qualificationEntity);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var qualificationEntity = await _repository.Qualification.GetByIdAsync(id);
            await _repository.Qualification.DeleteAsync(qualificationEntity);
            return NoContent();
        }
    }
}