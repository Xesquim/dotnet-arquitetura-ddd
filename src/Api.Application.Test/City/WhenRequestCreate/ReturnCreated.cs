using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.City;
using Api.Domain.Interfaces.Services.City;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.City.WhenRequestCreate
{
    public class ReturnCreated
    {
        private CitiesController _controller;
        [Fact(DisplayName = "Is possible to create")]
        public async Task Is_Possible_Call_A_Controller_Create()
        {
            var serviceMock = new Mock<ICityService>();
            serviceMock.Setup(m => m.Post(It.IsAny<CityDtoCreate>())).ReturnsAsync(
                new CityDtoCreateResult
                {
                    Id = Guid.NewGuid(),
                    Name = "São Paulo",
                    CreateAt = DateTime.UtcNow
                }
            );

            _controller = new CitiesController(serviceMock.Object);

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(m => m.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var cityDtoCreate = new CityDtoCreate
            {
                Name = "São Paulo",
                IbgeCode = 1
            };

            var result = await _controller.Post(cityDtoCreate);
            Assert.True(result is CreatedResult);
        }
    }
}