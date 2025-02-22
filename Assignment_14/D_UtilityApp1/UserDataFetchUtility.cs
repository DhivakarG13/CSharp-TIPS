using C_DisplayApp;
using E_ValidateApp;

namespace D_UtilityApp
{
    public static class UserDataFetchUtility
    { 
        public static int GetNumericalInput(string inputTitle)
        {
            string? UserInput = string.Empty;
            while (true)
            {
                DisplayUtility.PrintInputTitle(inputTitle);
                UserInput = Console.ReadLine();
                if (ValidationUtility.NumericalInputValidate(UserInput))
                {
                    break;
                }
            }
            return int.Parse(UserInput);
        }

        public static int GetChoice(int totalChoices)
        {
            string? Choice = null;
            bool IsValidChoice = false;
            while (!IsValidChoice)
            {
                Console.Write("Enter Your Choice:");
                Choice = Console.ReadLine();
                IsValidChoice = ValidationUtility.ValidateChoice(Choice, totalChoices);
                Console.WriteLine();
            }
            IsValidChoice = int.TryParse(Choice, out int ParsedChoice);
            return ParsedChoice;
        }
    }
}
