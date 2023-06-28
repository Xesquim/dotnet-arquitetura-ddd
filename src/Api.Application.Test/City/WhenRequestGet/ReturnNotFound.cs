using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.City;
using Api.Domain.Interfaces.Services.City;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.City.WhenRequestGet
{
    public class ReturnNotFound
    {
        private CitiesController _controller;
        [Fact(DisplayName = "Is possible to get and return not found")]
        public async Task Is_Possible_Call_A_Controller_Get_And_Return_Not_Found()
        {
            var serviceMock = new Mock<ICityService>();
            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((CityDto)null));

            _controller = new CitiesController(serviceMock.Object);

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is NotFoundResult);
        }
    }
}