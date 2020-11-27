using gasmaTools.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace gasmaTools.Application.Interfaces
{
    public interface IPersonService : IDisposable
    {
        PersonViewModel GetById(Guid id);
        IEnumerable<PersonViewModel> GetAll();
        void Insert(PersonViewModel personViewModel);
        void Update(PersonViewModel personViewModel);
        void Activate(Guid id);
        void Inactivate(Guid id);
    }
}
