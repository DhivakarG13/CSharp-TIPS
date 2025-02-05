
public class InventoryManager
{
    private InventoryDataBase inventory = new InventoryDataBase();

    public void Run()
    {
        bool closeFlag = false;


        while (true)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine(" ------- INVENTORY MANAGER ------ ");
            Console.WriteLine("----------------------------------\n");


            List<Product> MatchingProducts = new List<Product>();
            MessageService.DialogWriter(new MainDialog());
            MainDialog mainDialogChoice = (MainDialog)UserInputService.GetUserChoice(new
                    List<int> { 1, 2, 3, 4, 5, 6, 7 });


            Console.Clear();

            switch (mainDialogChoice)
            {

                case MainDialog.Create_Product:
                    {
                        inventory.AddProduct();
                        MessageService.PrintActionComplete("New Product Added");
                        break;
                    }
                case MainDialog.Search_Product:
                    {
                        MatchingProducts = InventoryOperations.SearchInventory(inventory.Products);
                        InventoryOperations.PrintProducts(MatchingProducts);

                        if (MatchingProducts.Count > 0)
                        {
                            MessageService.PrintActionComplete("-- Search Complete --");
                        }
                        break;
                    }
                case MainDialog.Edit_Product_Details:
                    {
                        MatchingProducts = InventoryOperations.SearchInventory(inventory.Products);
                        if (MatchingProducts.Count > 0)
                        {
                            inventory.EditProductDetails(MatchingProducts);
                            MessageService.PrintActionComplete("-- Product Updated --");
                        }
                        break;
                    }
                case MainDialog.Delete_Product:
                    {
                        MatchingProducts = InventoryOperations.SearchInventory(inventory.Products);
                        if (MatchingProducts.Count > 0)
                        {
                            inventory.DeleteProduct(MatchingProducts);
                            MessageService.PrintActionComplete("-- Product Deleted --");
                        }
                        break;
                    }
                case MainDialog.View_All_Products:
                    {

                        Console.WriteLine("----------------------------------");
                        Console.WriteLine(" ----- Products in Inventory ---- ");
                        Console.WriteLine("----------------------------------");

                        MessageService.PrintProductDetails(inventory.Products);

                        if (inventory.Products.Count > 0)
                        {
                            MessageService.PrintActionComplete("-- Products available in the Inventory are displayed --");
                        }
                        break;
                    }
                case MainDialog.Exit_App:
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
