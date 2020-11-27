using gasmaTools.Abstraction.Data;
using gasmaTools.Domain.Entities;
using gasmaTools.Domain.Repositories;
using gasmaTools.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gasmaTools.Infra.Data.Repositories
{
    public class GameReadRepository : Repository<Game, Guid>, IGameReadRepository
    {
        public GameReadRepository(GasmaToolsContext context) : base(context)
        {
        }

        public Task<IEnumerable<Game>> GetGameWithPerson()
        {
            var games = Set.AsNoTracking()
                .Include(a => a.Person).AsEnumerable();

            return Task.FromResult(games);
        }
    }
}
