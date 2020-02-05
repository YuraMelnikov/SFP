using Microsoft.AspNetCore.Mvc;
using Contracts;
using AutoMapper;
using System.Collections.Generic;
using Entities.DataTransferObjects;
using System;
using SFPrj.ActionFilters;
using Entities.Models;
using System.Threading.Tasks;

namespace SFPrj.Controllers
{
    [ServiceFilter(typeof(ModelValidationAttribute))]
    [Route("api/image")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public ImageController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var images = await _repository.Image.GetAllAsync();
                var imagesResult = _mapper.Map<IEnumerable<ImageDto>>(images);
                return Ok(imagesResult);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var image = await _repository.Image.GetByIdAsync(id);
                var imageResult = _mapper.Map<ImageDto>(image);
                return Ok(imageResult);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ImageForCreationDto image)
        {
            try
            {
                var imageEntity = _mapper.Map<Image>(image);
                await _repository.Image.AddAsync(imageEntity);
                return StatusCode(201, await _repository.Image.GetByIdAsync(imageEntity.Id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, ImageForUpdateDto image)
        {
            var imageEntity = await _repository.Image.GetByIdAsync(id);
            imageEntity = _mapper.Map(image, imageEntity);
            await _repository.Image.UpdateAsync(imageEntity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var image = await _repository.Image.GetByIdAsync(id);
            await _repository.Image.DeleteAsync(image);
            return NoContent();
        }
    }
}