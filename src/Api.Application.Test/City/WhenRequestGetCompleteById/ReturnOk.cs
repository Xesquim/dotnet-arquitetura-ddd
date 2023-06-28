using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.City;
using Api.Domain.Interfaces.Services.City;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.City.WhenRequestGetCompleteByIbge
{
    public class ReturnOk
    {
        private CitiesController _controller;
        [Fact(DisplayName = "Is possible to get by ibge")]
        public async Task Is_Possible_Call_A_Controller_Get_ByIbge()
        {
            var serviceMock = new Mock<ICityService>();
            serviceMock.Setup(m => m.GetCompleteByIbge(It.IsAny<int>())).ReturnsAsync(
                new CityDtoComplete
                {
                    Id = Guid.NewGuid(),
                    Name = "São Paulo"
                }
            );

            _controller = new CitiesController(serviceMock.Object);

            var result = await _controller.GetCompleteByIbge(1);
            Assert.True(result is OkObjectResult);
        }
    }
}