using gasmaTools.Abstraction.Bus;
using gasmaTools.Abstraction.Commands;
using gasmaTools.Abstraction.Data;
using gasmaTools.Abstraction.Domain.Notifications;
using MediatR;

namespace gasmaTools.Abstraction.Domain.CommandHandlers
{
    public class CommandHandler
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMediatorHandler mediator;
        private readonly DomainNotificationHandler domainNotifications;

        public CommandHandler(IUnitOfWork unitOfWork, IMediatorHandler mediator, INotificationHandler<DomainNotification> domainNotifications)
        {
            this.unitOfWork = unitOfWork;
            this.mediator = mediator;
            this.domainNotifications = (DomainNotificationHandler)domainNotifications;
        }

        protected void NotifyValidationErrors(Command command)
        {
            foreach (var erro in command.ValidationResult?.Errors)
            {
                mediator.RaiseEventAsync(new DomainNotification(command.MessageType, erro.ErrorMessage));
            }
        }

        public bool Commit()
        {
            if (domainNotifications.HasNotification()) return false;
            if (unitOfWork.Commit()) return true;

            mediator.RaiseEventAsync(new DomainNotification("Commit", "Houve um problema ao salvar os dados!"));
            return false;
        }
    }
}
