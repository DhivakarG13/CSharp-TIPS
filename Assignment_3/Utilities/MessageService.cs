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
    public static void PrintProductDetails(Product product)
    {
        Console.WriteLine("{0,-10} {1,-10} {2,-5} {3,-5} {4,-10}", product.ProductName, product.ProductId, product.ProductPrice , product.Quantity, product.ExpiryDate);
        
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
