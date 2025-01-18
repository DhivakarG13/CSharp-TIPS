
// Ignore Spelling: Validator

public static class GetUserDetails
{
    public static string? GetUserName()
    {
        ConsoleWriter.GetUserInfoWriter("Enter User Name : ");
        bool IsValid = false;
        string? UserName = null;

        while (!IsValid)
        {
            UserName = ConsoleReader.GetInput();
            IsValid = UserDataValidators.ValidateUserName(UserName);
        }
        return UserName;
    }
    public static int GetProductQuantity()
    {
        ConsoleWriter.GetUserInfoWriter("Enter Quantity : ");
        bool IsValid = false;
        string? ProductQuantity = null;

        while (!IsValid)
        {
            ProductQuantity = ConsoleReader.GetInput();
            IsValid = UserDataValidators.ValidateNumericalInputs(ProductQuantity);
        }
        return int.Parse(ProductQuantity);
    }

    public static string? GetProductName()
    {
        ConsoleWriter.GetUserInfoWriter("Enter Product Name : ");
        bool IsValid = false;
        string? ProductName = null;

        while (!IsValid)
        {
            ProductName = ConsoleReader.GetInput();
            IsValid = UserDataValidators.ValidateProductName(ProductName);
        }
        return ProductName;
    }
    public static int GetId()
    {
        ConsoleWriter.GetUserInfoWriter("Enter Id : ");
        bool IsValid = false;
        string? UserId = null;

        while (!IsValid)
        {
            UserId = ConsoleReader.GetInput();
            IsValid = UserDataValidators.ValidateNumericalInputs(UserId);
        }
        return int.Parse(UserId);
    }
}
