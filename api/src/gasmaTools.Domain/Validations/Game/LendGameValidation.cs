using gasmaTools.Domain.Commands.Game;

namespace gasmaTools.Domain.Validations.Game
{
    public class LendGameValidation : GameValidation<LendGameCommand>
    {
        public LendGameValidation()
        {
            ValidateId();
            ValidatePersonId();
        }
    }
}
