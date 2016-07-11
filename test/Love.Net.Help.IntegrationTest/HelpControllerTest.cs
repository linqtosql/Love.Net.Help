using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

using Love.Net.Help.Host;
using Xunit;
using Newtonsoft.Json.Linq;
using System.Net;

namespace Love.Net.Help.IntegrationTest {
    public class HelpControllerTest {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public HelpControllerTest() {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Theory]
        [InlineData(1)]
        public async Task ReturnValue(int id) {
            // Act
            var response = await _client.GetAsync($"/api/values/{id}");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal("value", responseString);
        }

        [Fact]
        public async Task ReturnJObject() {
            // Act
            var response = await _client.GetAsync($"/api/help/");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsAsync<JObject>();

            // Assert
            Assert.NotNull(json);
            Assert.True(json.Count == 2);
        }

        [Theory]
        [InlineData("api/Account")]
        public async Task Get_By_RelativePath(string relativePath) {
            // Act
            var response = await _client.GetAsync($"/api/help/get?RelativePath={ WebUtility.UrlEncode(relativePath)}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsAsync<JObject>();

            // Assert
            Assert.NotNull(json);
            Assert.True(json.Count == 1);
        } 
    }
}
