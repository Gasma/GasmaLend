using gasmaTools.Domain.Base;
using System;

namespace gasmaTools.Domain.Entities
{
    public class Person : Entity
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public int Age { get; private set; }

        public Person(Guid id, string name, string address, int age)
            : this(name, address, age)
        {
            Id = id;
        }

        public Person(string name, string address, int age)
        {
            Name = name;
            Address = address;
            Age = age;
        }

        public void Activate()
        {
            this.Active = true;
            this.InactivateAt = null;
        }

        public void InActivate()
        {
            this.Active = false;
            this.InactivateAt = DateTime.Now;
        }
    }
}
