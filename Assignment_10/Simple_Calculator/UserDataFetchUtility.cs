namespace Simple_Calculator
{
    public static class UserDataFetchUtility
    {
        public static int GetNumberToCalculate(string dataToFetch)
        {
            string? userInput = null;
            int parsedInput = default;
            bool isValidNumber = false;
            do
            {
                Console.Write($"Enter {dataToFetch} : ");
                userInput = Console.ReadLine();
                isValidNumber = int.TryParse(userInput, out parsedInput);
            }
            while (!isValidNumber);
            {
                    Console.WriteLine("Numerical value expected");
            }
            return parsedInput;
        }

        public static int GetDialogChoice(int totalOptions)
        {
            bool isValidChoice = false;
            int choice = GetNumberToCalculate("Choice ");

            while (!isValidChoice)
            {
                isValidChoice = UserDataValidate.ValidateChoice(choice, totalOptions);
                if (!isValidChoice)
                {
                    Console.WriteLine("Enter a valid Input try Again");
                }
                else
                {
                    break;
                }
                choice = GetNumberToCalculate("Choice ");
            }

            return choice;
        }
    }
}