using System;

namespace gasmaTools.Abstraction.Entities
{
    public interface IDeletable
    {
        bool IsDeleted { get; }
        DateTime? DeletedDate { get; }
        void Delete();
    }
}
