﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using SFPrj.ActionFilters;

namespace SFPrj.Controllers
{
    [ServiceFilter(typeof(ModelValidationAttribute))]
    [ServiceFilter(typeof(ModelNullAttribute))]
    [Route("api/fail")]
    [ApiController]
    public class FailController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public FailController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var fails = await _repository.Fail.GetAll();
            var failsResult = _mapper.Map<IEnumerable<FailDto>>(fails);
            return Ok(failsResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var fail = await _repository.Fail.GetById(id);
            var failResult = _mapper.Map<FailDto>(fail);
            return Ok(failResult);
        }

        [HttpPost]
        public async Task<IActionResult> Create(FailCreateDto fail)
        {
            var failEntity = _mapper.Map<Fail>(fail);
            await _repository.Fail.Create(failEntity);
            await _repository.SaveAsync();
            var failCreate = _mapper.Map<FailDto>(failEntity);
            return CreatedAtRoute("FailById", new { id = failCreate}, failCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, FailCreateDto fail)
        {
            var failEntity = await _repository.Fail.GetById(id);
            failEntity = _mapper.Map(fail, failEntity);
            _repository.Fail.Update(failEntity);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var failEntity = await _repository.Fail.GetById(id);
            _repository.Fail.Delete(failEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}