using System.Threading.Tasks;
using Xunit;

namespace Api.Integration.Test
{
    public class LoginTest : BaseIntegration
    {
        [Fact]
        public async Task TokenTest()
        {
            await AddToken();
        }
    }
}