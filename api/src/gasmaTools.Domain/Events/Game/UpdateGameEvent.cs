using gasmaTools.Abstraction.Events;
using System;

namespace gasmaTools.Domain.Events.Game
{
    public class UpdateGameEvent : Event
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public UpdateGameEvent(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
