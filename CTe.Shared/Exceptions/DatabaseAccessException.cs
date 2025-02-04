

namespace CTe.Shared.Exceptions
{
    public class DatabaseAccessException : Exception
    {
        public DatabaseAccessException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
