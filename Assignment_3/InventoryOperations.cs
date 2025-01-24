public class InventoryOperations
{
    public int GetUserChoice(List<int> Range)
    {
        Console.Write("Enter your Choice:");

        bool IsValid = false;
        string? Choice = null;

        while (!IsValid)
        {
            Choice = Console.ReadLine();
            IsValid = ValidateUserChoice.ValidateChoice(Choice, Range);
        }

        // Preventing Warnings
        int ParsedChoice = -1;

        if (Choice != null)
        {
            ParsedChoice = int.Parse(Choice);
        }

        return ParsedChoice;

    }

    internal StorageSlot CreateNewStorageSlot(List<StorageSlot> inventory)
    {
        Console.Clear();

        Console.WriteLine("-------------------------------");
        Console.WriteLine("---Creating New Slot For You---");
        Console.WriteLine("-------------------------------");

        string? userName = UserDetailFetchUtility.GetUserName();
        string? productName = UserDetailFetchUtility.GetProductName();
        int productQuantity = UserDetailFetchUtility.GetProductQuantity();

        StorageSlot storageSlot = new StorageSlot(userName, productName, productQuantity, inventory);
        Console.Clear();

        storageSlot.PrintStorageSlotDetails();

        DialogAndEventWriterUtility.PrintActionComplete("New Storage space created");

        return storageSlot;

    }

    internal int SearchInventory(List<StorageSlot> Inventory)
    {

        Console.Clear();
        DialogAndEventWriterUtility.PrintSearchDialog();
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

        string? userName = UserDetailFetchUtility.GetUserName();
        List<int> foundIndexes = new List<int>();
        int index = 0;

        foreach (StorageSlot slot in Inventory)
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
            DialogAndEventWriterUtility.PrintError("\n\nNo results Match Your Search\n\n");
            DialogAndEventWriterUtility.PrintActionFailed("Search Failed");
            return -1;
        }
        else if (foundIndexes.Count > 1)
        {
            DialogAndEventWriterUtility.PrintWarning("More than One results Match your search ," +
                " For User privacy search by UserId ");
            index = SearchById(Inventory);
            return index;
        }
        else if (foundIndexes.Count == 1)
        {
            Inventory[foundIndexes[0]].PrintStorageSlotDetails();
            return foundIndexes[0];
        }

        return -1;

    }

    private int SearchById(List<StorageSlot> Inventory)
    {

        int UserId = UserDetailFetchUtility.GetId();
        int index = 0;

        foreach (StorageSlot slot in Inventory)
        {
            if (slot.UserInfo != null)
            {
                if (slot.UserInfo.UserId == UserId)
                {
                    slot.PrintStorageSlotDetails();
                    return index;
                }
            }
            index++;
        }

        Console.Clear();
        DialogAndEventWriterUtility.PrintError("\n\nNo results Match Your Search\n\n");
        DialogAndEventWriterUtility.PrintActionFailed("Search Failed");
        return -1;

    }



}
