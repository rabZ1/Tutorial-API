using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using AutoMapper;
using Moq;
using Passanger.Core.Repositories;
using Passanger.Infrastucture.Services;
using Passanger.Core.Domain;

namespace Passanger.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public async Task register_async_should_invoke_add_async_on_repository()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();

            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object);
            await userService.RegisterAsync("user@gmail.com", "secret", "user1");

            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }
    }
}
