using System;
using Domain.Core.Operations;

namespace Domain.Core.Commands
{
    public class CommandHandler : IDisposable
    {
        public CommandHandler()
        {
            CommandResult = new CommandResult();
        }
        
        protected CommandResult CommandResult { get; set; }
        protected bool HasErrors => CommandResult.ValidationResult.IsValid == false;

        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}