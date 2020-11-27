using System;

namespace gasmaTools.Abstraction.Entities
{
    public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public TPrimaryKey Id { get; protected set; }
        public virtual DateTime CreationAt { get; protected set; }
        public virtual bool Active { get; protected set; }
        public virtual DateTime? InactivateAt { get; protected set; }
    }
}
