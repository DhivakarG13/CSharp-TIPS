
public static class UserInputService
{
    public static string? GetUserName()
    {
        MessageService.GetUserInfoWriter("\nEnter User Name : ");
        bool IsValidUserName = false;
        string? UserName = null;

        while (!IsValidUserName)
        {
            UserName = Console.ReadLine();
            IsValidUserName = ValidationService.ValidateUserName(UserName);
        }
        return UserName;
    }
    public static int GetProductQuantity()
    {
        MessageService.GetUserInfoWriter("Enter Quantity : ");
        bool IsValidQuantity = false;
        string? ProductQuantity = null;

        while (!IsValidQuantity)
        {
            ProductQuantity = Console.ReadLine();
            IsValidQuantity = ValidationService.ValidateNumericalInputs(ProductQuantity);
        }

        int ParsedProductQuantity = default;

        if (ProductQuantity != null)
        {
            IsValidQuantity = int.TryParse(ProductQuantity, out ParsedProductQuantity);
        }

        return ParsedProductQuantity;
    }

    public static string? GetProductName()
    {
        MessageService.GetUserInfoWriter("Enter Product Name : ");
        bool IsValidProductName = false;
        string? ProductName = null;

        while (!IsValidProductName)
        {
            ProductName = Console.ReadLine();
            IsValidProductName = ValidationService.ValidateProductName(ProductName);
        }
        return ProductName;
    }
    /// <summary>
    /// Gets user Id || product Id.
    /// </summary>
    /// <returns></returns>
    public static int GetId()
    {
        MessageService.GetUserInfoWriter("Enter Id : ");
        bool IsValidId = false;
        string? UserId = null;

        while (!IsValidId)
        {
            UserId = Console.ReadLine();
            IsValidId = ValidationService.ValidateNumericalInputs(UserId);
        }

        int ParsedUserId = default;

        if (UserId != null)
        {
            IsValidId = int.TryParse(UserId, out ParsedUserId);
        }

        return ParsedUserId;
    }
}
