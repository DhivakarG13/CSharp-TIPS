using C_DisplayApp;

namespace E_ValidateApp
{
    public static class ValidationUtility
    {
        public static bool NumericalInputValidate(string userInput)
        {
            if(string.IsNullOrEmpty(userInput))
            {
                DisplayUtility.PrintError("Enter a value to continue");
                return false;
            }
            int parsedUserInput = default;
            if(int.TryParse(userInput, out parsedUserInput) == false)
            {
                DisplayUtility.PrintError("Expected input -> Number");
                return false;
            }
            return true;
        }

        public static bool ValidateChoice(string? Choice, int TotalChoices)
        {
            if (Choice == null || Choice.Length == 0)
            {
                DisplayUtility.PrintError("Enter a value to continue");
                return false;
            }
            bool IsValidChoice = false;
            IsValidChoice = int.TryParse(Choice, out int ParsedChoice);
            if (!IsValidChoice)
            {
                DisplayUtility.PrintError("Expected input -> Number");
                return false;
            }
            if (ParsedChoice > 0 && ParsedChoice <= TotalChoices)
            {
                return true;
            }
            else
            {
                DisplayUtility.PrintError("Choice Out Of Range");
                return false;
            }

        }
    }
}
