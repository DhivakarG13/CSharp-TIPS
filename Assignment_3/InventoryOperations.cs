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

        string? userName = UserInputService.GetUserName();
        string? productName = UserInputService.GetProductName();
        int productQuantity = UserInputService.GetProductQuantity();

        StorageSlot storageSlot = new StorageSlot(userName, productName, productQuantity, inventory);

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
        if (searchDialogChoice == 1) //Search By Name
        {
            foundIndex = SearchByName(Inventory);
        }
        else if (searchDialogChoice == 2)
        {
            foundIndex = SearchByUserId(Inventory);
        }
        else if (searchDialogChoice == 3)
        {
            foundIndex = SearchByProductId(Inventory);
        }
        return foundIndex;
    }

    public static int SearchByName(List<StorageSlot> inventory)
    {
        string? userName = UserInputService.GetUserName();
        List<int> foundIndexes = new List<int>();
        int index = 0;

        foreach (StorageSlot slot in inventory)
        {
            if (slot.UserInfo != null)
                if (slot.UserInfo.UserName == userName)
                {
                    foundIndexes.Add(index);
                }
            index++;
        }

        if (foundIndexes.Count == 0)
        {
            Console.Clear();
            MessageService.PrintError("\n\nNo results Match Your Search\n\n");
            MessageService.PrintActionFailed("Search Failed");
            return -1;
        }
        else if (foundIndexes.Count > 1)
        {
            MessageService.PrintWarning("More than One results Match your search ," +
                " For User privacy search by UserId ");
            index = SearchByUserId(inventory);
            return index;
        }
        else if (foundIndexes.Count == 1)
        {
            inventory[foundIndexes[0]].UserInfo.PrintUserDetails();
            inventory[foundIndexes[0]].PrintTimingDetails();
            Console.WriteLine($"Total Sub Slots : {inventory[foundIndexes[0]].Products.Count}");
            return foundIndexes[0];
        }
        return -1;
    }

    public static int SearchByUserId(List<StorageSlot> inventory)
    {
        int userId = UserInputService.GetId();
        int index = 0;

        foreach (StorageSlot slot in inventory)
        {
            if (slot.UserInfo != null)
            {
                if (slot.UserInfo.UserId == userId)
                {
                    slot.UserInfo.PrintUserDetails();
                    if (slot.Products != null)
                    {
                        Console.WriteLine($"Total Sub Slots : {slot.Products.Count}");
                    }
                    slot.PrintTimingDetails();
                    return index;
                }
            }
            index++;
        }
        Console.Clear();
        MessageService.PrintError("\n\nNo results Match Your Search\n\n");
        MessageService.PrintActionFailed("Search Failed");
        return -1;
    }

    public static int SearchByProductId(List<StorageSlot> inventory)
    {
        int productId = UserInputService.GetId();
        int index = 0;

        foreach (StorageSlot slot in inventory)
        {
            if (slot.Products != null)
            {
                foreach (Product product in slot.Products)
                {
                    if (product.ProductId == productId && slot.UserInfo != null)
                    {
                        slot.UserInfo.PrintUserDetails();
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
