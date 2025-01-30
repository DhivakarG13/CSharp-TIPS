public class InventoryManager
{
    private List<StorageSlot> Inventory = new List<StorageSlot>();

    public void Run()
    {
        bool closeFlag = false;
        int storageSlotIndex = -1;

        //Add Description For Actions
        //Go Back To Prev Page
        //View all products

        while (true)
        {
            MessageService.PrintMainDialog();
            int mainDialogChoice = InventoryOperations.GetUserChoice(new
                    List<int> { 1, 2, 3, 4, 5, 6, 7 });

            switch (mainDialogChoice)
            {
                case 1://Create new Storage space

                    Inventory.Add(InventoryOperations.CreateNewStorageSlot(Inventory));
                    break;

                case 2://Check Your Storage slot
                    {
                        storageSlotIndex = InventoryOperations.SearchInventory(Inventory);
                        if (storageSlotIndex == -1)
                        {
                            break;
                        }
                        Inventory[storageSlotIndex].ViewAllProducts();
                        Inventory[storageSlotIndex].ResetLastAccessTime();
                        MessageService.PrintActionComplete("Search Done");
                        break;
                    }
                case 3://Add New Product slot
                    {
                        storageSlotIndex = InventoryOperations.SearchInventory(Inventory);

                        if (storageSlotIndex == -1)
                        {
                            break;
                        }

                        string? newProductName = UserInputService.GetProductName();
                        bool isProductAlreadyExists = ValidationService.IsExistingProduct(newProductName, Inventory[storageSlotIndex].Products);
                        if (isProductAlreadyExists)//Adding to existing slot as the name search Matches the existing product
                        {
                            int productQuantity = UserInputService.GetProductQuantity();
                            Inventory[storageSlotIndex].AddProducts(newProductName, productQuantity);
                            MessageService.PrintActionComplete("Adding to existing slot as the name search Matches the existing product");
                        }
                        else 
                        {
                            int newProductQuantity = UserInputService.GetProductQuantity();
                            Inventory[storageSlotIndex].CreateNewProductSpace(newProductName, newProductQuantity);
                            MessageService.PrintActionComplete("New product added");
                        }
                        Inventory[storageSlotIndex].ResetLastAccessTime();

                        break;
                    }
                case 4://Add Products to your Slot
                    {
                        storageSlotIndex = InventoryOperations.SearchInventory(Inventory);

                        if (storageSlotIndex == -1)
                        {
                            break;
                        }
                        string? productName = UserInputService.GetProductName();
                        bool isProductFound = ValidationService.IsExistingProduct(productName, Inventory[storageSlotIndex].Products);
                        if (isProductFound)
                        {
                            int ProductQuantity = UserInputService.GetProductQuantity();
                            Inventory[storageSlotIndex].AddProducts(productName, ProductQuantity);
                            MessageService.PrintActionComplete("Products Added :)");
                            Inventory[storageSlotIndex].ResetLastAccessTime();
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
                        storageSlotIndex = InventoryOperations.SearchInventory(Inventory);

                        if (storageSlotIndex == -1)
                        {
                            break;
                        }
                        string? productName = UserInputService.GetProductName();
                        bool isProductFound = ValidationService.IsExistingProduct(productName, Inventory[storageSlotIndex].Products);
                        if (isProductFound)
                        {
                            int ProductQuantity = UserInputService.GetProductQuantity();
                            Inventory[storageSlotIndex].FetchProducts(productName, ProductQuantity);
                            Inventory[storageSlotIndex].ResetLastAccessTime();
                        }
                        else
                        {
                            MessageService.PrintActionFailed("Product Unavailable");
                        }
                        break;
                    }
                case 6://Delete your Storage
                    {
                        int slotIndexToDelete = InventoryOperations.SearchInventory(Inventory);

                        if (slotIndexToDelete == -1)
                        {
                            break;
                        }
                        Inventory.RemoveAt(slotIndexToDelete);
                        MessageService.PrintActionComplete("Your Slot Deleted and Items are Retrieved :)");
                        break;
                    }

                case 7://Closes the Application
                    {
                        closeFlag = true;
                        break;
                    }
            }

            Console.Clear();

            if (closeFlag)
            {
                break;
            }

        }
    }
}
