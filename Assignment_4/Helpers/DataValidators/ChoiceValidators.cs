




public static class ChoiceValidators
{
    public static bool ChoiceValidator(string? Choice,List<int> Range )
    {
        try
        {
            int ParsedChoice = int.Parse(Choice);
            if (Range.Contains(ParsedChoice))
            {
                return true;
            }
        }
        catch (ArgumentNullException)
        {
            ConsoleWriter.PrintWarning("Choose an Option to continue");
            return false;
        }
        catch (FormatException)
        {
            ConsoleWriter.PrintWarning("Enter a Valid Number to Continue");
            return false;
        }
        catch
        {
            ConsoleWriter.PrintWarning("Enter a Valid Number to Continue");
            return false;
        }
        ConsoleWriter.PrintWarning("Choose a valid Option to Continue");
        return false;
    }
}

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
    internal static bool ValidateNumericalInputs(string? NumericalValue)
    {
        try
        {
            int parsedValue = int.Parse(NumericalValue);
            if (parsedValue < 0)
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
        catch (ArgumentNullException)
        {
            ConsoleWriter.PrintWarning("Enter a Value to continue");
            return false;
        }
        return true;
    }

    internal static bool ValidateNewTransactionId(int newId, List<IFinance> financialRecord)
    {
        try
        {
            if (financialRecord.Count == 0)
            {
                return true;
            }
            foreach (IFinance Action in financialRecord)
            {
                if (Action.TransactionId == newId)
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