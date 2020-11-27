using MediatR;
using System;

namespace gasmaTools.Abstraction.Events
{
    public abstract class Message : IRequest<bool>
    {
        public Guid EntityId { get; protected set; }
        public string MessageType { get; protected set; }

        protected Message()
        {
            this.MessageType = GetType().Name;
        }
    }
}
