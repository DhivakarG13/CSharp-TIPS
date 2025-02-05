
public static class ValidationService
{
    public static bool ValidateChoice(string? choice, List<int> Range)
    {

        if (choice == null)
        {
            MessageService.PrintWarning("Choose a Option to continue");
            return false;
        }

        int parsedChoice = default;
        bool isParse_Able = false;
        isParse_Able = int.TryParse(choice, out parsedChoice);

        if (!isParse_Able)
        {
            MessageService.PrintWarning("Enter a Valid Number to Continue");
            return false;
        }
        if (Range.Contains(parsedChoice))
        {
            return true;
        }

        MessageService.PrintWarning("Choose a valid Option to Continue");
        return false;
    }
    public static bool ValidateProductIndexChoice(string? userChoice, int totalElements)
    {
        if (userChoice == null)
        {
            MessageService.PrintWarning("Choose a Option to continue");
            return false;
        }

        int parsedChoice = default;
        bool isParse_Able = false;
        isParse_Able = int.TryParse(userChoice, out parsedChoice);

        if (!isParse_Able)
        {
            MessageService.PrintWarning("Enter a Valid Number to Continue");
            return false;
        }
        if (parsedChoice < totalElements && parsedChoice >= 0)
        {
            return true;
        }

        MessageService.PrintWarning("Choose a valid Option to Continue");
        return false;
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

    public static bool ValidatePrice(string? priceValue)
    {
        if (priceValue == null)
        {
            MessageService.PrintWarning("Enter a Price to continue");
            return false;
        }

        int parsedPriceValue;

        bool isInteger = int.TryParse(priceValue, out parsedPriceValue);

        if (isInteger == false)
        {
            MessageService.PrintWarning("Numerical values Expected");
            return false;
        }
        if (parsedPriceValue < 0)
        {
            MessageService.PrintWarning("Negative numbers NotAllowed");
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

        return false;
    }

    public static bool ValidateNewProductId(int NewId, List<Product> existingProducts)
    {
        if (NewId > 9999 || NewId < 1000)
        {
            MessageService.PrintWarning(" User ID is a four digit Number");
            return false;
        }
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

    public static bool ValidateNumericalInputs(string? numericalValue)
    {

        if (numericalValue == null)
        {
            MessageService.PrintWarning("Enter a Value to continue");
            return false;
        }

        int parsedNumericalValue;

        bool isInteger = int.TryParse(numericalValue, out parsedNumericalValue);

        if (isInteger == false)
        {
            MessageService.PrintWarning("Numerical values Expected");
            return false;
        }
        if (parsedNumericalValue < 0)
        {
            MessageService.PrintWarning("Negative numbers NotAllowed");
            return false;
        }

        return true;
    }

    public static bool ValidateStringValue(string? stringValue)
    {
        if (string.IsNullOrEmpty(stringValue))
        {
            MessageService.PrintWarning("Enter a proper string to continue");
            return false;
        }
        stringValue = stringValue.Trim();
        if (stringValue.Length < 3)
        {
            MessageService.PrintWarning("At least 3 Characters Expected");
            MessageService.PrintWarning("Outer Spaces are not considered");
            return false;
        }
        return true;
    }

    
}