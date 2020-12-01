using gasmaTools.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace gasmaTools.Application.Interfaces
{
    public interface IGameService : IDisposable
    {
        GameViewModel GetById(Guid id);
        IEnumerable<GameViewModel> GetAll();
        GameViewModel Insert(GameViewModel gameViewModel);
        void Update(GameViewModel gameViewModel);
        void Activate(Guid id);
        void Inactivate(Guid id);
        void GiveBack(Guid id);
        void Lend(Guid id, Guid personId);
    }
}
