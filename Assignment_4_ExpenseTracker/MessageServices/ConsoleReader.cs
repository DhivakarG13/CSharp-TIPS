namespace Assignment_4_ExpenseTracker.MessageServices
{
    public static class ConsoleReader
    {
        internal static string? GetInput()
        {
            string? Input = Console.ReadLine();
            return Input;
        }
    }
}