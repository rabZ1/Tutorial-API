using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Passagner.Api;
using Passanger.Infrastucture.DTO;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System.Net;
using System.Text;

namespace Passanger.Tests.EndToEnd.Controllers
{
    public class UserControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public UserControllerTests()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task given_valid_email_user_should_exists()
        {
            var email = "user1@gmail.com";
            var response = await _client.GetAsync($"users/{email}");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserDto>(responseString);
        }

        [Fact]
        public async Task given_invalid_email_user_shouldnt_exists()
        {
            var email = "invalid@gmail.com";
            var response = await _client.GetAsync($"users/{email}");

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NotFound);
        }


        [Fact]
        public async Task given_new_email_user_should_be_created()
        {
            var request = new
            {
                Email = "test@gmail.com",
                Password = "secret",
                Username = "testowy"
            };

            var payload = GetPayload(request);
            var response = await _client.PostAsync("users", payload);

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Created);
            response.Headers.Location.ToString().ShouldAllBeEquivalentTo($"users/{request.Email}");
        }


        private StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);

            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}