
public static class ValidateUserChoice
{
    public static bool ValidateChoice(string? Choice, List<int> Range)
    {

        if (Choice == null)
        {
            DialogAndEventWriterUtility.PrintWarning("Choose a Option to continue");
            return false;
        }
        try
        {
            int ParsedChoice = int.Parse(Choice);
            if (Range.Contains(ParsedChoice))
            {
                return true;
            }
        }
        catch (FormatException)
        {
            DialogAndEventWriterUtility.PrintWarning("Enter a Valid Number to Continue");
        }

        DialogAndEventWriterUtility.PrintWarning("Choose a valid Option to Continue");

        return false;

    }
}