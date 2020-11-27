using gasmaTools.Abstraction.Events;
using System;

namespace gasmaTools.Domain.Events.Person
{
    public class ActivatePersonEvent : Event
    {
        public Guid Id { get; private set; }

        public ActivatePersonEvent(Guid id)
        {
            Id = id;
        }
    }
}
