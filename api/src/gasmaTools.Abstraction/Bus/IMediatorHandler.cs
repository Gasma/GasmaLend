using gasmaTools.Abstraction.Commands;
using gasmaTools.Abstraction.Events;
using MediatR;
using System.Threading.Tasks;

namespace gasmaTools.Abstraction.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommandAsync<T>(T command) where T : Command;
        Task RaiseEventAsync<T>(T @event) where T : Event;
        Task Subscribe<T, TH>() where T : Event where TH : INotificationHandler<T>;
    }
}
