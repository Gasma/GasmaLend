using Microsoft.EntityFrameworkCore;
using System;

namespace gasmaTools.Abstraction.Data
{
    public interface IContextOptionsBuilder
    {
        string ConnectionString { get; }
        string MigrationsAssemblyName { get; }
        Action<DbContextOptionsBuilder> Builder();
    }
}
