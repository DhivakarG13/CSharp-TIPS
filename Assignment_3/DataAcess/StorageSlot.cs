using System.Collections.Generic;

public class StorageSlot
{
    private UserData? _userInfo;
    private List<Product>? _products = new List<Product>();
    private DateTime _timeCreated;
    private DateTime _timeLastAccessed;

    
    public StorageSlot(string? userName, string? productName,
        int productQuantity, List<StorageSlot> inventory)
    {
        _userInfo = new UserData(userName, inventory);
        AddNewProduct(productName, productQuantity);
        _timeCreated = DateTime.Now;
        _timeLastAccessed = DateTime.Now;
    }

    internal UserData? GetUserData() => _userInfo;
    internal string? GetUserName() => _userInfo.GetName();
    internal int GetUserId() => _userInfo.GetId();
    internal List<Product>? GetProducts() => _products;
    internal DateTime GetCreatedTime() => _timeCreated;
    internal DateTime GetLastAccessedTime() => _timeLastAccessed;

    internal void PrintDetails()
    {
        ConsoleWriter.PrintSlotDetails(this);
        _timeLastAccessed = DateTime.Now;
    }

    public void AddNewProduct(string? productName , int productQuantity)
    {
        Product newProduct = new Product(productName, productQuantity , _products);
        _products.Add(newProduct);
    }
    public void ResetLastAccessTime()
    {
        _timeLastAccessed = DateTime.Now;    
    }
    public void AddProducts(string? productName,int productQuantity)
    {
        int FoundIndex = this.FindProduct(productName);
        if(FoundIndex != -1)
        {
            _products[FoundIndex].AddProducts(productQuantity);
        }
    }

    private int FindProduct(string? productName)
    {
        int index = 0;
        foreach (Product product in _products)
        {
            if (product.GetProductName() == productName)
            {
                return index;
            }
            index++;
        }
        Console.WriteLine("Product Not Found");
        return -1;
    }

    public void FetchProducts(string? productName, int productQuantity)
    {
        int FoundIndex = this.FindProduct(productName);
        if(_products[FoundIndex].GetQuantity() < productQuantity)
        {
            ConsoleWriter.PrintError("\nExceeded Limit\n");
            ConsoleWriter.WriteProductData(_products[FoundIndex]);
            ConsoleWriter.PrintActionFailed("Fetch Failed");
        }
        if (FoundIndex != -1)
        {
            _products[FoundIndex].FetchProducts(productQuantity);
        }
    }
}
