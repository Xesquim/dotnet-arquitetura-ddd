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
    public class ReturnNotFound
    {
        private ZipCodeController _controller;
        [Fact(DisplayName = "Is possible to get and return not found")]
        public async Task Is_Possible_Call_A_Controller_Get_And_Return_Not_Found()
        {
            var serviceMock = new Mock<IZipCodeService>();
            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((ZipCodeDto)null));

            _controller = new ZipCodeController(serviceMock.Object);

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is NotFoundResult);
        }
    }
}