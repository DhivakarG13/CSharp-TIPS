public static class UserDataValidateUtility
{
    public static bool ValidateSource(string? userName)
    {
        if ((userName == null) || userName.Length == 0)
        {
            ConsoleWriter.PrintWarning("Enter a Value to Continue");
            return false;
        }
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
        return true;
    }
    public static bool ValidateNumericalInputs(string? NumericalValue)
    {
        if ((NumericalValue == null) || NumericalValue.Length == 0)
            if ((NumericalValue == null) || NumericalValue.Length == 0)
            {
                ConsoleWriter.PrintWarning("Enter a Value to Continue");
                return false;
            }
        bool IsValidNumber = false;
        IsValidNumber = int.TryParse(NumericalValue, out int ParsedNumber);
        if (!IsValidNumber)
        {
            ConsoleWriter.PrintWarning("Enter a Valid Number to Continue");
            return false;
        }
        return true;
    }

    public static bool ValidateNewTransactionId(int newId, List<IFinance> financialRecord)
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
        return true;
    }

    public static bool ValidateDateInputs(string? ActionDate)
    {
        if (DateTime.TryParse(ActionDate, out DateTime userDateTime))
        {
            return true;
        }
        else
        {
            ConsoleWriter.PrintWarning("You have entered an incorrect value expected Format -> 10/22/1987");
            return false;
        }
    }
}