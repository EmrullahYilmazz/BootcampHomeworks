using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Web_Api_Tests
{
    public class ItemControllerIntegrationTest : IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly HttpClient _client;
        public ItemControllerIntegrationTest(TestingWebAppFactory<Program> factory)
            => _client = factory.CreateClient();
        [Fact]
        public async Task ReturnIndex()
        {
            var response = await _client.GetAsync("/Item");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("ceket", responseString);
            Assert.Contains("kalem", responseString);
        }
        [Fact]
        public async Task CreatetWrongItem()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Item");
            var formModel = new Dictionary<string, string>
            {
                { "Name", "123" },
                { "Age", "name" }
            };
            postRequest.Content = new FormUrlEncodedContent(formModel);

            var response = await _client.SendAsync(postRequest);

            response.EnsureSuccessStatusCode();

            var responsecode = await response.Content.ReadAsStringAsync();

            Assert.Contains("500", responsecode);
        }
    }
    
}
