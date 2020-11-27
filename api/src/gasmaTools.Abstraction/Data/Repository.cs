using gasmaTools.Abstraction.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gasmaTools.Abstraction.Data
{
    public class Repository<TEntity, TPrimaryKey> :
        IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>

    {
        public DbContext Context { get; protected set; }

        public DbSet<TEntity> Set { get; protected set; }

        public Repository(DbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
            this.Set = context.Set<TEntity>();
        }

        #region ReadRepository

        public IEnumerable<TEntity> GetAll()
        {
            return this.GetAllAsync().GetAwaiter().GetResult();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                return this.Set.AsEnumerable();
            });
        }

        public TEntity GetById(TPrimaryKey id)
        {
            return this.GetByIdAsync(id).GetAwaiter().GetResult();
        }

        public Task<TEntity> GetByIdAsync(TPrimaryKey id)
        {
            return this.Set.FindAsync(id).AsTask();
        }

        #endregion

        #region WriteRepository

        public void Delete(TPrimaryKey id)
        {
            this.DeleteAsync(id).GetAwaiter().GetResult();
        }

        public void Delete(TEntity entity)
        {
            this.DeleteAsync(entity).GetAwaiter().GetResult();
        }

        public Task DeleteAsync(TPrimaryKey id)
        {
            var entity = this.Set.Find(id);
            return this.DeleteAsync(entity);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            if (entity != null && entity is IDeletable)
            {
                ((IDeletable)entity).Delete();
                await this.UpdateAsync(entity);
            }
            else
            {
                this.Set.Attach(entity).State = EntityState.Deleted;
            }
        }

        public void Insert(TEntity entity)
        {
            this.InsertAsync(entity).GetAwaiter().GetResult();
        }

        public Task InsertAsync(TEntity entity)
        {
            return this.Set.AddAsync(entity).AsTask();
        }

        public int SaveChanges()
        {
            return this.SaveChangesAsync().GetAwaiter().GetResult();
        }

        public Task<int> SaveChangesAsync()
        {
            return this.Context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            this.UpdateAsync(entity).GetAwaiter().GetResult();
        }

        public Task UpdateAsync(TEntity entity)
        {
            return Task.Factory.StartNew(() =>
            {
                this.Set.Update(entity);
            });
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
