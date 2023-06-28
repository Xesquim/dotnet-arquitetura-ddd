using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.City;
using Api.Domain.Interfaces.Services.City;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.City.WhenRequestUpdate
{
    public class ReturnBadRequest
    {
        private CitiesController _controller;
        [Fact(DisplayName = "Isn't possible to update")]
        public async Task Isnt_Possible_Call_A_Controller_Update()
        {
            var serviceMock = new Mock<ICityService>();
            serviceMock.Setup(m => m.Put(It.IsAny<CityDtoUpdate>())).ReturnsAsync(
                new CityDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Name = "São Paulo",
                    UpdateAt = DateTime.UtcNow
                }
            );

            _controller = new CitiesController(serviceMock.Object);
            _controller.ModelState.AddModelError("Name", "Name is a required field");
            var cityDtoUpdate = new CityDtoUpdate
            {
                Id = Guid.NewGuid(),
                Name = "São Paulo",
                IbgeCode = 1
            };

            var result = await _controller.Put(cityDtoUpdate);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}