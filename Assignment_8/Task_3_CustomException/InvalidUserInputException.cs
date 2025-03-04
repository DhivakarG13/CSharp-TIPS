namespace CustomException
{
    public class InvalidUserInputException : Exception
    {
        public int StatusCode { get; }

        public InvalidUserInputException(string message, int statusCode)
            : base(message)
        {
            StatusCode = statusCode;
        }

        public InvalidUserInputException(string message, int statusCode, Exception innerException)
            : base(message, innerException)
        {
            StatusCode = statusCode;
        }

        public InvalidUserInputException()
            : this("Invalid user input", 400)
        {
        }

        public InvalidUserInputException(string message)
            : this(message, 400)
        {
        }

        public InvalidUserInputException(string message, Exception innerException)
            : this(message, 400, innerException)
        {
        }
    }
}
