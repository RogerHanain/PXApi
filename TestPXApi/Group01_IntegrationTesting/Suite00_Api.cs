using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using NUnit.Framework;
using PXApi;
using PXApi.Models;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Group01_IntegrationTesting
{
    public class Suite00_Api
    {
        private TestServer server;
        private HttpClient client;

        [SetUp]
        public void Setup()
        {
            server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            client = server.CreateClient();
        }

        [TearDown]
        public void TearDown()
        {
            server.Dispose();
            client.Dispose();
        }

        [Test]
        public async Task Test000_GetAllShows_IsASuccess()
        {
            // Act
            var response = await client.GetAsync("/v1/word");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task Test001_GetAllContentIsNotEmpty()
        {
            // Act
            var response = await client.GetAsync("/v1/word");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Greater(responseString.Length, 30000);
        }
    }
}
