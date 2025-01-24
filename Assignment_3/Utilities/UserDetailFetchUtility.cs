
public static class UserDetailFetchUtility
{
    public static string? GetUserName()
    {
        DialogAndEventWriterUtility.GetUserInfoWriter("\nEnter User Name : ");
        bool IsValid = false;
        string? UserName = null;

        while (!IsValid)
        {
            UserName = Console.ReadLine();
            IsValid = UserDataValidators.ValidateUserName(UserName);
        }
        return UserName;
    }
    public static int GetProductQuantity()
    {
        DialogAndEventWriterUtility.GetUserInfoWriter("Enter Quantity : ");
        bool IsValid = false;
        string? ProductQuantity = null;

        while (!IsValid)
        {
            ProductQuantity = Console.ReadLine();
            IsValid = UserDataValidators.ValidateNumericalInputs(ProductQuantity);
        }

        int ParsedProductQuantity = default;

        if (ProductQuantity != null)
        {
            IsValid = int.TryParse(ProductQuantity, out ParsedProductQuantity);
        }

        return ParsedProductQuantity;
    }

    public static string? GetProductName()
    {
        DialogAndEventWriterUtility.GetUserInfoWriter("Enter Product Name : ");
        bool IsValid = false;
        string? ProductName = null;

        while (!IsValid)
        {
            ProductName = Console.ReadLine();
            IsValid = UserDataValidators.ValidateProductName(ProductName);
        }
        return ProductName;
    }
    public static int GetId()
    {
        DialogAndEventWriterUtility.GetUserInfoWriter("Enter Id : ");
        bool IsValid = false;
        string? UserId = null;

        while (!IsValid)
        {
            UserId = Console.ReadLine();
            IsValid = UserDataValidators.ValidateNumericalInputs(UserId);
        }

        int ParsedUserId = default;

        if (UserId != null)
        {
            IsValid = int.TryParse(UserId, out ParsedUserId);
        }

        return ParsedUserId;
    }
}
