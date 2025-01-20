


public static class GetUserChoice
{
    internal static int GetChoice(List<int> Range)
    {
        string? Choice = null;
        bool IsValid = false;
        while (!IsValid)
        {
            Console.Write("Enter Your Choice:");
            Choice = ConsoleReader.GetInput();
            IsValid = ChoiceValidators.ChoiceValidator(Choice, Range);
            Console.WriteLine();
        }
        return int.Parse(Choice); 
    }
}
