using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Si;
using Api.Domain.Interfaces.Services.Si;
using Moq;
using Xunit;

namespace Api.Service.Test.Si
{
    public class WhenExecuteGetAll : SiTests
    {
        private ISiService _service;
        private Mock<ISiService> _serviceMock;

        [Fact(DisplayName = "Is possible execute GET all method")]
        public async Task Is_Possible_Execute_Get_All_Method()
        {
            _serviceMock = new Mock<ISiService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(SiDtoList);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _listResult = new List<SiDto>();
            
            _serviceMock = new Mock<ISiService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(_listResult.AsEnumerable);
            _service = _serviceMock.Object;

            var _resultEmpty = await _service.GetAll();
            Assert.Empty(_resultEmpty);
        }        
    }
}