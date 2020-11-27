using gasmaTools.Abstraction.Events;

namespace gasmaTools.Domain.Events.Game
{
    public class InsertGameEvent : Event
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public InsertGameEvent(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
