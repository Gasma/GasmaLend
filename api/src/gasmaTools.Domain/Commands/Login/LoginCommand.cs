using gasmaTools.Abstraction.Commands;

namespace gasmaTools.Domain.Commands.Login
{
    public abstract class LoginCommand : Command
    {
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string UserName { get; protected set; }
        public string FullName { get; protected set; }
        public string Token { get; protected set; }

        public void SetToken(string token)
        {
            Token = token;
        }
    }
}
