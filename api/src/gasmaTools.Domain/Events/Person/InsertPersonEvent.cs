using gasmaTools.Abstraction.Events;
using System;

namespace gasmaTools.Domain.Events.Person
{
    public class InsertPersonEvent : Event
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public int Age { get; private set; }

        public InsertPersonEvent(Guid id, string name, string address, int age)
        {
            Id = id;
            Name = name;
            Address = address;
            Age = age;
        }
    }
}
