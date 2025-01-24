public class StorageSlot
{
    public UserData? UserInfo { get; }

    public List<Product>? Products { get; }

    public DateTime TimeCreated { get; }

    public DateTime TimeLastAccessed { get; private set; }

    public StorageSlot(string? userName, string? productName,
        int productQuantity, List<StorageSlot> inventory)
    {
        if (userName != null)
        {
            UserInfo = new UserData(userName, inventory);
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
            UserInfo.PrintUserData();

            foreach (Product product in Products)
            {
                product.PrintProductData();
            }

            Console.WriteLine($"TIME CREATED       : {TimeCreated}");
            Console.WriteLine($"TIME LAST ACCESSED : {TimeLastAccessed}");

            TimeLastAccessed = DateTime.Now;
        }
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
        int FoundIndex = this.FindProduct(productName);
        if (Products != null)
        {
            if (FoundIndex != -1)
            {
                Products[FoundIndex].AddProducts(productQuantity);
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
        int FoundIndex = this.FindProduct(productName);

        if (Products != null)
        {
            if (Products[FoundIndex].Quantity < productQuantity)
            {
                DialogAndEventWriterUtility.PrintError("\nExceeded Limit\n");
                Products[FoundIndex].PrintProductData();
                DialogAndEventWriterUtility.PrintActionFailed("Fetch Failed");
            }
            if (FoundIndex != -1)
            {
                Products[FoundIndex].FetchProducts(productQuantity);
            }
        }
    }
}
