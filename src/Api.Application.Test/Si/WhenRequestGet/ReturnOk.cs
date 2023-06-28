using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Si;
using Api.Domain.Interfaces.Services.Si;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Si.WhenRequestGet
{
    public class ReturnOk
    {
        private SisController _controller;

        [Fact(DisplayName = "Is possible get a si")]
        public async Task Is_Possible_Call_A_Controller_Get_Si()
        {
            var faker = new Faker();
            var serviceMock = new Mock<ISiService>();

            serviceMock.Setup(c => c.Get(It.IsAny<Guid>())).ReturnsAsync(
                new SiDto
                {
                    Id = Guid.NewGuid(),
                    Name = "São Paulo",
                    Abbreviation = "SP"
                }
            );

            _controller = new SisController(serviceMock.Object);

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is OkObjectResult);
        }
    }
}