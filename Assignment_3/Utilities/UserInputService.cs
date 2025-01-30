public static class UserInputService
{
    public static string? GetUserName()
    {
        MessageService.GetUserInfoWriter("\nEnter User Name : ");
        bool isValidUserName = false;
        string? userName = null;

        while (!isValidUserName)
        {
            userName = Console.ReadLine();
            isValidUserName = ValidationService.ValidateUserName(userName);
        }
        return userName;
    }

    public static int GetProductQuantity()
    {
        MessageService.GetUserInfoWriter("Enter Quantity : ");
        bool isValidQuantity = false;
        string? productQuantity = null;

        while (!isValidQuantity)
        {
            productQuantity = Console.ReadLine();
            isValidQuantity = ValidationService.ValidateNumericalInputs(productQuantity);
        }

        int parsedProductQuantity = default;

        if (productQuantity != null)
        {
            isValidQuantity = int.TryParse(productQuantity, out parsedProductQuantity);
        }

        return parsedProductQuantity;
    }

    public static string? GetProductName()
    {
        MessageService.GetUserInfoWriter("Enter Product Name : ");
        bool isValidProductName = false;
        string? productName = null;

        while (!isValidProductName)
        {
            productName = Console.ReadLine();
            isValidProductName = ValidationService.ValidateProductName(productName);
        }
        return productName;
    }

    /// <summary>
    /// Gets user Id || product Id.
    /// </summary>
    /// <returns></returns>
    public static int GetId()
    {
        MessageService.GetUserInfoWriter("Enter Id : ");
        bool isValidId = false;
        string? userId = null;

        while (!isValidId)
        {
            userId = Console.ReadLine();
            isValidId = ValidationService.ValidateNumericalInputs(userId);
        }

        int parsedUserId = default;

        if (userId != null)
        {
            isValidId = int.TryParse(userId, out parsedUserId);
        }

        return parsedUserId;
    }
}
