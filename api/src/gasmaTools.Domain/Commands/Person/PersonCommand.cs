using gasmaTools.Abstraction.Commands;
using System;

namespace gasmaTools.Domain.Commands.Person
{
    public abstract class PersonCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Address { get; protected set; }
        public int Age { get; protected set; }
    }
}
