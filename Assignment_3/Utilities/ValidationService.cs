
public static class ValidationService
{
    public static bool ValidateChoice(string? Choice, List<int> Range)
    {

        if (Choice == null)
        {
            MessageService.PrintWarning("Choose a Option to continue");
            return false;
        }

        int ParsedChoice = default;
        bool IsParsable = false;
        IsParsable = int.TryParse(Choice, out ParsedChoice);

        if (!IsParsable)
        {
            MessageService.PrintWarning("Enter a Valid Number to Continue");
            return false;
        }
        if (Range.Contains(ParsedChoice))
        {
            return true;
        }

        MessageService.PrintWarning("Choose a valid Option to Continue");

        return false;

    }
    public static bool ValidateUserName(string? userName)
    {

        if (userName == null)
        {
            MessageService.PrintWarning("Enter a Value to Continue");
            return false;
        }
        userName = userName.Trim();
        if (userName.Length < 4)
        {
            MessageService.PrintWarning("At least 5 Characters required");
            return false;
        }
        else if (!userName.Any(char.IsAsciiLetterOrDigit))
        {
            MessageService.PrintWarning("No Numerical values or special characters are allowed in Name");
            return false;
        }
        else if (userName.Any(char.IsWhiteSpace))
        {
            MessageService.PrintWarning("No Space allowed InBetween");
            return false;
        }

        return true;

    }

    public static bool ValidateNumericalInputs(string? productQuantity)
    {

        if (productQuantity == null)
        {
            MessageService.PrintWarning("Enter a Value to continue");
            return false;
        }

        int parsedQuantity;

        bool IsInteger = int.TryParse(productQuantity, out parsedQuantity);

        if (IsInteger == false)
        {
            MessageService.PrintWarning("Numerical values Expected");
            return false;
        }
        if (parsedQuantity < 0)
        {
            MessageService.PrintWarning("Negative numbers NotAllowed");
            return false;
        }

        return true;

    }

    public static bool ValidateProductName(string? productName)
    {

        if (productName == null)
        {
            MessageService.PrintWarning("Enter a Value to Continue");
            return false;
        }
        productName = productName.Trim();
        if (productName.Length < 4)
        {
            MessageService.PrintWarning("At least 5 Characters required");
            return false;
        }
        else if (!productName.Any(char.IsLetter))
        {
            MessageService.PrintWarning("Should Contain at least an Alphabet");
            return false;
        }
        else if (productName.Any(char.IsWhiteSpace))
        {
            MessageService.PrintWarning("No Space allowed InBetween");
            return false;
        }

        return true;

    }

    public static bool IsExistingProduct(string? newProductName, List<Product>? products)
    {
        if (products != null)
        {
            if (products.Count == 0)
            {
                return false;
            }
            foreach (Product product in products)
            {
                if (newProductName == product.ProductName)
                {
                    return true;
                }
            }
        }

        return true;

    }

    public static bool ValidateNewProductId(int NewId, List<Product> existingProducts)
    {
        if (existingProducts.Count == 0)
        {
            return true;
        }
        foreach (Product product in existingProducts)
        {
            if (product.ProductId == NewId)
            {
                return false;
            }
        }

        return true;

    }

    public static bool ValidateNewUserId(int newId, List<StorageSlot> inventory)
    {
        if (inventory.Count == 0)
        {
            return true;
        }
        foreach (StorageSlot storageSlot in inventory)
        {
            if (storageSlot.UserInfo != null)
            {
                if (storageSlot.UserInfo.UserId == newId)
                {
                    return false;
                }
            }
        }
        return true;

    }

}