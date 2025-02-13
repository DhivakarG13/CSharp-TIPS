using Assignment_4_ExpenseTracker.MessageServices;
using Constants;
using Models;
namespace Assignment_4_ExpenseTracker.HelperUtility
{
    public static class ValidationServices
    {
        public static bool ValidateChoice(string? Choice, List<int> Range)
        {
            if (Choice == null || Choice.Length == 0)
            {
                ConsoleWriter.PrintWarning(ConstantStrings.userInputChoiceEmpty);
                return false;
            }
            bool IsValidChoice = false;
            IsValidChoice = int.TryParse(Choice, out int ParsedChoice);
            if (!IsValidChoice)
            {
                ConsoleWriter.PrintWarning(ConstantStrings.userInputInvalidNumber);
                return false;
            }
            if (Range.Contains(ParsedChoice))
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
        public static bool ValidateAmount(string? NumericalValue)
        {
            if (NumericalValue == null || NumericalValue.Length == 0)
            {
                ConsoleWriter.PrintWarning(ConstantStrings.userInputValueEmpty);
                return false;
            }
            bool IsValidNumber = false;
            IsValidNumber = int.TryParse(NumericalValue, out int ParsedNumber);
            if (!IsValidNumber)
            {
                ConsoleWriter.PrintWarning(ConstantStrings.userInputInvalidNumber);
                return false;
            }
            if (ParsedNumber < 0)
            {
                ConsoleWriter.PrintWarning(ConstantStrings.userInputNegativeNumber);
                return false;
            }
            return true;
        }
        public static bool ValidateNumericalInputs(string? NumericalValue)
        {
            if (NumericalValue == null || NumericalValue.Length == 0)
            {
                ConsoleWriter.PrintWarning(ConstantStrings.userInputValueEmpty);
                return false;
            }
            bool IsValidNumber = false;
            IsValidNumber = int.TryParse(NumericalValue, out int ParsedNumber);
            if (!IsValidNumber)
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
            foreach (IFinance Action in financialRecord)
            {
                if (Action.TransactionId == newId)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool ValidateDateInputs(string? ActionDate)
        {
            if (DateTime.TryParse(ActionDate, out DateTime userDateTime))
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