using gasmaTools.Application.ViewModels;
using System;

namespace gasmaTools.Application.Interfaces
{
    public interface ILoginService : IDisposable
    {
        LoginViewModel GetById(Guid id);
        void Insert(LoginViewModel gameViewModel);
        string Login(LoginViewModel gameViewModel);
    }
}
