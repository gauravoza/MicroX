using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using MicroX.Tests.Helpers;
using Xunit;

namespace MicroX.Tests.Controllers
{
    public class ServiceInfoControllerTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public ServiceInfoControllerTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ServiceInfo_Should_Return_Metadata()
        {
            var response = await _client.GetAsync("/Info");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();
            content.Should().Contain("environment"); // or other known field
        }
    }
}
