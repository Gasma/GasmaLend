using System;
using System.Threading.Tasks;

namespace gasmaTools.Abstraction.Data
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
        Task<bool> CommitAsync();
    }
}
