namespace Assignment_4_ExpenseTracker.MessageServices
{
    public static class ConsoleReader
    {
        internal static string? GetInput()
        {
            string? userInput = Console.ReadLine();
            return userInput;
        }
    }
}