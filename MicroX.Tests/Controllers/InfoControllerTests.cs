using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using MicroX.Tests.Helpers;
using Xunit;

namespace MicroX.Tests.Controllers
{
    public class InfoControllerTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public InfoControllerTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Info_Should_Return_App_Info()
        {
            var response = await _client.GetAsync("/info");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var body = await response.Content.ReadAsStringAsync();
            body.Should().Contain("MicroX"); // adjust based on your app's info
        }
    }
}
