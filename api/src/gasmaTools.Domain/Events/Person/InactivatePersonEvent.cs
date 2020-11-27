using gasmaTools.Abstraction.Events;
using System;

namespace gasmaTools.Domain.Events.Person
{
    public class InactivatePersonEvent : Event
    {
        public Guid Id { get; private set; }

        public InactivatePersonEvent(Guid id)
        {
            Id = id;
        }
    }
}
