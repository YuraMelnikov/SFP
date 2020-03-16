using Microsoft.AspNetCore.Mvc;
using Contracts;
using AutoMapper;
using System.Collections.Generic;
using Entities.DataTransferObjects;
using System;
using Entities.Models;
using System.Threading.Tasks;

namespace SFPrj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public ImageController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetImage()
        {
            var image = await _repository.Image.GetAllImageAsync(trackChanges: false);
            var imageDTO = _mapper.Map<IEnumerable<ImageDto>>(image);
            return Ok(imageDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetImage(Guid id)
        {
            var image = await _repository.Image.GetImageAsync(id, trackChanges: false);
            if (image == null)
                return NotFound();
            else
            {
                var imageDTO = _mapper.Map<ImageDto>(image);
                return Ok(imageDTO);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateImage([FromBody]ImageForCreationDto image)
        {
            if (image == null)
                return BadRequest("ImageDto object is null.");
            else
            {
                var imageEntity = _mapper.Map<Image>(image);
                _repository.Image.CreateImage(imageEntity);
                await _repository.SaveAsync();
                var imageToReturn = _mapper.Map<ImageDto>(imageEntity);
                return CreatedAtRoute("GetImage", new { id = imageToReturn.Id }, imageToReturn);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(Guid id)
        {
            var image = await _repository.Image.GetImageAsync(id, trackChanges: false);
            if (image == null)
            {
                return NotFound();
            }
            _repository.Image.DeleteImage(image);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateImage([FromBody] ImageDto image)
        {
            if (image == null)
                return BadRequest("ImageDto object is null");
            var imageEntity = await _repository.Image.GetImageAsync(image.Id, trackChanges: true);
            if (imageEntity == null)
                return NotFound();
            _mapper.Map(image, imageEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}