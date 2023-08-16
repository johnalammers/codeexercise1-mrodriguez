namespace CSharpCodeReview1.Domain.Models.Exceptions
{
    public class EmployeeParsingException : Exception
    {
        public EmployeeParsingException(string message, Exception inner) : base(message, inner) { }
    }
}
