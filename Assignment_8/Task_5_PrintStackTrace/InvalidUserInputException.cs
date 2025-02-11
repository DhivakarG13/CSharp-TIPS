namespace Task_5
{
    public class  InvalidUserInputException : Exception
    {
        int StatusCode;
        //public InvalidUserInputException()
        //{
            
        //}
        public InvalidUserInputException(string message , int statusCode): base(message) 
        {
            StatusCode = statusCode;
        }
        public InvalidUserInputException(string message , int statusCode , Exception innerException) : base(message , innerException) 
        {
            StatusCode = statusCode;
        }

        public InvalidUserInputException(string message = "Invalid User Input Exception is thrown")
        : base(message)
        {
            
        }
        public InvalidUserInputException(string message, Exception innerException)
        : base(message, innerException)
        {
            
        }
    }
}
