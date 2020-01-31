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
    [ServiceFilter(typeof(ModelNullAttribute))]
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
            var images = await _repository.Image.GetAllAsync();
            var imagesResult = _mapper.Map<IEnumerable<ImageDto>>(images);
            return Ok(imagesResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var image = await _repository.Image.GetByIdAsync(id);
            var imageResult = _mapper.Map<ImageDto>(image);
            return Ok(imageResult);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ImageForCreationDto image)
        {
            var imageEntity = _mapper.Map<Image>(image);
            await _repository.Image.AddAsync(imageEntity);
            var createImage = _mapper.Map<ImageDto>(imageEntity);
            return CreatedAtRoute("ImageById", new { id = createImage.Id }, createImage);
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