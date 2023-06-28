using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Si;
using Api.Domain.Interfaces.Services.Si;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Si.WhenRequestGetAll
{
    public class ReturnBadRequest
    {
        private SisController _controller;

        [Fact(DisplayName = "Isn't possible get all si")]
        public async Task Isnt_Possible_Call_A_Controller_Get_All_Si()
        {
            var faker = new Faker();
            var serviceMock = new Mock<ISiService>();

            serviceMock.Setup(c => c.GetAll()).ReturnsAsync(
                new List<SiDto>
                {
                    new SiDto
                    {
                        Id = Guid.NewGuid(),
                        Name = "São Paulo",
                        Abbreviation = "SP"
                    },
                    new SiDto
                    {
                        Id = Guid.NewGuid(),
                        Name = "Espirito Santo",
                        Abbreviation = "ES"
                    }
                }
            );

            _controller = new SisController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Id is invalid");

            var result = await _controller.GetAll();
            Assert.True(result is BadRequestObjectResult);
        }
    }
}