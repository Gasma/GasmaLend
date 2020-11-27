using gasmaTools.Abstraction.Events;
using System;

namespace gasmaTools.Domain.Events.Game
{
    public class ActivateGameEvent : Event
    {
        public Guid Id { get; private set; }

        public ActivateGameEvent(Guid id)
        {
            Id = id;
        }
    }
}
