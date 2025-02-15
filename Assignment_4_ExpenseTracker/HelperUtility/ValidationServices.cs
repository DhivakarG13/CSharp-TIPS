using Assignment_4_ExpenseTracker.MessageServices;
using Constants;
using Models;
namespace Assignment_4_ExpenseTracker.HelperUtility
{
    public static class ValidationServices
    {
        public static bool ValidateChoice(string? choice, List<int> range)
        {
            if (choice == null || choice.Length == 0)
            {
                ConsoleWriter.PrintWarning(ConstantStrings.userInputChoiceEmpty);
                return false;
            }
            bool isValidChoice = false;
            isValidChoice = int.TryParse(choice, out int parsedChoice);
            if (!isValidChoice)
            {
                ConsoleWriter.PrintWarning(ConstantStrings.userInputInvalidNumber);
                return false;
            }
            if (range.Contains(parsedChoice))
            {
                return true;
            }
            else
            {
                ConsoleWriter.PrintWarning(ConstantStrings.userChoiceOutOfRange);
                return false;
            }
        }

        public static bool ValidateOtherSource(string? sourceName)
        {
            if (sourceName == null || sourceName.Length == 0)
            {
                ConsoleWriter.PrintWarning(ConstantStrings.userInputValueEmpty);
                return false;
            }
            sourceName = sourceName.Trim();
            if (sourceName.Length < 5)
            {
                ConsoleWriter.PrintWarning(ConstantStrings.fiveCharactersLimitWarning);
                return false;
            }
            if (sourceName.Any(char.IsDigit))
            {
                ConsoleWriter.PrintWarning(ConstantStrings.noNumericalValuesAllowedWarning);
                return false;
            }
            if (sourceName.Any(char.IsWhiteSpace))
            {
                ConsoleWriter.PrintWarning(ConstantStrings.noSpaceAllowedWarning);
                return false;
            }
            return true;
        }

        public static bool ValidateAmount(string? numericalValue)
        {
            if (numericalValue == null || numericalValue.Length == 0)
            {
                ConsoleWriter.PrintWarning(ConstantStrings.userInputValueEmpty);
                return false;
            }
            bool isValidNumber = false;
            isValidNumber = int.TryParse(numericalValue, out int parsedNumber);
            if (!isValidNumber)
            {
                ConsoleWriter.PrintWarning(ConstantStrings.userInputInvalidNumber);
                return false;
            }
            if (parsedNumber < 0)
            {
                ConsoleWriter.PrintWarning(ConstantStrings.userInputNegativeNumber);
                return false;
            }
            return true;
        }

        public static bool ValidateNumericalInputs(string? numericalValue)
        {
            if (numericalValue == null || numericalValue.Length == 0)
            {
                ConsoleWriter.PrintWarning(ConstantStrings.userInputValueEmpty);
                return false;
            }
            bool isValidNumber = false;
            isValidNumber = int.TryParse(numericalValue, out int parsedNumber);
            if (!isValidNumber)
            {
                ConsoleWriter.PrintWarning(ConstantStrings.userInputInvalidNumber);
                return false;
            }
            return true;
        }

        public static bool ValidateNewTransactionId(int newId, List<IFinance> financialRecord)
        {
            if (financialRecord.Count == 0)
            {
                return true;
            }
            foreach (IFinance action in financialRecord)
            {
                if (action.TransactionId == newId)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool ValidateDateInputs(string? actionDate)
        {
            if (DateTime.TryParse(actionDate, out DateTime userDateTime))
            {
                return true;
            }
            else
            {
                ConsoleWriter.PrintWarning(ConstantStrings.userInputInvalidDate);
                return false;
            }
        }

        public static bool ValidateStringValue(string? stringValue)
        {
            if (stringValue == null || stringValue.Length == 0)
            {
                ConsoleWriter.PrintWarning(ConstantStrings.userInputValueEmpty);
                return false;
            }
            stringValue = stringValue.Trim();
            if (stringValue.Length < 2)
            {
                ConsoleWriter.PrintWarning(ConstantStrings.twoCharactersLimitWarning);
                return false;
            }
            if (stringValue.Any(char.IsWhiteSpace))
            {
                ConsoleWriter.PrintWarning(ConstantStrings.noSpaceAllowedWarning);
                return false;
            }
            return true;
        }
    }
}