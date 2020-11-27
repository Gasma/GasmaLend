using gasmaTools.Abstraction.Data;
using gasmaTools.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace gasmaTools.Infra.Data.EntityConfig
{
    public class PersonConfiguration : EntityConfigurationBase<Person, Guid>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            base.Configure(builder);
        }
    }
}
