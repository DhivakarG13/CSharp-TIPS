using ConsoleTables;

public static class MessageService
{
    public static void DialogWriter(Enum Dialog)
    {
        foreach (var option in Enum.GetValues(Dialog.GetType()))
        {
            Console.WriteLine($"   [{(int)option}]  {option}");
        }
    }
    public static void GetUserInfoWriter(string? TypeOfData)
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write($"{TypeOfData}");
        Console.ResetColor();
    }
    public static void PrintProductDetails(List<Product> productsToPrint)
    {
        ConsoleTable table = new ConsoleTable("Index", "ProductName", "ProductId", "ProductPrice", "ProductQuantity", "ExpiryDate}");

        for (int productIndex = 0; productIndex < productsToPrint.Count; productIndex++)
        {
            table.AddRow($"{productIndex}",productsToPrint[productIndex].ProductName,
                productsToPrint[productIndex].ProductId,productsToPrint[productIndex].ProductPrice,
                productsToPrint[productIndex].Quantity,productsToPrint[productIndex].ExpiryDate );
            
        }
        table.Write();
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
        Console.Write("Try Again :");
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
