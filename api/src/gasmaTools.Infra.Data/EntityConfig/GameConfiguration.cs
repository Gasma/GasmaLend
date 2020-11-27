using gasmaTools.Abstraction.Data;
using gasmaTools.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace gasmaTools.Infra.Data.EntityConfig
{
    public class GameConfiguration : EntityConfigurationBase<Game, Guid>
    {
        public override void Configure(EntityTypeBuilder<Game> builder)
        {
            base.Configure(builder);
        }
    }
}
