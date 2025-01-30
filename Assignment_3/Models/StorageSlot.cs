public class StorageSlot
{
    public UserDetails? UserInfo { get; }
    public List<Product>? Products { get; }
    public DateTime TimeCreated { get; }
    public DateTime TimeLastAccessed { get; private set; }

    public StorageSlot(string? userName, string? productName,
        int productQuantity, List<StorageSlot> inventory)
    {
        if (userName != null)
        {
            UserInfo = new UserDetails(userName, inventory);
            Products = new List<Product>();
            CreateNewProductSpace(productName, productQuantity);
            TimeCreated = DateTime.Now;
            TimeLastAccessed = DateTime.Now;
        }
    }

    public void PrintStorageSlotDetails()
    {
        if (UserInfo != null && Products != null)
        {
            UserInfo.PrintUserDetails();

            foreach (Product product in Products)
            {
                product.PrintProductDetails();
            }
            PrintTimingDetails();
            TimeLastAccessed = DateTime.Now;
        }
    }
    public void ViewAllProducts()
    {
        Console.WriteLine("Press [V] to view all your product Details or [C] to continue");
        while (true)
        {
            ConsoleKeyInfo InputKey = Console.ReadKey();
            if (InputKey.Key == ConsoleKey.V)
            {
                if (Products != null)
                {
                    foreach (Product product in Products)
                    {
                        product.PrintProductDetails();
                    }
                }
                break;
            }
            else if (InputKey.Key == ConsoleKey.C)
            {
                break;
            }
            else
            {
                Console.WriteLine("Press an valid Key");
            }
        }
    }

    public void PrintTimingDetails()
    {
        Console.WriteLine($"TIME CREATED       : {TimeCreated}");
        Console.WriteLine($"TIME LAST ACCESSED : {TimeLastAccessed}");
    }
    public void ResetLastAccessTime()
    {
        TimeLastAccessed = DateTime.Now;
    }

    public void CreateNewProductSpace(string? productName, int productQuantity)
    {
        if (Products != null)
        {
            Product newProduct = new Product(productName, productQuantity, Products);
            Products.Add(newProduct);
        }
    }

    public void AddProducts(string? productName, int productQuantity)
    {
        int foundIndex = this.FindProduct(productName);
        if (Products != null)
        {
            if (foundIndex != -1)
            {
                Products[foundIndex].AddProducts(productQuantity);
            }
        }
    }

    private int FindProduct(string? productName)
    {
        int index = 0;
        if (Products != null)
        {
            foreach (Product product in Products)
            {
                if (product.ProductName == productName)
                {
                    return index;
                }
                index++;
            }
        }
        Console.WriteLine("Product Not Found");
        return -1;
    }

    public void FetchProducts(string? productName, int productQuantity)
    {
        int foundIndex = this.FindProduct(productName);

        if (Products != null)
        {
            if (Products[foundIndex].Quantity < productQuantity)
            {
                MessageService.PrintError("\nExceeded Limit\n");
                Products[foundIndex].PrintProductDetails();
                MessageService.PrintActionFailed("Fetch Failed");
            }
            else if (foundIndex != -1)
            {
                Products[foundIndex].FetchProducts(productQuantity);
                MessageService.PrintActionComplete("Fetch Successful:)");
            }
        }
    }
}