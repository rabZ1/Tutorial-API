using FluentAssertions;
using Passanger.Infrastucture.Commands.Users;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Passanger.Tests.EndToEnd
{
    class AccountControllerTests : ControllerTestsBase
    {
        [Fact]
        public async Task given_change_password_command_should_return_no_content()
        {
            var command = new ChangeUserPassword
            {
                CurrentPassword = "secret",
                NewPassword = "secret1"
            };

            var payload = GetPayload(command);
            var response = await Client.PutAsync("account/password", payload);

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NoContent);
        }
    }
}
