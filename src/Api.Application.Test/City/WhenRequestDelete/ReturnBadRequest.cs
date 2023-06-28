using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.City;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.City.WhenRequestDelete
{
    public class ReturnBadRequest
    {
        private CitiesController _controller;
        [Fact(DisplayName = "Isn't possible to delete")]
        public async Task Isnt_Possible_Call_A_Controller_Delete()
        {
            var serviceMock = new Mock<ICityService>();
            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>()))
                        .ReturnsAsync(true);

            _controller = new CitiesController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Id is required");

            var result = await _controller.Delete(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }
    }
}