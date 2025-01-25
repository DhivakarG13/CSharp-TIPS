public static class MessageService
{
    public static void PrintMainDialog()
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine("-------Inventory__Manager-------");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Main Menu :\n");
        Console.WriteLine("[1] Create  New Storage Slot");
        Console.WriteLine("[2] Check  your Storage Slot");
        Console.WriteLine("[3] Add New Product to your Slot");
        Console.WriteLine("[4] Add Products to your Slot");
        Console.WriteLine("[5] Fetch Product from your Slot");
        Console.WriteLine("[6] Delete your Storage");
        Console.WriteLine("[7] Close Application\n\n");
    }

    public static void PrintSearchDialog()
    {
        Console.WriteLine("Search By :");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("[1] Name");
        Console.WriteLine("[2] User Id");
        Console.WriteLine("[3] Product Id\n\n");
    }

    public static void GetUserInfoWriter(string? TypeOfData)
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write($"{TypeOfData}");
        Console.ResetColor();
    }

    public static void PrintError(string? ErrorMessage)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{ErrorMessage}");
        Console.ResetColor();
    }

    public static void PrintWarning(string? WarningMessage)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"{WarningMessage}");
        Console.ResetColor();
    }

    public static void PrintActionComplete(string? Message)
    {
        Console.WriteLine("---------------------------");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{Message}");
        Console.ResetColor();
        Console.WriteLine("---------------------------\n\n\n");
        Console.WriteLine("Press Any Key to continue");
        Console.ReadKey();
    }

    public static void PrintActionFailed(string? Message)
    {
        Console.WriteLine("---------------------------");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"{Message}");
        Console.ResetColor();
        Console.WriteLine("---------------------------\n\n\n");
        Console.WriteLine("Press Any Key to continue");
        Console.ReadKey();
    }

}
