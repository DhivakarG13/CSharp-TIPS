using C_DisplayApplication;
using E_ValidateApplication;

namespace D_UtilityApplication
{
    public static class UserDataFetchUtility
    {
        public static int GetNumericalInput(string inputTitle)
        {
            string? userInput;
            bool isValidNumericalInput;

            do
            {
                DisplayUtility.PrintInputTitle(inputTitle);
                userInput = Console.ReadLine();
                isValidNumericalInput = ValidationUtility.ValidateNumericalInput(userInput);
            }
            while (!isValidNumericalInput);

            int.TryParse(userInput, out int parsedChoice);
            return parsedChoice;
        }

        public static int GetChoice(int totalChoices)
        {
            string? choice;
            bool isValidChoice;

            do
            {
                Console.Write("Enter Your Choice:");
                choice = Console.ReadLine();
                isValidChoice = ValidationUtility.ValidateChoice(choice, totalChoices);
                Console.WriteLine();
            }
            while (!isValidChoice);

            int.TryParse(choice, out int parsedChoice);
            return parsedChoice;
        }
    }
}
