

using System;

public static class ConsoleWriter
{
    internal static void PrintMainDialog()
    {
        Console.WriteLine("---------------------------");
        Console.WriteLine("------Expense Tracker------");
        Console.WriteLine("---------------------------\n\n");
        Console.WriteLine(":   Main Menu      :\n");
        int index = 1;
        foreach (string value in Enum.GetNames(typeof(UserOptions)))
        {
            Console.WriteLine($":   [{index}] {value}      :");
            index++;
        }
        Console.WriteLine("\n\n");
    }
    internal static void PrintIncomeDialog()
    {
        Console.WriteLine("Available Options:");
        int index = 1;
        foreach (string value in Enum.GetNames(typeof(IncomeOption)))
        {
            Console.WriteLine($"[{index}] {value}   ");
            index++;
        }
    }
    internal static void PrintExpenseDialog()
    {
        Console.WriteLine("Available Options:");
        int index = 1;
        foreach (string value in Enum.GetNames(typeof(ExpenseOption)))
        {
            Console.WriteLine($"[{index}] {value}   ");
            index++;
        }
    }
    internal static void PrintSearchDialog()
    {
        Console.WriteLine("Available Options:");
        int index = 1;
        foreach (string value in Enum.GetNames(typeof(SearchOption)))
        {
            Console.WriteLine($"[{index}] {value}   ");
            index++;
        }
    }
    internal static void PrintSearchByActionDialog()
    {
        Console.WriteLine("Available Options:");
        int index = 1;
        foreach (string value in Enum.GetNames(typeof(Actions)))
        {
            Console.WriteLine($"[{index}] {value}   ");
            index++;
        }
    }
    internal static void GetUserInfoWriter(string? TypeOfData)
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write($"{TypeOfData}");
        Console.ResetColor();
    }
    internal static void PrintError(string? ErrorMessage)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{ErrorMessage}");
        Console.ResetColor();
    }
    internal static void PrintBalance(int Balance)
    {
        if(Balance < 0)
        {
            PrintError($"Available Balance : {Balance}");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Available Balance : {Balance}");
            Console.ResetColor();
        }
    }
    internal static void PrintWarning(string? WarningMessage)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"{WarningMessage}");
        Console.ResetColor();
    }
    internal static void PrintActionComplete(string? Message)
    {
        Console.WriteLine("---------------------------");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{Message}");
        Console.ResetColor();
        Console.WriteLine("---------------------------\n\n\n");
        Console.WriteLine("Press Any Key to continue");
        Console.ReadKey();
    }

    internal static void ActionWriter(string? action, int amount, int transactionId)
    {
        Console.WriteLine(action);
        Console.WriteLine($"Amount : {amount}");
        Console.WriteLine($"Transaction Id :{transactionId}");
    }
}
