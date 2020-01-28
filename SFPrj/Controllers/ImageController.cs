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
        public async Task<IActionResult> GetAllImages()
        {
            var images = await _repository.Image.GetAll();
            var imagesResult = _mapper.Map<IEnumerable<ImageDto>>(images);
            return Ok(imagesResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var image = await _repository.Image.GetById(id);
            var imageResult = _mapper.Map<ImageDto>(image);
            return Ok(imageResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateImage(ImageForCreationDto image)
        {
            var imageEntity = _mapper.Map<Image>(image);
            await _repository.Image.Create(imageEntity);
            await _repository.SaveAsync();
            var createImage = _mapper.Map<ImageDto>(imageEntity);
            return CreatedAtRoute("ImageById", new { id = createImage.Id }, createImage);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateImage(Guid id, ImageForUpdateDto image)
        {
            var imageEntity = await _repository.Image.GetById(id);
            imageEntity = _mapper.Map(image, imageEntity);

            _repository.Image.Update(imageEntity);

            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(Guid id)
        {
            var image = await _repository.Image.GetById(id);
            _repository.Image.Delete(image);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}