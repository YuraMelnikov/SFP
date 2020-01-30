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
        public async Task<IActionResult> GetAll()
        {
            var qualifications = await _repository.Qualification.GetAll();
            var qualificationsResult = _mapper.Map<IEnumerable<QualificationDto>>(qualifications);
            return Ok(qualificationsResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var qualification = await _repository.Qualification.GetById(id);
            var qualificationReasult = _mapper.Map<QualificationDto>(qualification);
            return Ok(qualificationReasult);
        }

        [HttpPost]
        public async Task<IActionResult> Create(QualificationCreateDto qualification)
        {
            var qualificationEntity = _mapper.Map<Qualification>(qualification);
            await _repository.Qualification.Create(qualificationEntity);
            await _repository.SaveAsync();
            var qualificationCreate = _mapper.Map<QualificationDto>(qualificationEntity);
            return CreatedAtRoute("GetById", new { id = qualificationCreate.Id }, qualificationCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, QualificationUpdateDto qualification)
        {
            var qualificationEntity = await _repository.Qualification.GetById(id);
            qualificationEntity = _mapper.Map(qualification, qualificationEntity);
            _repository.Qualification.Update(qualificationEntity);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var qualificationEntity = await _repository.Qualification.GetById(id);
            _repository.Qualification.Delete(qualificationEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}