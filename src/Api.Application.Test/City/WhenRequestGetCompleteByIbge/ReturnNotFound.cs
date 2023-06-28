using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.City;
using Api.Domain.Interfaces.Services.City;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.City.WhenRequestGetCompleteByIbge
{
    public class ReturnNotFound
    {
        private CitiesController _controller;
        [Fact(DisplayName = "Is possible to get by ibge and return not found")]
        public async Task Is_Possible_Call_A_Controller_Get_By_Ibge_And_Return_Not_Found()
        {
            var serviceMock = new Mock<ICityService>();
            serviceMock.Setup(m => m.GetCompleteByIbge(It.IsAny<int>())).Returns(Task.FromResult((CityDtoComplete)null));

            _controller = new CitiesController(serviceMock.Object);

            var result = await _controller.GetCompleteByIbge(1);
            Assert.True(result is NotFoundResult);
        }
    }
}