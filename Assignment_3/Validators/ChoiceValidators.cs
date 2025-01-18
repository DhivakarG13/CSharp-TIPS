// Ignore Spelling: Validators


public static class ChoiceValidators
{
    public static bool ValidateChoice(string? Choice ,List<int> Range)
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
            ConsoleWriter.PrintWarning("Choose a Option to continue");
        }
        catch (FormatException)
        {
            ConsoleWriter.PrintWarning("Enter a Valid Number to Continue");
        }
        ConsoleWriter.PrintWarning("Choose a valid Option to Continue");
        return false;
    }
}