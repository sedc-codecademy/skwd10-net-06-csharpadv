namespace TaxiManager9000.Domain.Exceptions
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException(string? message) : base(message)
        {
        }
    }
}
