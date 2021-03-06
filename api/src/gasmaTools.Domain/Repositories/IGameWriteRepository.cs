﻿using gasmaTools.Abstraction.Data;
using gasmaTools.Domain.Entities;
using System;

namespace gasmaTools.Domain.Repositories
{
    public interface IGameWriteRepository : IWriteRepository<Game, Guid>
    {
    }
}
