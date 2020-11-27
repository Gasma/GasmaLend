using gasmaTools.Abstraction.Data;
using gasmaTools.Infra.Data.Context;
using System.Threading.Tasks;

namespace gasmaTools.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GasmaToolsContext context;

        public UnitOfWork(GasmaToolsContext context)
        {
            this.context = context;
        }

        public bool Commit()
        {
            return context.SaveChanges() > 0;
        }

        public Task<bool> CommitAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                return Commit();
            });
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
