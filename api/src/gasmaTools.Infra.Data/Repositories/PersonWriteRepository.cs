using gasmaTools.Abstraction.Data;
using gasmaTools.Domain.Entities;
using gasmaTools.Domain.Repositories;
using gasmaTools.Infra.Data.Context;
using System;

namespace gasmaTools.Infra.Data.Repositories
{
    public class PersonWriteRepository : Repository<Person, Guid>, IPersonWriteRepository
    {
        public PersonWriteRepository(GasmaToolsContext context) : base(context)
        {

        }
    }
}
