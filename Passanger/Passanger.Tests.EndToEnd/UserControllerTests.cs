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
using Passanger.Infrastucture.Commands.Users;

namespace Passanger.Tests.EndToEnd.Controllers
{
    public class UserControllerTests : ControllerTestsBase
    {
        [Fact]
        public async Task given_valid_email_user_should_exists()
        {
            var email = "user1@gmail.com";
            var response = await Client.GetAsync($"users/{email}");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserDto>(responseString);
        }

        [Fact]
        public async Task given_invalid_email_user_shouldnt_exists()
        {
            var email = "invalid@gmail.com";
            var response = await Client.GetAsync($"users/{email}");

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NotFound);
        }


        [Fact]
        public async Task given_new_email_user_should_be_created()
        {
            var command = new CreateUser
            {
                Email = "test1@gmail.com",
                Password = "secret",
                Username = "testowy"
            };

            var payload = GetPayload(command);
            var response = await Client.PostAsync("users", payload);

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Created);
            //response.Headers.Location.ToString().ShouldAllBeEquivalentTo($"users/{command.Email}");
            Assert.Equal(response.Headers.Location.ToString(), $"users/{command.Email}");

            var user = await GetUserAsync(command.Email);
            Assert.Equal(user.Email, $"users/{command.Email}");
        }

        private async Task<UserDto> GetUserAsync(string email)
        {
            var response = await Client.GetAsync($"users/{email}");
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<UserDto>(responseString);
        }
    }
}