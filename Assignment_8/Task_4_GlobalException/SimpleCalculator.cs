public static class SimpleCalculator
{
    public static int Divide10ByInput(int userInput)
    {
        if (userInput == 0)
        {
            throw new InvalidUserInputException("Zero is an invalid input");
        }
        return 10 / userInput;
    }
}
