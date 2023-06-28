using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.City;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.City.WhenRequestDelete
{
    public class ReturnDeleted
    {
        private CitiesController _controller;
        [Fact(DisplayName = "Is possible to delete")]
        public async Task Is_Possible_Call_A_Controller_Delete()
        {
            var serviceMock = new Mock<ICityService>();
            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>()))
                        .ReturnsAsync(true);

            _controller = new CitiesController(serviceMock.Object);

            var result = await _controller.Delete(Guid.NewGuid());
            Assert.True(result is OkObjectResult);
        }
    }
}