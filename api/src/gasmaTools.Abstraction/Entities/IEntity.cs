using System;

namespace gasmaTools.Abstraction.Entities
{
    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; }
        DateTime CreationAt { get; }
        bool Active { get; }
        DateTime? InactivateAt { get; }
    }
}
