public class SimpleCalculator : IDisposable
{
    public int Divide10ByInput(int userInput)
    {
        if (userInput == 0)
        {
            throw new InvalidUserInputException("Zero is an invalid input");
        }
        return 10 / userInput;
    }

    public void Dispose()
    {
    }
}
