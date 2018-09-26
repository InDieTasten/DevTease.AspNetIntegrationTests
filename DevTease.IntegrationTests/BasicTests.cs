using DevTease.AspNetCoreApp.Interfaces.Repository;
using DevTease.AspNetCoreApp.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DevTease.IntegrationTests
{
    public class BasicTests : IClassFixture<WebApplicationFactory<AspNetCoreApp.Startup>>
    {
        private readonly WebApplicationFactory<AspNetCoreApp.Startup> _webAppFactory;

        public BasicTests(WebApplicationFactory<AspNetCoreApp.Startup> webAppFactory)
        {
            _webAppFactory = webAppFactory;
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/Home")]
        [InlineData("/Home/About")]
        [InlineData("/Home/Contact")]
        [InlineData("/Home/Privacy")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _webAppFactory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }


        [Theory]
        [InlineData(10, 10, 10)]
        [InlineData(-1, -1, -1)]
        public async Task Get_ApiReturnsCorrectBanana(int color, int curvature, int length)
        {
            // Arrange
            var client = _webAppFactory.WithWebHostBuilder(builder =>
                builder.ConfigureTestServices((IServiceCollection services) =>
                {
                    services.AddSingleton<IBananaRepository>(new TestBananaRepository()
                    {
                        Banana = new Banana
                        {
                            Color = color,
                            Curvature = curvature,
                            Length = length
                        }
                    });
                }))
                .CreateClient();

            // Act
            var response = await client.GetAsync("/api/banana");

            // Assert
            response.EnsureSuccessStatusCode();
            var banana = await IsJsonResponse<Banana>(response);
            Assert.Equal(color, banana.Color);
            Assert.Equal(curvature, banana.Curvature);
            Assert.Equal(length, banana.Length);
        }


        public class TestBananaRepository : IBananaRepository
        {
            public Banana Banana { get; set; }

            public Banana GetBanana()
            {
                return Banana;
            }
        }

        private async Task<T> IsJsonResponse<T>(HttpResponseMessage response)
        {
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());

            var bodyString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(bodyString);
        }
    }
}
