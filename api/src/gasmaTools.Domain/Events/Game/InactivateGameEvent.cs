using gasmaTools.Abstraction.Events;
using System;

namespace gasmaTools.Domain.Events.Game
{
    public class InactivateGameEvent : Event
    {
        public Guid Id { get; private set; }

        public InactivateGameEvent(Guid id)
        {
            Id = id;
        }
    }
}
