using gasmaTools.Abstraction.Data;
using gasmaTools.Domain.Entities;
using gasmaTools.Domain.Repositories;
using gasmaTools.Infra.Data.Context;
using System;

namespace gasmaTools.Infra.Data.Repositories
{
    public class GameWriteRepository : Repository<Game, Guid>, IGameWriteRepository
    {
        public GameWriteRepository(GasmaToolsContext context) : base(context)
        {

        }
    }
}
