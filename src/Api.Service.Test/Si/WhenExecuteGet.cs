using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Si;
using Api.Domain.Interfaces.Services.Si;
using Moq;
using Xunit;

namespace Api.Service.Test.Si
{
    public class WhenExecuteGet : SiTests
    {
        private ISiService _service;
        private Mock<ISiService> _serviceMock;

        [Fact(DisplayName = "Is possible execute GET method")]
        public async Task Is_Possible_Execute_Get_Method()
        {
            _serviceMock = new Mock<ISiService>();
            _serviceMock.Setup(m => m.Get(SiId)).ReturnsAsync(SiDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(SiId);
            Assert.NotNull(result);
            Assert.True(result.Id == SiId);
            Assert.Equal(Name, result.Name);
            
            _serviceMock = new Mock<ISiService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((SiDto)null));
            _service = _serviceMock.Object;

            var _resultNull = await _service.Get(SiId);
            Assert.Null(_resultNull);
        }        
    }
}