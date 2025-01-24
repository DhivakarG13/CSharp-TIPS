public class InventoryManager
{
    private List<StorageSlot> Inventory = new List<StorageSlot>();

    InventoryOperations inventoryOperation = new InventoryOperations();

    internal void Run()
    {
        bool CloseFlag = false;
        int FoundIndex = -1;

        while (true)
        {
            DialogAndEventWriterUtility.PrintMainDialog();
            int MainDialogChoice = inventoryOperation.GetUserChoice(new
                    List<int> { 1, 2, 3, 4, 5, 6, 7 });

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

                    if (FoundIndex == -1)
                    {
                        break;
                    }
                    else
                    {
                        Inventory[FoundIndex].ResetLastAccessTime();
                    }

                    switch (MainDialogChoice)
                    {
                        case 2:
                            {
                                DialogAndEventWriterUtility.PrintActionComplete("Search Done");
                                break;
                            }
                        case 3:   //Add New Product slot
                            {
                                string? NewProductName = UserDetailFetchUtility.GetProductName();
                                bool IsProductNew = UserDataValidators.IsNewProduct(NewProductName, Inventory[FoundIndex].Products);
                                if (IsProductNew)
                                {
                                    int NewProductQuantity = UserDetailFetchUtility.GetProductQuantity();
                                    Inventory[FoundIndex].CreateNewProductSpace(NewProductName, NewProductQuantity);
                                    DialogAndEventWriterUtility.PrintActionComplete("New product added");
                                }
                                else //Adding to existing slot as the name search Matches the existing product
                                {
                                    int ProductQuantity = UserDetailFetchUtility.GetProductQuantity();
                                    Inventory[FoundIndex].AddProducts(NewProductName, ProductQuantity);
                                    DialogAndEventWriterUtility.PrintActionComplete("Adding to existing slot as the name search Matches the existing product");
                                }
                                break;
                            }
                        case 4:    //Add Products to Existing Slot
                            {
                                string? ProductName = UserDetailFetchUtility.GetProductName();
                                bool IsValid = UserDataValidators.IsNewProduct(ProductName, Inventory[FoundIndex].Products);
                                if (IsValid)
                                {
                                    Console.Clear();
                                    DialogAndEventWriterUtility.PrintError("\n\nNo results Match Your Search\n\n");
                                    DialogAndEventWriterUtility.PrintActionFailed(" Unavailable :( ");
                                    break;
                                }
                                else
                                {
                                    int ProductQuantity = UserDetailFetchUtility.GetProductQuantity();
                                    Inventory[FoundIndex].AddProducts(ProductName, ProductQuantity);
                                    DialogAndEventWriterUtility.PrintActionComplete("Products Added :)");
                                    break;
                                }
                            }
                        case 5:  //Fetch Product from your Slot
                            {
                                string? ProductName = UserDetailFetchUtility.GetProductName();
                                bool IsValid = UserDataValidators.IsNewProduct(ProductName, Inventory[FoundIndex].Products);
                                if (IsValid)
                                {
                                    DialogAndEventWriterUtility.PrintActionFailed("Product Unavailable");
                                    break;
                                }
                                else
                                {
                                    int ProductQuantity = UserDetailFetchUtility.GetProductQuantity();
                                    Inventory[FoundIndex].FetchProducts(ProductName, ProductQuantity);
                                    DialogAndEventWriterUtility.PrintActionComplete("Fetch Successful:)");
                                    break;
                                }
                            }
                        case 6:   // Deleting Slot
                            {
                                Inventory.RemoveAt(FoundIndex);
                                DialogAndEventWriterUtility.PrintActionComplete("Your Slot Deleted and Items are Retrieved :)");
                                break;
                            }
                    }
                    break;

                case 7://Closes the Application

                    CloseFlag = true;
                    break;

            }

            Console.Clear();

            if (CloseFlag)
            {
                break;
            }

        }
    }
}
