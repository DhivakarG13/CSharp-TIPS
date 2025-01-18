
// Ignore Spelling: Validators

public static class UserDataValidators
{
    internal static bool ValidateUserName(string? userName)
    {
        try
        {
            userName = userName.Trim();
            if (userName.Length < 4)
            {
                ConsoleWriter.PrintWarning("At least 5 Characters required");
                return false;
            }
            else if (userName.Any(char.IsDigit))
            {
                ConsoleWriter.PrintWarning("No Numerical values are allowed in Name");
                return false;
            }
            else if (userName.Any(char.IsWhiteSpace))
            {
                ConsoleWriter.PrintWarning("No Space allowed InBetween");
                return false;
            }
        }
        catch (ArgumentNullException)
        {
            ConsoleWriter.PrintWarning("Enter a Value to Continue");
            return false;
        }
        return true;
    }

    internal static bool ValidateNumericalInputs(string? productQuantity)
    {
        try
        {
            int parsedQuantity = int.Parse(productQuantity);
            if (parsedQuantity < 0)
            {
                ConsoleWriter.PrintWarning("Negative numbers NotAllowed");
                return false;
            }
        }
        catch (FormatException)
        {
            ConsoleWriter.PrintWarning("Numerical values Expected");
            return false;
        }
        catch(ArgumentNullException)
        {
            ConsoleWriter.PrintWarning("Enter a Value to continue");
            return false;
        }
        return true;
    }

    internal static bool ValidateProductName(string? productName)
    {
        try
        {
            productName = productName.Trim();
            if (productName.Length < 4)
            {
                ConsoleWriter.PrintWarning("At least 5 Characters required");
                return false;
            }
            else if (!productName.Any(char.IsLetter))
            {
                ConsoleWriter.PrintWarning("Should Contain at least an Alphabet");
                return false;
            }
            else if (productName.Any(char.IsWhiteSpace))
            {
                ConsoleWriter.PrintWarning("No Space allowed InBetween");
                return false;
            }
        }
        catch (ArgumentNullException)
        {
            ConsoleWriter.PrintWarning("Enter a Value to Continue");
            return false;
        }
        return true;
    }
    internal static bool IsNewProduct(string? newProductName, List<Product>? products)
    {
        try
        {
            if (products.Count == 0)
            {
                return true;
            }
            foreach (Product product in products)
            {
                if (newProductName == product.GetProductName())
                {
                    return false;
                }
            }
        }
        catch (ArgumentNullException)
        {
            return true;
        }
        return true;
    }
    internal static bool ValidateNewProductId(int NewId , List<Product> existingProducts)
    {
        try
        {
            if (existingProducts.Count == 0)
            {
                return true;
            }
            foreach (Product product in existingProducts)
            {
                if (product.GetProductId() == NewId)
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

    internal static bool ValidateNewUserId(int newId, List<StorageSlot> inventory)
    {
        try
        {
            if (inventory.Count == 0)
            {
                return true;
            }
            foreach (StorageSlot storageSlot in inventory)
            {
                if (storageSlot.GetUserId() == newId)
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

}