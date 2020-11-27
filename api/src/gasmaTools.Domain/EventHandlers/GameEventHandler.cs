using gasmaTools.Domain.Events.Game;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace gasmaTools.Domain.EventHandlers
{
    public class GameEventHandler : INotificationHandler<ActivateGameEvent>,
        INotificationHandler<GiveBackGameEvent>,
        INotificationHandler<InactivateGameEvent>,
        INotificationHandler<LendGameEvent>,
        INotificationHandler<UpdateGameEvent>,
        INotificationHandler<InsertGameEvent>
    {
        public Task Handle(ActivateGameEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
        public Task Handle(GiveBackGameEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
        public Task Handle(InactivateGameEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
        public Task Handle(InsertGameEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
        public Task Handle(LendGameEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
        public Task Handle(UpdateGameEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
