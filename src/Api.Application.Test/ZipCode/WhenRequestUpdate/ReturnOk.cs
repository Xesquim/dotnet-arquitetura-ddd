using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.ZipCode;
using Api.Domain.Interfaces.Services.ZipCode;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.ZipCode.WhenRequestUpdate
{
    public class ReturnOk
    {
        private ZipCodeController _controller;
        [Fact(DisplayName = "Is possible to update")]
        public async Task Is_Possible_Call_A_Controller_Update()
        {
            var serviceMock = new Mock<IZipCodeService>();
            serviceMock.Setup(m => m.Put(It.IsAny<ZipCodeDtoUpdate>())).ReturnsAsync(
                new ZipCodeDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Street = "Rua 1",
                    Number = "12",
                    UpdateAt = DateTime.UtcNow
                }
            );

            _controller = new ZipCodeController(serviceMock.Object);
            
            var zipCodeDtoUpdate = new ZipCodeDtoUpdate
            {
                Id = Guid.NewGuid(),
                Street = "Rua 1",
                Number = "12"
            };

            var result = await _controller.Put(zipCodeDtoUpdate);
            Assert.True(result is OkObjectResult);
        }
    }
}