using gasmaTools.Abstraction.Data;
using gasmaTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gasmaTools.Domain.Repositories
{
    public interface IGameReadRepository : IReadRepository<Game, Guid>
    {
        Task<IEnumerable<Game>> GetGameWithPerson();
    }
}
