using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using AutoMapper;
using SFPrj.ActionFilters;

namespace SFPrj.Controllers
{
    [ServiceFilter(typeof(ModelValidationAttribute))]
    [ServiceFilter(typeof(ModelNullAttribute))]
    [Route("api/country")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public CountryController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var countryes = await _repository.Country.GetAll();
            var countryesResult = _mapper.Map<IEnumerable<CountryDto>>(countryes);
            return Ok(countryesResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var country = await _repository.Country.GetById(id);
            var countryResult = _mapper.Map<CountryDto>(country);
            return Ok(countryResult);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CountryCreateDto country)
        {
            var countryEntity = _mapper.Map<Country>(country);
            await _repository.Country.Create(countryEntity);
            await _repository.SaveAsync();
            var createCountry = _mapper.Map<CountryDto>(countryEntity);
            return CreatedAtRoute("CountryById", new { id = createCountry.Id }, createCountry);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, CountryUpdateDto country)
        {
            var countryEntity = await _repository.Country.GetById(id);
            countryEntity = _mapper.Map(country, countryEntity);
            _repository.Country.Update(countryEntity);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var country = await _repository.Country.GetById(id);
            _repository.Country.Delete(country);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}