using gasmaTools.Domain.Commands.Game;

namespace gasmaTools.Domain.Validations.Game
{
    public class UpdateGameValidation : GameValidation<UpdateGameCommand>
    {
        public UpdateGameValidation()
        {
            ValidateId();
            ValidateName();
        }
    }
}
