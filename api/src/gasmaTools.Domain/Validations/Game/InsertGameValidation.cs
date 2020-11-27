using gasmaTools.Domain.Commands.Game;

namespace gasmaTools.Domain.Validations.Game
{
    public class InsertGameValidation : GameValidation<InsertGameCommand>
    {
        public InsertGameValidation()
        {
            ValidateName();
        }
    }
}
