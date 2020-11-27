using gasmaTools.Domain.Events.Login;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace gasmaTools.Domain.EventHandlers
{
    public class LoginEventHandler :
        INotificationHandler<InsertLoginEvent>
    {
        public Task Handle(InsertLoginEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
