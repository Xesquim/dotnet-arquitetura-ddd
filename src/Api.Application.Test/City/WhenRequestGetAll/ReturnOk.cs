using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.City;
using Api.Domain.Interfaces.Services.City;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.City.WhenRequestGetAll
{
    public class ReturnOk
    {
        private CitiesController _controller;
        [Fact(DisplayName = "Is possible to get all")]
        public async Task Is_Possible_Call_A_Controller_Get_All()
        {
            var serviceMock = new Mock<ICityService>();
            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
                new List<CityDto> {
                    new CityDto
                    {
                        Id = Guid.NewGuid(),
                        Name = "São Paulo"
                    }
                }
            );

            _controller = new CitiesController(serviceMock.Object);

            var result = await _controller.GetAll();
            Assert.True(result is OkObjectResult);
        }
    }
}