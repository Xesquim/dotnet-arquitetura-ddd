using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.City;
using Api.Domain.Interfaces.Services.City;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.City.WhenRequestGetCompleteById
{
    public class ReturnNotFound
    {
        private CitiesController _controller;
        [Fact(DisplayName = "Is possible to get by id and return not found")]
        public async Task Is_Possible_Call_A_Controller_Get_By_Id_And_Return_Not_Found()
        {
            var serviceMock = new Mock<ICityService>();
            serviceMock.Setup(m => m.GetCompleteById(It.IsAny<Guid>())).Returns(Task.FromResult((CityDtoComplete)null));

            _controller = new CitiesController(serviceMock.Object);

            var result = await _controller.GetCompleteById(Guid.NewGuid());
            Assert.True(result is NotFoundResult);
        }
    }
}