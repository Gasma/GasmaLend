using gasmaTools.Domain.Commands.Game;

namespace gasmaTools.Domain.Validations.Game
{
    public class GiveBackGameValidation : GameValidation<GiveBackGameCommand>
    {
        public GiveBackGameValidation()
        {
            ValidateId();
        }
    }
}
