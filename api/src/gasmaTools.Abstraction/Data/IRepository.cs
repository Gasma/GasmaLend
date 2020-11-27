using gasmaTools.Abstraction.Entities;
using Microsoft.EntityFrameworkCore;

namespace gasmaTools.Abstraction.Data
{
    public interface IRepository<TEntity, TPrimaryKey> :
        IReadRepository<TEntity, TPrimaryKey>,
        IWriteRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        DbContext Context { get; }
        DbSet<TEntity> Set { get; }
    }
}
