
using System.Threading.Tasks;

namespace Passanger.Infrastucture.Commands
{
    public interface ICommandDispatcher 
    {
        Task DispatchAsync<T>(T command) where T : ICommand;
    }
}
