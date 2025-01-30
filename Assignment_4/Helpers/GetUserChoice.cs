


public static class GetUserChoice
{
    public static int GetChoice(List<int> Range)
    {
        string? Choice = null;
        bool IsValidChoice = false;
        while (!IsValidChoice)
        {
            Console.Write("Enter Your Choice:");
            Choice = ConsoleReader.GetInput();
            IsValidChoice = ChoiceValidateUtility.ValidateChoice(Choice, Range);
            Console.WriteLine();
        }
        IsValidChoice = int.TryParse(Choice, out int ParsedChoice);
        return ParsedChoice; 
    }
}
