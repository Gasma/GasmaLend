using gasmaTools.Domain.Base;
using System;

namespace gasmaTools.Domain.Entities
{
    public class Game : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Guid? PersonId { get; private set; }
        public Person Person { get; set; }

        public Game(Guid id, string name, string description)
            : this(name, description)
        {
            Id = id;
        }

        public Game(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void Lend(Guid personId)
        {
            this.PersonId = personId;
        }

        public void GiveBack()
        {
            this.PersonId = null;
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
