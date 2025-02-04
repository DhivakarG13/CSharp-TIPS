public static class UserInputService
{
    public static int GetUserChoice(List<int> Range)
    {
        Console.Write("\nEnter your Choice:");
        bool isValidChoice = false;
        string? userChoice = null;
        int parsedChoice = default;
        while (!isValidChoice)
        {
            userChoice = Console.ReadLine();
            isValidChoice = ValidationService.ValidateChoice(userChoice, Range);
            int.TryParse(userChoice, out parsedChoice);
        }
        return parsedChoice;
    }
    public static int GetUserProductIndexChoice(int totalProducts)
    {
        Console.WriteLine("Enter your Choice:");
        bool isValidChoice = false;
        string? userChoice = null;
        int parsedChoice = default;
        while (!isValidChoice)
        {
            userChoice = Console.ReadLine();
            isValidChoice = ValidationService.ValidateProductIndexChoice(userChoice, totalProducts);
            int.TryParse(userChoice, out parsedChoice);
        }
        return parsedChoice;
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
        if(productName != null)
        {
            productName = productName.Trim();
        }
        return productName;
    }

    public static int GetProductId()
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

    public static int GetProductPrice()
    {
        MessageService.GetUserInfoWriter("Enter Price : ");
        bool isValidPrice = false;
        string? productPrice = null;

        while (!isValidPrice)
        {
            productPrice = Console.ReadLine();
            isValidPrice = ValidationService.ValidatePrice(productPrice);
        }

        int parsedPrice = default;

        if (productPrice != null)
        {
            isValidPrice = int.TryParse(productPrice, out parsedPrice);
        }

        return parsedPrice;
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

    public static DateOnly GetProductExpiryDate()
    {
        MessageService.GetUserInfoWriter("Enter ExpiryDate : ");
        bool isValidDate = false;
        DateOnly expiryDate = default;

        while (!isValidDate)
        {
            isValidDate = DateOnly.TryParse(Console.ReadLine(), out expiryDate);
            if (!isValidDate)
            {
                MessageService.PrintWarning("Expected Format DD/MM/YYYY");
            }
        }
        return expiryDate;
    }
    public static string? GetStringInput(string typeOfData)
    {
        MessageService.GetUserInfoWriter($"Enter {typeOfData} : ");
        bool isValidStringValue = false;
        string? stringValue = null;

        while (!isValidStringValue)
        {
            stringValue = Console.ReadLine();
            isValidStringValue = ValidationService.ValidateStringValue(stringValue);
        }
        return stringValue;
    }

    public static int GetNumericalValue(string typeOfValue)
    {
        MessageService.GetUserInfoWriter($"Enter {typeOfValue} : ");
        bool isValidNumericalValue = false;
        string? numericalValue = null;
        int parsedNumericalValue = default;

        while (!isValidNumericalValue)
        {
            numericalValue = Console.ReadLine();
            isValidNumericalValue = int.TryParse(numericalValue, out parsedNumericalValue);
            if(!isValidNumericalValue)
            {
                MessageService.PrintWarning("Enter a Proper Number");
            }
        }

        return parsedNumericalValue;
    }

    
}
