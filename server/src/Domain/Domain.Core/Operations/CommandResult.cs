using FluentValidation.Results;

namespace Domain.Core.Operations
{
    public class CommandResult
    {
	    public ValidationResult ValidationResult { get; set; }
        public object Data {get; set;}

        public bool HasErrors => ValidationResult != null && ValidationResult.IsValid == false;
    }
}