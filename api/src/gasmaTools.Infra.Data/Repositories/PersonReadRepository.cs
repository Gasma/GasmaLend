using gasmaTools.Abstraction.Data;
using gasmaTools.Domain.Entities;
using gasmaTools.Domain.Repositories;
using gasmaTools.Infra.Data.Context;
using System;

namespace gasmaTools.Infra.Data.Repositories
{
    public class PersonReadRepository : Repository<Person, Guid>, IPersonReadRepository
    {
        public PersonReadRepository(GasmaToolsContext context) : base(context)
        {
        }
    }
}
