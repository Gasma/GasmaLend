using gasmaTools.Abstraction.Events;
using System;

namespace gasmaTools.Domain.Events.Game
{
    public class GiveBackGameEvent : Event
    {
        public Guid Id { get; private set; }

        public GiveBackGameEvent(Guid id)
        {
            Id = id;
        }
    }
}
