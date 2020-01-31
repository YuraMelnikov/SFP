using System;
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
    [Route("api/fine")]
    [ApiController]
    public class FineController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public FineController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var fines = await _repository.Fine.GetAllAsync();
            var finesResult = _mapper.Map<FineDto>(fines);
            return Ok(finesResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var fine = await _repository.Fine.GetByIdAsync(id);
            var fineResult = _mapper.Map<FineDto>(fine);
            return Ok(fineResult);
        }

        [HttpPost]
        public async Task<IActionResult> Post(FineCreateDto fine)
        {
            var fineEntity = _mapper.Map<Fine>(fine);
            await _repository.Fine.AddAsync(fineEntity);
            var createFine = _mapper.Map<FineDto>(fineEntity);
            return CreatedAtRoute("FineById", new { id = createFine.Id }, createFine);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, FineUpdateDto fine)
        {
            var fineEntity = await _repository.Fine.GetByIdAsync(id);
            fineEntity = _mapper.Map(fine, fineEntity);
            await _repository.Fine.UpdateAsync(fineEntity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var fineEntity = await _repository.Fine.GetByIdAsync(id);
            await _repository.Fine.DeleteAsync(fineEntity);
            return NoContent();
        }
    }
}