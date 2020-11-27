using System;

namespace gasmaTools.Abstraction.Events
{
    public class StoredEvent : Event
    {
        public Guid Id { get; set; }
        public string Data { get; set; }
        public string User { get; set; }

        public StoredEvent()
        {

        }

        public StoredEvent(Event @event, string data, string user)
        {
            Id = Guid.NewGuid();
            EntityId = @event.EntityId;
            MessageType = @event.MessageType;
            Data = data;
            User = user;
        }
    }
}
