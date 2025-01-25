public class InventoryManager
{
    private List<StorageSlot> Inventory = new List<StorageSlot>();


    InventoryOperations inventoryOperation = new InventoryOperations();

    public void Run()
    {
        bool CloseFlag = false;
        int StorageSlotIndex = -1;

        //Add Description For Actions
        //Go Back To Prev Page
        //View all products

        while (true)
        {
            MessageService.PrintMainDialog();
            int MainDialogChoice = inventoryOperation.GetUserChoice(new
                    List<int> { 1, 2, 3, 4, 5, 6, 7 });

            switch (MainDialogChoice)
            {
                case 1://Create new Storage space

                    Inventory.Add(inventoryOperation.CreateNewStorageSlot(Inventory));
                    break;

                case 2://Check Your Storage slot
                    {

                        StorageSlotIndex = inventoryOperation.SearchInventory(Inventory);
                        if (StorageSlotIndex == -1)
                        {
                            break;
                        }
                        Inventory[StorageSlotIndex].ViewAllProducts();
                        Inventory[StorageSlotIndex].ResetLastAccessTime();
                        MessageService.PrintActionComplete("Search Done");
                        break;
                    }
                case 3://Add New Product slot
                    {
                        StorageSlotIndex = inventoryOperation.SearchInventory(Inventory);

                        if (StorageSlotIndex == -1)
                        {
                            break;
                        }

                        string? NewProductName = UserInputService.GetProductName();
                        bool IsProductAlreadyExists = ValidationService.IsExistingProduct(NewProductName, Inventory[StorageSlotIndex].Products);
                        if (IsProductAlreadyExists)
                        {
                            int ProductQuantity = UserInputService.GetProductQuantity();
                            Inventory[StorageSlotIndex].AddProducts(NewProductName, ProductQuantity);
                            MessageService.PrintActionComplete("Adding to existing slot as the name search Matches the existing product");
                        }
                        else //Adding to existing slot as the name search Matches the existing product
                        {
                            int NewProductQuantity = UserInputService.GetProductQuantity();
                            Inventory[StorageSlotIndex].CreateNewProductSpace(NewProductName, NewProductQuantity);
                            MessageService.PrintActionComplete("New product added");
                        }
                        Inventory[StorageSlotIndex].ResetLastAccessTime();

                        break;
                    }
                case 4://Add Products to your Slot
                    {
                        StorageSlotIndex = inventoryOperation.SearchInventory(Inventory);

                        if (StorageSlotIndex == -1)
                        {
                            break;
                        }
                        string? ProductName = UserInputService.GetProductName();
                        bool IsProductFound = ValidationService.IsExistingProduct(ProductName, Inventory[StorageSlotIndex].Products);
                        if (IsProductFound)
                        {
                            int ProductQuantity = UserInputService.GetProductQuantity();
                            Inventory[StorageSlotIndex].AddProducts(ProductName, ProductQuantity);
                            MessageService.PrintActionComplete("Products Added :)");
                            Inventory[StorageSlotIndex].ResetLastAccessTime();
                        }
                        else
                        {
                            Console.Clear();
                            MessageService.PrintError("\n\nNo results Match Your Search\n\n");
                            MessageService.PrintActionFailed(" Unavailable :( ");
                        }
                        break;
                    }
                case 5://Fetch Product from your Slot
                    {
                        StorageSlotIndex = inventoryOperation.SearchInventory(Inventory);

                        if (StorageSlotIndex == -1)
                        {
                            break;
                        }
                        string? ProductName = UserInputService.GetProductName();
                        bool IsProductFound = ValidationService.IsExistingProduct(ProductName, Inventory[StorageSlotIndex].Products);
                        if (IsProductFound)
                        {
                            int ProductQuantity = UserInputService.GetProductQuantity();
                            Inventory[StorageSlotIndex].FetchProducts(ProductName, ProductQuantity);
                            MessageService.PrintActionComplete("Fetch Successful:)");
                            Inventory[StorageSlotIndex].ResetLastAccessTime();
                        }
                        else
                        {
                            MessageService.PrintActionFailed("Product Unavailable");
                        }
                        break;
                    }
                case 6://Delete your Storage
                    {
                        int SlotIndexToDelete = inventoryOperation.SearchInventory(Inventory);

                        if (SlotIndexToDelete == -1)
                        {
                            break;
                        }
                        Inventory.RemoveAt(SlotIndexToDelete);
                        MessageService.PrintActionComplete("Your Slot Deleted and Items are Retrieved :)");
                        break;
                    }

                case 7://Closes the Application
                    {
                        CloseFlag = true;
                        break;
                    }
            }

            Console.Clear();

            if (CloseFlag)
            {
                break;
            }

        }
    }
}
