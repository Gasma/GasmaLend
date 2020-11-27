using MediatR;
using System;

namespace gasmaTools.Abstraction.Events
{
    public interface IEvent : INotification
    {
        DateTime Timestamp { get; }
    }
}
