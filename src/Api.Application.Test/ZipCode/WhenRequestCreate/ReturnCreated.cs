using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.ZipCode;
using Api.Domain.Interfaces.Services.ZipCode;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.ZipCode.WhenRequestCreate
{
    public class ReturnCreated
    {
        private ZipCodeController _controller;
        [Fact(DisplayName = "Is possible to create")]
        public async Task Is_Possible_Call_A_Controller_Create()
        {
            var serviceMock = new Mock<IZipCodeService>();
            serviceMock.Setup(m => m.Post(It.IsAny<ZipCodeDtoCreate>())).ReturnsAsync(
                new ZipCodeDtoCreateResult
                {
                    Id = Guid.NewGuid(),
                    Street = "Rua 1",
                    Number = "12",
                    CreateAt = DateTime.UtcNow
                }
            );

            _controller = new ZipCodeController(serviceMock.Object);

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(m => m.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var zipCodeDtoCreate = new ZipCodeDtoCreate
            {
                Street = "Rua 1",
                Number = "12"
            };

            var result = await _controller.Post(zipCodeDtoCreate);
            Assert.True(result is CreatedResult);
        }
    }
}