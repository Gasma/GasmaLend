using gasmaTools.Domain.Validations.Game;

namespace gasmaTools.Domain.Commands.Game
{
    public class ActivateGameValidation : GameValidation<ActivateGameCommand>
    {
        public ActivateGameValidation()
        {
            ValidateId();
        }
    }
}
