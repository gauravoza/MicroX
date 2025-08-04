using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using MicroX.Tests.Helpers;
using Xunit;

namespace MicroX.Tests.Controllers
{
    public class PingControllerTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public PingControllerTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Ping_Should_Return_Pong()
        {
            var response = await _client.GetAsync("/ping");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();
            content.Should().Be("Pong");
        }
    }
}
