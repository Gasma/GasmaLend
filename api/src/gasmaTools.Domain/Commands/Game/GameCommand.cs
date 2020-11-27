using gasmaTools.Abstraction.Commands;
using System;

namespace gasmaTools.Domain.Commands.Game
{
    public abstract class GameCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public Guid? PersonId { get; protected set; }
    }
}
