using gasmaTools.Abstraction.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gasmaTools.Abstraction.Data
{
    public interface IReadRepository<TEntity, TPrimaryKey> : IDisposable
        where TEntity : IEntity<TPrimaryKey>
    {

        TEntity GetById(TPrimaryKey id);
        IEnumerable<TEntity> GetAll();
        Task<TEntity> GetByIdAsync(TPrimaryKey id);
        Task<IEnumerable<TEntity>> GetAllAsync();

    }
}
