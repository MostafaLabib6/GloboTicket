
using FluentValidation.Results;
namespace GloboTicket.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public IEnumerable<string> ErrorList { get; } = new List<string>();
        public ValidationException(ValidationResult validationResult)
        {
            foreach (var exception in validationResult.Errors)
            {
                ErrorList.Append(exception.ErrorMessage);
            }
        }
    }
}
