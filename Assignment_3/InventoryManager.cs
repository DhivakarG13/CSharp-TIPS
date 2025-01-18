
// Ignore Spelling: Validators

public class InventoryManager
{
    private List<StorageSlot> Inventory = new List<StorageSlot>();
    InventoryOperations inventoryOperation =new InventoryOperations();
    
    internal void Run()
    {
        bool CloseFlag = false;
        int FoundIndex = -1;

        while (true)
        {
            ConsoleWriter.PrintMainDialog();
            int MainDialogChoice = inventoryOperation.GetUserChoice(new 
                List<int>{ 1, 2, 3, 4, 5, 6, 7 });

            switch (MainDialogChoice)
            {
                case 1://Create new Storage space
                    Inventory.Add(inventoryOperation.CreateNewStorageSlot(Inventory));
                    break;
                case 2://Check Your Storage slot
                case 3://Add New Product slot
                case 4://Add Products to your Slot
                case 5://Fetch Product from your Slot
                case 6://Delete your Storage
                    FoundIndex = inventoryOperation.SearchInventory(Inventory);
                    if(FoundIndex == -1 )
                    {
                        break;
                    }
                    else
                    {
                        Inventory[FoundIndex].ResetLastAccessTime();
                    }
                    if(MainDialogChoice == 2)
                    {
                        ConsoleWriter.PrintActionComplete("Search Done");
                    }
                    if(MainDialogChoice == 3)//Add New Product slot
                    {
                        string? NewProductName = GetUserDetails.GetProductName();
                        bool IsValid = UserDataValidators.IsNewProduct(NewProductName, Inventory[FoundIndex].GetProducts());
                        if(IsValid)
                        {
                            int NewProductQuantity = GetUserDetails.GetProductQuantity();
                            Inventory[FoundIndex].AddNewProduct(NewProductName, NewProductQuantity);
                            ConsoleWriter.PrintActionComplete("New product added");
                        }
                        else //Adding to existing slot as the name search Matches the existing product
                        {
                            int ProductQuantity = GetUserDetails.GetProductQuantity();
                            Inventory[FoundIndex].AddProducts(NewProductName, ProductQuantity);
                            ConsoleWriter.PrintActionComplete("Adding to existing slot as the name search Matches the existing product");
                        }
                        break;
                    }
                    if(MainDialogChoice == 4)//Add Products to Existing Slot
                    {
                        string? ProductName = GetUserDetails.GetProductName();
                        bool IsValid = UserDataValidators.IsNewProduct(ProductName, Inventory[FoundIndex].GetProducts());
                        if (IsValid)
                        {
                            Console.Clear();
                            ConsoleWriter.PrintError("\n\nNo results Match Your Search\n\n");
                            ConsoleWriter.PrintActionFailed(" Unavailable :( ");
                            break;
                        }
                        else
                        {
                            int ProductQuantity = GetUserDetails.GetProductQuantity();
                            Inventory[FoundIndex].AddProducts(ProductName, ProductQuantity);
                            ConsoleWriter.PrintActionComplete("Products Added :)");
                            break;
                        }
                    }
                    if (MainDialogChoice == 5)//Fetch Product from your Slot
                    {
                        string? ProductName = GetUserDetails.GetProductName();
                        bool IsValid = UserDataValidators.IsNewProduct(ProductName, Inventory[FoundIndex].GetProducts());
                        if (IsValid)
                        {
                            ConsoleWriter.PrintActionFailed("Product Unavailable");
                            break;
                        }
                        else
                        {
                            int ProductQuantity = GetUserDetails.GetProductQuantity();
                            Inventory[FoundIndex].FetchProducts(ProductName, ProductQuantity);
                            ConsoleWriter.PrintActionComplete("Fetch Successful:)");
                            break;
                        }
                    }
                    if (MainDialogChoice == 6) // Deleting Slot
                    {
                        Inventory.RemoveAt(FoundIndex);
                        ConsoleWriter.PrintActionComplete("Your Slot Deleted and Items are Retrieved :)");
                        break;
                    }
                    break;
                case 7://Closes the Application
                    CloseFlag = true;
                    break;
            }
            Console.Clear();
            if(CloseFlag)
            {
                break;
            }
        }
    }
}
