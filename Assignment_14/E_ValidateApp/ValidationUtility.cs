using C_DisplayApplication;

namespace E_ValidateApplication
{
    public static class ValidationUtility
    {
        public static bool ValidateNumericalInput(string? userInput)
        {
            if (string.IsNullOrEmpty(userInput))
            {
                DisplayUtility.PrintError("Enter a value to continue");
                return false;
            }

            if (!int.TryParse(userInput, out _))
            {
                DisplayUtility.PrintError("Expected input -> Number");
                return false;
            }

            return true;
        }

        public static bool ValidateChoice(string? userChoice, int totalChoices)
        {
            if (userChoice == null || userChoice.Length == 0)
            {
                DisplayUtility.PrintError("Enter a value to continue");
                return false;
            }

            if (!int.TryParse(userChoice, out int parsedChoice))
            {
                DisplayUtility.PrintError("Expected input -> Number");
                return false;
            }

            if (parsedChoice > 0 && parsedChoice <= totalChoices)
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
