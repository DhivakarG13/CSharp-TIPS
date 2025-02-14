using Assignment_4_ExpenseTracker.HelperUtility;
using Constants;
using Constants.Enumerations;

namespace Assignment_4_ExpenseTracker.MessageServices
{
    public static class GetUserData
    {
        public static int GetDialogChoice(int totalChoices)
        {
            List<int> range = new List<int>();
            for (int index = 1; index <= totalChoices; index++)
            {
                range.Add(index);
            }
            string? choice = null;
            bool isValidChoice = false;
            while (!isValidChoice)
            {
                Console.Write("Enter Your Choice : ");
                choice = ConsoleReader.GetInput();
                isValidChoice = ValidationServices.ValidateChoice(choice, range);
                Console.WriteLine();
            }
            isValidChoice = int.TryParse(choice, out int parsedChoice);
            return parsedChoice;
        }

        public static int GetChoiceFromList(int totalProducts)
        {
            List<int> Range = new List<int>();
            for (int index = 0; index < totalProducts; index++)
            {
                Range.Add(index);
            }
            string? choice = null;
            bool isValidChoice = false;
            while (!isValidChoice)
            {
                Console.Write("Enter Your Index : ");
                choice = ConsoleReader.GetInput();
                isValidChoice = ValidationServices.ValidateChoice(choice, Range);
                Console.WriteLine();
            }
            isValidChoice = int.TryParse(choice, out int parsedChoice);
            return parsedChoice;
        }

        public static (IncomeOptions, string) GetIncomeSource()
        {
            ConsoleWriter.PrintDialog(new IncomeOptions());
            IncomeOptions incomeChoice = (IncomeOptions)GetUserData.GetDialogChoice(Enum.GetNames(typeof(IncomeOptions)).Length);
            string source = "";
            if (incomeChoice == IncomeOptions.Other)
            {
                source = GetUserData.GetOtherSource(ConstantStrings.income);
            }
            else
            {
                ConsoleWriter.PrintSource(incomeChoice.ToString());
            }
            (IncomeOptions, string) incomeSource = ((IncomeOptions)incomeChoice, source);
            return incomeSource;
        }

        public static (ExpenseOptions, string) GetExpenseSource()
        {
            ConsoleWriter.PrintDialog(new ExpenseOptions());
            ExpenseOptions expenseChoice = (ExpenseOptions)GetUserData.GetDialogChoice(Enum.GetNames(typeof(ExpenseOptions)).Length);
            string source = "";
            if (expenseChoice == ExpenseOptions.Other)
            {
                source = GetUserData.GetOtherSource(ConstantStrings.expense);
            }
            else
            {
                ConsoleWriter.PrintSource(expenseChoice.ToString());
            }
            (ExpenseOptions, string) expenseSource = ((ExpenseOptions)expenseChoice, source);
            return expenseSource;
        }

        public static string GetOtherSource(string action)
        {
            bool isValidSource = false;
            string? source = string.Empty;
            while (!isValidSource)
            {
                ConsoleWriter.GetActionInfoWriter(action + ConstantStrings.source);
                source = ConsoleReader.GetInput();
                isValidSource = ValidationServices.ValidateOtherSource(source);
            }
            return source ?? "";
        }

        public static int GetAmount()
        {
            bool isValid = false;
            string? amount = null;
            while (!isValid)
            {
                ConsoleWriter.GetActionInfoWriter(ConstantStrings.amount);
                amount = ConsoleReader.GetInput();
                isValid = ValidationServices.ValidateAmount(amount);
            }
            int parsedAmount = default;
            int.TryParse(amount, out parsedAmount);
            return parsedAmount;
        }

        public static DateOnly GetActivityTime()
        {
            ConsoleWriter.PrintDialog(new SetTimeOptions());
            SetTimeOptions userSetTimeChoice = (SetTimeOptions)GetDialogChoice(Enum.GetNames(typeof(SetTimeOptions)).Length);
            switch (userSetTimeChoice)
            {
                case SetTimeOptions.Own_Time:
                    return GetUserTime();
                case SetTimeOptions.Current_Time:
                    return DateOnly.FromDateTime(DateTime.Now);
                default:
                    return DateOnly.FromDateTime(DateTime.Now);
            }
        }

        public static DateOnly GetUserTime()
        {
            bool isValidDate = false;
            string? actionDate = null;
            while (!isValidDate)
            {
                ConsoleWriter.GetActionInfoWriter(ConstantStrings.actionDate);
                actionDate = ConsoleReader.GetInput();
                isValidDate = ValidationServices.ValidateDateInputs(actionDate);
            }
            DateTime parsedActionDate = default;
            DateTime.TryParse(actionDate, out parsedActionDate);
            return DateOnly.FromDateTime(parsedActionDate);
        }

        public static int GetActionId()
        {
            bool isValidActionId = false;
            string? actionId = null;
            while (!isValidActionId)
            {
                ConsoleWriter.GetActionInfoWriter(ConstantStrings.actionId);
                actionId = ConsoleReader.GetInput();
                isValidActionId = ValidationServices.ValidateNumericalInputs(actionId);
            }
            int parsedActionId = default;
            int.TryParse(actionId, out parsedActionId);
            return parsedActionId;
        }

        public static int GetNumericalValue(string typeOfData)
        {
            Console.Write($"Enter Your {typeOfData}:");
            bool isNumberValid = false;
            string? validNumber = null;
            while (!isNumberValid)
            {
                validNumber = Console.ReadLine();
                isNumberValid = ValidationServices.ValidateNumericalInputs(validNumber);
            }
            int parsedValidNumber = default;
            int.TryParse(validNumber, out parsedValidNumber);
            return parsedValidNumber;
        }

        public static string GetStringValue(string action)
        {
            bool isValidStringValue = false;
            string? stringValue = string.Empty;
            while (!isValidStringValue)
            {
                ConsoleWriter.GetActionInfoWriter(action + ConstantStrings.value);
                stringValue = ConsoleReader.GetInput();
                isValidStringValue = ValidationServices.ValidateStringValue(stringValue);
            }
            return stringValue ?? string.Empty;
        }
    }

}