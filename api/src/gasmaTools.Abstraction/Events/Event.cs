using MediatR;

namespace gasmaTools.Abstraction.Events
{
    public abstract class Event : Message, INotification
    {
    }
}
