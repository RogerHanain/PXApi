using AXApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using SXDatabase;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace IntegrationTests
{
    public class Suite00_Api
    {
        private TestServer server;
        private HttpClient client;

        [SetUp]
        public void Setup()
        {
            server = new TestServer(new WebHostBuilder().UseStartup<AXApi.Startup>());

            client = server.CreateClient();
        }

        [TearDown]
        public void TearDown()
        {
            server.Dispose();
            client.Dispose();
        }

        [Test]
        public async Task Test_Words_GetAllIsASuccess()
        {
            // Act
            var response = await client.GetAsync("/v1/word");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task Test_Words_GetAllWordsIsNotEmpty()
        {
            // Act
            var response = await client.GetAsync("/v1/word");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Greater(responseString.Length, 30000);
        }

        [Test]
        public async Task Test_Words_GetWordsForAnEpisode()
        {
            // Act
            var response = await client.GetAsync("/v1/word?episodename=Friends_s01e01");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Greater(responseString.Length, 2000);
        }

        [TestCase("low")]
        public async Task Test_Translation_GetASpecificWordTranslationAndCheckLengthIsNotZero(string word)
        {
            // Act
            var response = await client.GetAsync($"/v1/translations?word={word}");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Greater(responseString.Length, 10);
        }

        [Test]
        public async Task Test_Translation_EnsureWithNoQueryIsASuccess()
        {
            // Act
            var response = await client.GetAsync($"/v1/translations");

            var responseCode = response.EnsureSuccessStatusCode().StatusCode;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, responseCode);
        }



        [Test]
        public void Test_Main_RunRunnerAndCheckHostIsCreated()
        {
            //Arrange
            var args = new string[1];
            args[0] = "%LAUNCHER_ARGS%";

            //Act
            var taskRun = new Task(() => AXApi.Program.Main(args));

            taskRun.Start();

            taskRun.Wait(5000);

            //Assert
            Assert.IsNotNull(AXApi.Program.TestHostRunner.TestHost);

            AXApi.Program.TestHostRunner.TestHost.StopAsync();
        }
    }
}
