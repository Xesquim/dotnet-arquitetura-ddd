using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.City;
using Api.Domain.Interfaces.Services.City;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.City.WhenRequestGet
{
    public class ReturnBadRequest
    {
        private CitiesController _controller;
        [Fact(DisplayName = "Isn't possible to get")]
        public async Task Isnt_Possible_Call_A_Controller_Get()
        {
            var serviceMock = new Mock<ICityService>();
            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                new CityDto
                {
                    Id = Guid.NewGuid(),
                    Name = "São Paulo"
                }
            );

            _controller = new CitiesController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Id is required");

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }
    }
}