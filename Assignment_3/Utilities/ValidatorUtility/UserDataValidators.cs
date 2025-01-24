
public static class UserDataValidators
{
    public static bool ValidateUserName(string? userName)
    {

        if (userName == null)
        {
            DialogAndEventWriterUtility.PrintWarning("Enter a Value to Continue");
            return false;
        }
        userName = userName.Trim();
        if (userName.Length < 4)
        {
            DialogAndEventWriterUtility.PrintWarning("At least 5 Characters required");
            return false;
        }
        else if (userName.Any(char.IsDigit))
        {
            DialogAndEventWriterUtility.PrintWarning("No Numerical values are allowed in Name");
            return false;
        }
        else if (userName.Any(char.IsWhiteSpace))
        {
            DialogAndEventWriterUtility.PrintWarning("No Space allowed InBetween");
            return false;
        }

        return true;

    }

    public static bool ValidateNumericalInputs(string? productQuantity)
    {

        if (productQuantity == null)
        {
            DialogAndEventWriterUtility.PrintWarning("Enter a Value to continue");
            return false;
        }

        int parsedQuantity;

        bool IsInteger = int.TryParse(productQuantity, out parsedQuantity);

        if (IsInteger == false)
        {
            DialogAndEventWriterUtility.PrintWarning("Numerical values Expected");
            return false;
        }
        if (parsedQuantity < 0)
        {
            DialogAndEventWriterUtility.PrintWarning("Negative numbers NotAllowed");
            return false;
        }

        return true;

    }

    public static bool ValidateProductName(string? productName)
    {

        if (productName == null)
        {
            DialogAndEventWriterUtility.PrintWarning("Enter a Value to Continue");
            return false;
        }
        productName = productName.Trim();
        if (productName.Length < 4)
        {
            DialogAndEventWriterUtility.PrintWarning("At least 5 Characters required");
            return false;
        }
        else if (!productName.Any(char.IsLetter))
        {
            DialogAndEventWriterUtility.PrintWarning("Should Contain at least an Alphabet");
            return false;
        }
        else if (productName.Any(char.IsWhiteSpace))
        {
            DialogAndEventWriterUtility.PrintWarning("No Space allowed InBetween");
            return false;
        }

        return true;

    }

    public static bool IsNewProduct(string? newProductName, List<Product>? products)
    {
        try
        {
            if (products != null)
            {
                if (products.Count == 0)
                {
                    return true;
                }
                foreach (Product product in products)
                {
                    if (newProductName == product.ProductName)
                    {
                        return false;
                    }
                }
            }
        }
        catch (ArgumentNullException)
        {
            return true;
        }

        return true;

    }

    public static bool ValidateNewProductId(int NewId, List<Product> existingProducts)
    {
        try
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
        }
        catch
        {
            return false;
        }

        return true;

    }

    public static bool ValidateNewUserId(int newId, List<StorageSlot> inventory)
    {
        try
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
        }
        catch
        {
            return false;
        }

        return true;

    }

}