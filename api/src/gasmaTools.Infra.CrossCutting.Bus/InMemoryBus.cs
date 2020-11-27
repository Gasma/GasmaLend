using gasmaTools.Abstraction.Bus;
using gasmaTools.Abstraction.Commands;
using gasmaTools.Abstraction.Events;
using MediatR;
using System.Threading.Tasks;

namespace gasmaTools.Infra.CrossCutting.Bus
{
    public class InMemoryBus : IMediatorHandler
    {
        private readonly IEventStore eventStore;
        private readonly IMediator mediator;

        public InMemoryBus(IEventStore eventStore, IMediator mediator)
        {
            this.eventStore = eventStore;
            this.mediator = mediator;
        }

        public Task RaiseEventAsync<T>(T @event) where T : Event
        {
            if (!@event.MessageType.Equals("DomainNotification"))
                this.eventStore?.Save(@event);

            return mediator.Publish(@event);
        }

        public Task SendCommandAsync<T>(T command) where T : Command
        {
            return mediator.Send(command);
        }

        public Task Subscribe<T, TH>()
            where T : Event
            where TH : INotificationHandler<T>
        {
            throw new System.NotImplementedException();
        }
    }
}
