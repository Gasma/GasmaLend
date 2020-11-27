using gasmaTools.Abstraction.Entities;
using System;
using System.Threading.Tasks;

namespace gasmaTools.Abstraction.Data
{
    public interface IWriteRepository<TEntity, TPrimaryKey> : IDisposable
        where TEntity : IEntity<TPrimaryKey>
    {

        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TPrimaryKey id);
        void Delete(TEntity entity);
        int SaveChanges();

        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TPrimaryKey id);
        Task DeleteAsync(TEntity entity);
        Task<int> SaveChangesAsync();
    }
}
