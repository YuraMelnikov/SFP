using Microsoft.AspNetCore.Mvc;
using Contracts;
using AutoMapper;
using System.Collections.Generic;
using Entities.DataTransferObjects;
using System;
using SFPrj.ActionFilters;
using Entities.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SFPrj.Controllers
{
    //[ServiceFilter(typeof(ModelValidationAttribute))]
    [Route("api/[controller]")]
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
        public async Task<ActionResult<ImageDto>> Get(Guid id)
        {
            var image = await _repository.Image.GetByIdAsync(id);
            var imageResult = _mapper.Map<ImageDto>(image);
            return imageResult;
        }

        [HttpPost]
        public async Task<ActionResult<Image>> Post(ImageForCreationDto image)
        {
            var imageEntity = _mapper.Map<Image>(image);
            await _repository.Image.AddAsync(imageEntity);
            return CreatedAtAction(nameof(Get), new { id = imageEntity.Id }, imageEntity);
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
        public async Task<ActionResult<Image>> Delete(Guid id)
        {
            var image = await _repository.Image.GetByIdAsync(id);
            await _repository.Image.DeleteAsync(image);
            return image;
        }
    }
}