using System.Collections.Generic;
using SFPrj.Controllers;
using Contracts;
using MockData.Repositories;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Entities.DataTransferObjects;
using System;

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

        //Testing the Get Method
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
            Assert.Equal(4, GetCountImagesInRepositoryes(_controller.Get().Result as OkObjectResult));
        }

        //Testing the GetById method
        [Fact]
        public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.Get(Guid.NewGuid());

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            var testGuid = new Guid("75078E17-0D1B-11E6-8B6F-0050569977A1");

            // Act
            var okResult = _controller.Get(testGuid);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        //////[Fact]
        //////public void GetById_ExistingGuidPassed_ReturnsRightItem()
        //////{
        //////    // Arrange
        //////    var testGuid = new Guid("75078E17-0D1B-11E6-8B6F-0050569977A1");

        //////    // Act
        //////    var okResult = _controller.Get(testGuid).Result as OkObjectResult;

        //////    // Assert
        //////    Assert.IsType<ImageDto>(okResult.Value);
        //////    Assert.Equal(testGuid, (okResult.Value as ImageDto).Id);
        //////}

        //Testing the Add Method
        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var nameMissingItem = new ImageForCreationDto()
            {
                Link = "LinkTest",
                Description = "DescriptionTest"
            };
            _controller.ModelState.AddModelError("Name", "Required");

            // Act
            var badResponse = _controller.Post(nameMissingItem);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            ImageForCreationDto testItem = new ImageForCreationDto()
            {
                Link = "LinkTest",
                Description = "DescriptionTest"
            };

            // Act
            var createdResponse = _controller.Post(testItem);

            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }

        //////[Fact]
        //////public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        //////{
        //////    // Arrange
        //////    var testItem = new ImageForCreationDto()
        //////    {
        //////        Link = "LinkTest",
        //////        Description = "DescriptionTest"
        //////    };

        //////    // Act
        //////    var createdResponse = _controller.Post(testItem).Result as ImageForCreationDto;
        //////    var item = createdResponse as ImageForCreationDto;

        //////    // Assert
        //////    Assert.IsType<ImageForCreationDto>(item);
        //////    Assert.Equal("LinkTest", item.Link);
        //////}

        //Remove method
        [Fact]
        public void Remove_NotExistingGuidPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            var notExistingGuid = Guid.NewGuid();

            // Act
            var badResponse = _controller.Delete(notExistingGuid);

            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void Remove_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            var existingGuid = new Guid("75078E17-0D1B-11E6-8B6F-0050569977A1");

            // Act
            var okResponse = _controller.Delete(existingGuid).Result;

            // Assert
            Assert.IsType<OkResult>(okResponse);
        }
        [Fact]
        public void Remove_ExistingGuidPassed_RemovesOneItem()
        {
            // Arrange
            var existingGuid = new Guid("75078E17-0D1B-11E6-8B6F-0050569977A1");

            // Act
            var okResponse = _controller.Delete(existingGuid);

            // Assert
            Assert.Equal(3, GetCountImagesInRepositoryes(_controller.Get().Result as OkObjectResult));
        }

        private int GetCountImagesInRepositoryes(OkObjectResult okObjectResult)
        {
            var items = Assert.IsType<List<ImageDto>>(okObjectResult.Value);
            return items.Count;
        }
    }
}