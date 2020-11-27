using gasmaTools.Domain.Commands.Game;

namespace gasmaTools.Domain.Validations.Game
{
    public class InactivateGameValidation : GameValidation<InactivateGameCommand>
    {
        public InactivateGameValidation()
        {
            ValidateId();
        }
    }
}
