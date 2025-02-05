using Inventory.Helpers;

public class InventoryDataBase
{
    public List<Product> Products { get; }

    public InventoryDataBase()
    {
        Products = new List<Product>();
    }


    public void AddProduct()
    {
        Console.WriteLine("----------------------------------");
        Console.WriteLine(" ------ Adding New Product ------ ");
        Console.WriteLine("----------------------------------\n");

        string? productName = UserInputService.GetProductName();
        int productQuantity = UserInputService.GetProductQuantity();
        decimal productPrize = UserInputService.GetProductPrice();
        Console.WriteLine("::Setting Product ID::");
        int productID = SetNewProductId();
        DateOnly expiryDate = UserInputService.GetProductExpiryDate();
        Products.Add(new Product(productName, productQuantity, productPrize, productID, expiryDate));
    }
    public void DeleteProduct(List<Product> ProductsToDelete)
    {

        Console.WriteLine("----------------------------------");
        Console.WriteLine(" ----- Deleting Your Product ---- ");
        Console.WriteLine("----------------------------------\n");

        if (ProductsToDelete.Count() > 0)
        {
            InventoryOperations.PrintProducts(ProductsToDelete);
            Console.Write("\n\n Choose an index to Delete");
            int indexToDelete = UserInputService.GetUserProductIndexChoice(ProductsToDelete.Count());
            Products.Remove(ProductsToDelete[indexToDelete]);
        }
    }

    public void EditProductDetails(List<Product> ProductsToEdits)
    {
        if (ProductsToEdits.Count() > 0)
        {

            Console.WriteLine("----------------------------------");
            Console.WriteLine(" ----- Editing Your Product ----- ");
            Console.WriteLine("----------------------------------");

            InventoryOperations.PrintProducts(ProductsToEdits);
            Console.WriteLine("\n\n Choose an index to Edit");

            int indexToEdit = UserInputService.GetUserProductIndexChoice(ProductsToEdits.Count());
            Product productToEdit = ProductsToEdits[indexToEdit];
            while (true)
            {
                MessageService.DialogWriter(new EditDialog());
                EditDialog editDialogChoice = (EditDialog)UserInputService.GetUserChoice(new
                        List<int> { 1, 2, 3, 4, 5 });

                switch (editDialogChoice)
                {
                    case EditDialog.Edit_ProductName:
                        {
                            productToEdit.SetProductName(UserInputService.GetProductName());
                            break;
                        }
                    case EditDialog.Edit_ProductId:
                        {
                            int newProductID = SetNewProductId();
                            productToEdit.SetProductId(newProductID);
                            break;
                        }
                    case EditDialog.Edit_ProductQuantity:
                        {
                            productToEdit.SetProductQuantity(UserInputService.GetProductQuantity());
                            break;
                        }
                    case EditDialog.Edit_ProductPrice:
                        {
                            productToEdit.SetProductPrice(UserInputService.GetProductPrice());
                            break;
                        }
                    case EditDialog.Edit_ExpiryDate:
                        {
                            productToEdit.SetProductExpiryDate(UserInputService.GetProductExpiryDate());
                            break;
                        }
                }
                Console.WriteLine("\n\n Edit Another Entity ?");
                Console.WriteLine("::  [1] Yes  ::  [2] No  ::");
                int continueEditChoice = UserInputService.GetUserChoice(new
                        List<int> { 1, 2 });

                if (continueEditChoice == 2)
                {
                    break;
                }

            }
        }
    }

    public int SetNewProductId()
    {
        int productId = 0;
        MessageService.DialogWriter(new SetProductIdDialog());
        SetProductIdDialog setProductIdDialogChoice = (SetProductIdDialog)UserInputService.GetUserChoice(new
                List<int> { 1, 2 });

        switch (setProductIdDialogChoice)
        {
            case SetProductIdDialog.Set_Own_ID:
                bool isNewProductId = false;
                while (!isNewProductId)
                {
                    productId = UserInputService.GetProductId();

                    isNewProductId = ValidationService.ValidateNewProductId(productId, Products);
                    if(!isNewProductId)
                    {
                        MessageService.PrintWarning("A Product Exists with same productId");
                    }
                }
                break;
            case SetProductIdDialog.App_GenerateD_ID:
                {
                    productId = IdGenerateService.ProductIdGenerator(Products);
                    Console.WriteLine($"Your Product ID : {productId}");
                }
                break;
        }
        return productId;
    }
}