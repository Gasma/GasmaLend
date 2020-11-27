using FluentValidation.Results;
using gasmaTools.Abstraction.Events;
using System;

namespace gasmaTools.Abstraction.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}
