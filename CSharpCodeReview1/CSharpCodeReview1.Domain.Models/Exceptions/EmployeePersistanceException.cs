namespace CSharpCodeReview1.Domain.Models.Exceptions
{
    public class EmployeePersistanceException : Exception
    {
        public EmployeePersistanceException(string message, Exception inner) : base(message, inner) { }
    }
}
