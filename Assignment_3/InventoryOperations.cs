// Ignore Spelling: Validator

public class InventoryOperations
{
    public int GetUserChoice(List<int> Range)
    {
        Console.Write("Enter your Choice:");
        bool IsValid = false;
        string? Choice = null;
        while(!IsValid)
        {
            Choice = ConsoleReader.GetInput();
            IsValid = ChoiceValidators.ValidateChoice(Choice,Range);
        }
        return int.Parse(Choice);
    }
    internal StorageSlot CreateNewStorageSlot(List<StorageSlot> inventory)
    {
        Console.Clear();
        string? userName = GetUserDetails.GetUserName();
        string? productName = GetUserDetails.GetProductName();
        int productQuantity = GetUserDetails.GetProductQuantity();
        StorageSlot storageSlot = new StorageSlot(userName,productName, productQuantity, inventory);
        Console.Clear();
        ConsoleWriter.PrintSlotDetails(storageSlot);
        ConsoleWriter.PrintActionComplete("New Storage space created");
        return storageSlot;
    }

    internal int SearchInventory(List<StorageSlot> Inventory)
    {
        Console.Clear();
        ConsoleWriter.PrintSearchDialog();
        int SearchDialogChoice = GetUserChoice(new List<int> { 1, 2 });
        int FoundIndex = -1;
        if (SearchDialogChoice == 1) //Search By Name
        {
            FoundIndex = SearchByName(Inventory);
        }
        else
        {
            FoundIndex = SearchById(Inventory);
        }
        return FoundIndex;
    }
    private int SearchByName(List<StorageSlot> Inventory)
    {
        string? userName = GetUserDetails.GetUserName();
        List<int> foundIndeces = new List<int>();
        int index = 0;
        foreach (StorageSlot slot in Inventory)
        {
            if(slot.GetUserName() == userName)
            {
                foundIndeces.Add(index);
            }
            index++;
        }
        if(foundIndeces.Count == 0)
        {
            Console.Clear();
            ConsoleWriter.PrintError("\n\nNo results Match Your Search\n\n");
            ConsoleWriter.PrintActionFailed("Search Failed");
            return -1;
        }
        else if(foundIndeces.Count > 1 )
        {
            ConsoleWriter.PrintWarning("More than One results Match your search ," +
                " For User privacy search by UserId ");
            index = SearchById(Inventory);
            return index;
        }
        else if(foundIndeces.Count == 1)
        {
            Inventory[foundIndeces[0]].PrintDetails();
            return foundIndeces[0];
        }
        return -1;
    }
    private int SearchById(List<StorageSlot> Inventory)
    {
        int UserId = GetUserDetails.GetId();
        int index = 0;
        foreach (StorageSlot slot in Inventory)
        {
            if (slot.GetUserId() == UserId)
            {
                slot.PrintDetails();
                return index;
            }
            index++;
        }
            Console.Clear();
            ConsoleWriter.PrintError("\n\nNo results Match Your Search\n\n");
            ConsoleWriter.PrintActionFailed("Search Failed");
            return -1;
    }



}
