using gasmaTools.Abstraction.Events;

namespace gasmaTools.Domain.Events.Login
{
    public class InsertLoginEvent : Event
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }

        public InsertLoginEvent(string email, string fullName)
        {
            Email = email;
            FullName = fullName;
        }
    }
}
