

public static class ChoiceValidateUtility
{
    public static bool ValidateChoice(string? Choice, List<int> Range)
    {
        if (Choice == null || Choice.Length == 0)
        {
            ConsoleWriter.PrintWarning("Choose an Option to continue");
            return false;
        }
        bool IsValidChoice = false;
        IsValidChoice = int.TryParse(Choice, out int ParsedChoice);
        if (!IsValidChoice)
        {
            ConsoleWriter.PrintWarning("Enter a Valid Number to Continue");
            return false;
        }
        else if (Range.Contains(ParsedChoice))
        {
            return true;
        }
        else
        {

            ConsoleWriter.PrintWarning("Choose a valid Option to Continue");
            return false;
        }

    }
}
