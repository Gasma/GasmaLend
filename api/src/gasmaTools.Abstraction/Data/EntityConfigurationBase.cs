using gasmaTools.Abstraction.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gasmaTools.Abstraction.Data
{
    public class EntityConfigurationBase<TEntity, TPrimaryKey> : IEntityTypeConfiguration<TEntity>
        where TEntity : Entity<TPrimaryKey>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(entity => entity.Id);
            builder.Property(x => x.CreationAt).IsRequired();
            builder.Property(x => x.Active);
            builder.Property(x => x.InactivateAt);
        }
    }
}
