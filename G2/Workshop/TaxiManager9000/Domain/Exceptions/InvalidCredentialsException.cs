namespace TaxiManager9000.Domain.Exceptions
{
    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException(string? message) : base(message)
        {
        }
    }
}
