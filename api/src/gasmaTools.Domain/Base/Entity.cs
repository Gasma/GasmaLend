using gasmaTools.Abstraction.Entities;
using System;

namespace gasmaTools.Domain.Base
{
    public class Entity : Entity<Guid>
    {
        public Entity()
        {
            if (base.Id == Guid.Empty)
            {
                this.Id = Guid.NewGuid();
                this.CreationAt = DateTime.Now;
            }
        }
    }
}
