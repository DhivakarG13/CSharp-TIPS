// Ignore Spelling: Validators


public static class ConsoleWriter
{
    /// <summary>
    /// Prints the main dialog to show available operations to the user.
    /// </summary>
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
    /// <summary>
    /// Prints the available options for the user to search.
    /// </summary>
    internal static void PrintSearchDialog()
    {
        Console.WriteLine("Search By :");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("[1] Name");
        Console.WriteLine("[2] User Id\n\n");
    }
    /// <summary>
    /// Gets a Storage slot and prints all the data in the Storage slot.
    /// </summary>
    /// <param name="slot"></param>
    internal static void PrintSlotDetails(StorageSlot slot)
    {
        WriteUserData(slot.GetUserData());
        List<Product>? products = slot.GetProducts();
        foreach (Product product in products)
        {
            WriteProductData(product);
        }
        WriteTimeSlots(slot.GetCreatedTime(), slot.GetLastAccessedTime());
    }
    internal static void WriteUserData(UserData? userData) 
    {
        Console.WriteLine("USER NAME           : " + userData.GetName());
        Console.WriteLine("USER ID             : " + userData.GetId());
    }
    internal static void WriteProductData(Product product)
    {
        Console.WriteLine($"\nPRODUCT NAME       : {product.GetProductName()}");
        Console.WriteLine($"PRODUCT ID         : {product.GetProductId()}");
        Console.WriteLine($"AVAILABLE QUANTITY : {product.GetQuantity()}\n");
    }
    internal static void WriteTimeSlots(DateTime timeCreated, DateTime timeLastAccessed)
    {
        Console.WriteLine($"TIME CREATED       : {timeCreated}");
        Console.WriteLine($"TIME LAST ACCESSED : {timeLastAccessed}");
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
    internal static void PrintActionFailed(string? Message)
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
