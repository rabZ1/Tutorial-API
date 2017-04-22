using System.Threading.Tasks;

namespace Passanger.Infrastucture.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}
