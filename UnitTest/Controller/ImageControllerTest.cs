using System.Collections.Generic;
using SFPrj.Controllers;
using Contracts;
using MockData.Repositories;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Entities.DataTransferObjects;
using System;
using SFPrj.ActionFilters;

namespace UnitTest.Controller
{
    public class ImageControllerTest
    {
        private readonly ImageController _controller;
        private readonly IRepositoryWrapper _repository;

        public ImageControllerTest()
        {
            _repository = new RepositoryFakeWrapper();
            _controller = new ImageController(_repository, AutomapperSingleton.Mapper);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Get().Result as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<ImageDto>>(okResult.Value);
            Assert.Equal(4, items.Count);
        }

        [Fact]
        [ServiceFilter(typeof(ModelValidationAttribute))]
        public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            Guid guid = new Guid("55078E17-0D1B-11E6-8B6F-005056997700");
            // Act
            var notFoundResult = _controller.GetById(guid);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            var testGuid = new Guid("EC1C9706-18FE-11E6-8B6F-0050569977A1");

            // Act
            var okResult = _controller.GetById(testGuid);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsRightItem()
        {
            // Arrange
            var testGuid = new Guid("75078E17-0D1B-11E6-8B6F-0050569977A1");

            // Act
            var okResult = _controller.GetById(testGuid).Result as OkObjectResult;

            // Assert
            Assert.IsType<ImageDto>(okResult.Value);
            Assert.Equal(testGuid, (okResult.Value as ImageDto).Id);
        }

        [Fact]
        public void Post_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var nameMissingItem = new ImageForCreationDto()
            {
                Description = "descNew"
            };
            _controller.ModelState.AddModelError("Name", "Required");

            // Act
            var badResponse = _controller.Post(nameMissingItem);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }


        [Fact]
        public void Post_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            ImageForCreationDto testItem = new ImageForCreationDto()
            {
                Description = "descNew",
                Link = "//linkNew"
            };

            // Act
            var createdResponse = _controller.Post(testItem);

            // Assert
            Assert.IsType<ImageDto>(createdResponse);
        }


        //[Fact]
        //public void Post_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        //{
        //    // Arrange
        //    var testItem = new ImageForCreationDto()
        //    {
        //        Description = "descNew",
        //        Link = "//linkNew"
        //    };

        //    // Act
        //    var createdResponse = _controller.Post(testItem);
        //    var item = createdResponse as ImageDto;

        //    // Assert
        //    Assert.IsType<ImageDto>(item);
        //    Assert.Equal("descNew", item.Description);
        //    Assert.Equal("//linkNew", item.Link);
        //}
    }
}