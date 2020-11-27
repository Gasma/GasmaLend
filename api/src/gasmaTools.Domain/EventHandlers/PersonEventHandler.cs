using gasmaTools.Domain.Events.Person;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace gasmaTools.Domain.EventHandlers
{
    public class PersonEventHandler : 
        INotificationHandler<ActivatePersonEvent>,
        INotificationHandler<InactivatePersonEvent>,
        INotificationHandler<InsertPersonEvent>,
        INotificationHandler<UpdatePersonEvent>
    {
        public Task Handle(ActivatePersonEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
        public Task Handle(InactivatePersonEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
        public Task Handle(InsertPersonEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
        public Task Handle(UpdatePersonEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
