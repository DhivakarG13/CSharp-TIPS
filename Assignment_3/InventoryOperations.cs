using Inventory.Helpers;

public static class InventoryOperations
{
    public static int GetUserChoice(List<int> Range)
    {
        Console.Write("Enter your Choice:");
        bool isValidChoice = false;
        string? userChoice = null;

        while (!isValidChoice)
        {
            userChoice = Console.ReadLine();
            isValidChoice = ValidationService.ValidateChoice(userChoice, Range);
        }
        // Preventing Warnings
        int parsedChoice = -1;

        if (userChoice != null)
        {
            parsedChoice = int.Parse(userChoice);
        }
        return parsedChoice;
    }

    public static StorageSlot CreateNewStorageSlot(List<StorageSlot> inventory)
    {
        Console.Clear();
        Console.WriteLine("-------------------------------");
        Console.WriteLine("---Creating New Slot For You---");
        Console.WriteLine("-------------------------------");

        Console.WriteLine("\n\n----- :For User Name: At least 5 Characters required and At least 1 Alphabet required-----");
        Console.WriteLine("----- :For Product Name: At least 5 Characters required and no special characters or numbers are allowed-----");

        string? productName = UserInputService.GetProductName();
        int productQuantity = UserInputService.GetProductQuantity();

        StorageSlot storageSlot = new StorageSlot(productName, productQuantity);

        Console.Clear();
        storageSlot.PrintStorageSlotDetails();
        MessageService.PrintActionComplete("New Storage space created");

        return storageSlot;
    }

    public static int SearchInventory(List<StorageSlot> Inventory)
    {
        Console.Clear();
        MessageService.PrintSearchDialog();
        int searchDialogChoice = GetUserChoice(new List<int> { 1, 2, 3 });
        int foundIndex = -1;
        if (searchDialogChoice == 3)
        {
            foundIndex = SearchByProductId(Inventory);
        }
        return foundIndex;
    }

    public static int SearchByProductId(List<StorageSlot> inventory)
    {
        int productId = UserInputService.GetProductId();
        int index = 0;

        foreach (StorageSlot slot in inventory)
        {
            if (slot.Products != null)
            {
                foreach (Product product in slot.Products)
                {
                    if (product.ProductId == productId)
                    {
                        Console.WriteLine("YOUR PRODUCT :");
                        product.PrintProductDetails();
                        return index;
                    }
                }
                index++;
            }
        }
        Console.Clear();
        MessageService.PrintError("\n\nNo results Match Your Search\n\n");
        MessageService.PrintActionFailed("Search Failed");
        return -1;
    }

}
