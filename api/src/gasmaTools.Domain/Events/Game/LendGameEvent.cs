using gasmaTools.Abstraction.Events;
using System;

namespace gasmaTools.Domain.Events.Game
{
    public class LendGameEvent : Event
    {
        public Guid Id { get; private set; }
        public Guid PersonId { get; private set; }

        public LendGameEvent(Guid id, Guid personId)
        {
            Id = id;
            PersonId = personId;
        }
    }
}
