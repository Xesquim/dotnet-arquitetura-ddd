using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.ZipCode;
using Api.Domain.Interfaces.Services.ZipCode;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.ZipCode.WhenRequestGet
{
    public class ReturnOk
    {
        private ZipCodeController _controller;
        [Fact(DisplayName = "Is possible to get")]
        public async Task Is_Possible_Call_A_Controller_Get()
        {
            var serviceMock = new Mock<IZipCodeService>();
            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                new ZipCodeDto
                {
                    Id = Guid.NewGuid(),
                    Street = "Rua 1",
                    Number = "12"
                }
            );

            _controller = new ZipCodeController(serviceMock.Object);

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is OkObjectResult);
        }
    }
}