using System;
using System.Collections.Generic;
using Moq;
using Xunit;
using Contracts;
using SFPrj.Controllers;
using AutoMapper;
using Entities.Models;
using SFPrj;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace XUnitTestProjectSFPrj.Controller
{
    public class CountryTest
    {
        private async Task<IEnumerable<Country>> GetIEnumerableCountry()
        {
            IEnumerable<Country> countries = new List<Country>(){
                new Country() { Name = "TestCountry1", Id = Guid.Parse("97066981ac8c47f79176a6163b03e312"), IdImage = Guid.Parse("6d02682478594cea941bdc08464874d0") },
                new Country() { Name = "TestCountry2", Id = Guid.NewGuid(), IdImage = Guid.NewGuid() },
                new Country() { Name = "TestCountry3", Id = Guid.NewGuid(), IdImage = Guid.NewGuid() },
                new Country() { Name = "TestCountry4", Id = Guid.NewGuid(), IdImage = Guid.NewGuid() }
            };

            return await Task.FromResult(countries);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            CountryController controller;
            var countries = GetIEnumerableCountry();
            var mockRepo = new Mock<IRepositoryManager>();
            mockRepo.Setup(a => a.Country.GetAllCountriesAsync(false)).Returns(countries);
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = mockMapper.CreateMapper();
            controller = new CountryController(mockRepo.Object, mapper);
            //Act
            var okResult = controller.GetCountries();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            CountryController controller;
            var countries = GetIEnumerableCountry();
            var mockRepo = new Mock<IRepositoryManager>();
            mockRepo.Setup(a => a.Country.GetAllCountriesAsync(false)).Returns(countries);
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = mockMapper.CreateMapper();
            controller = new CountryController(mockRepo.Object, mapper);
            //Act
            var okResult = controller.GetCountries().Result as OkObjectResult;

            //Assert
            Assert.Equal(4, okResult.Value);
        }
    }
}
