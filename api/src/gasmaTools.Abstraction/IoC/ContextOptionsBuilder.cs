using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using System;

namespace gasmaTools.Abstraction.Data
{
    public class ContextOptionsBuilder : IContextOptionsBuilder
    {
        public string ConnectionString { get; private set; }

        public string MigrationsAssemblyName { get; private set; }

        public ContextOptionsBuilder(string connectionString)
        {
            this.ConnectionString = !string.IsNullOrEmpty(connectionString)
                ? connectionString : throw new ArgumentNullException(nameof(connectionString));
        }

        public ContextOptionsBuilder(string connectionString, string migrationsAssembly)
        : this(connectionString)
        {
            this.MigrationsAssemblyName = migrationsAssembly;
        }

        public Action<DbContextOptionsBuilder> Builder()
        {
            Action<NpgsqlDbContextOptionsBuilder> sqlOptions = null;
            if (!string.IsNullOrEmpty(this.MigrationsAssemblyName))
                sqlOptions = (options) => options.MigrationsAssembly(this.MigrationsAssemblyName);

            return options => options.UseNpgsql(ConnectionString, sqlOptions);
        }
    }
}
