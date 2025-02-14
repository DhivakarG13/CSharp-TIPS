using Assignment_4_ExpenseTracker.HelperUtility;
using Constants;
using Constants.Enumerations;

namespace Assignment_4_ExpenseTracker.MessageServices
{

    public static class GetUserData
    {
        public static int GetDialogChoice(int TotalChoices)
        {
            List<int> Range = new List<int>();
            for (int index = 1; index <= TotalChoices; index++)
            {
                Range.Add(index);
            }
            string? Choice = null;
            bool IsValidChoice = false;
            while (!IsValidChoice)
            {
                Console.Write("Enter Your Choice : ");
                Choice = ConsoleReader.GetInput();
                IsValidChoice = ValidationServices.ValidateChoice(Choice, Range);
                Console.WriteLine();
            }
            IsValidChoice = int.TryParse(Choice, out int ParsedChoice);
            return ParsedChoice;
        }

        public static int GetChoiceFromList(int TotalProducts)
        {
            List<int> Range = new List<int>();
            for (int index = 0; index < TotalProducts; index++)
            {
                Range.Add(index);
            }
            string? Choice = null;
            bool IsValidChoice = false;
            while (!IsValidChoice)
            {
                Console.Write("Enter Your Index : ");
                Choice = ConsoleReader.GetInput();
                IsValidChoice = ValidationServices.ValidateChoice(Choice, Range);
                Console.WriteLine();
            }
            IsValidChoice = int.TryParse(Choice, out int ParsedChoice);
            return ParsedChoice;
        }

        public static (IncomeOptions, string) GetIncomeSource()
        {
            ConsoleWriter.PrintDialog(new IncomeOptions());
            IncomeOptions IncomeChoice = (IncomeOptions)GetUserData.GetDialogChoice(Enum.GetNames(typeof(IncomeOptions)).Length);
            string source = "";
            if (IncomeChoice == IncomeOptions.Other)
            {
                source = GetUserData.GetOtherSource(ConstantStrings.income);
            }
            else
            {
                ConsoleWriter.PrintSource(IncomeChoice.ToString());
            }
            (IncomeOptions, string) IncomeSource = ((IncomeOptions)IncomeChoice, source);
            return IncomeSource;
        }

        public static (ExpenseOptions, string) GetExpenseSource()
        {
            ConsoleWriter.PrintDialog(new ExpenseOptions());
            ExpenseOptions ExpenseChoice = (ExpenseOptions)GetUserData.GetDialogChoice(Enum.GetNames(typeof(ExpenseOptions)).Length);
            string source = "";
            if (ExpenseChoice == ExpenseOptions.Other)
            {
                source = GetUserData.GetOtherSource(ConstantStrings.expense);
            }
            else
            {
                ConsoleWriter.PrintSource(ExpenseChoice.ToString());
            }
            (ExpenseOptions, string) ExpenseSource = ((ExpenseOptions)ExpenseChoice, source);
            return ExpenseSource;
        }

        public static string GetOtherSource(string action)
        {
            bool isValidSource = false;
            string? Source = string.Empty;
            while (!isValidSource)
            {
                ConsoleWriter.GetActionInfoWriter(action + ConstantStrings.source);
                Source = ConsoleReader.GetInput();
                isValidSource = ValidationServices.ValidateOtherSource(Source);
            }
            return Source ?? "";
        }

        public static int GetAmount()
        {
            bool IsValid = false;
            string? Amount = null;
            while (!IsValid)
            {
                ConsoleWriter.GetActionInfoWriter(ConstantStrings.amount);
                Amount = ConsoleReader.GetInput();
                IsValid = ValidationServices.ValidateAmount(Amount);
            }
            int ParsedAmount = default;
            int.TryParse(Amount, out ParsedAmount);
            return ParsedAmount;
        }

        public static DateOnly GetActivityTime()
        {
            ConsoleWriter.PrintDialog(new SetTimeOptions());
            SetTimeOptions UserSetTimeChoice = (SetTimeOptions)GetDialogChoice(Enum.GetNames(typeof(SetTimeOptions)).Length);
            switch (UserSetTimeChoice)
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
            bool IsValidDate = false;
            string? ActionDate = null;
            while (!IsValidDate)
            {
                ConsoleWriter.GetActionInfoWriter(ConstantStrings.actionDate);
                ActionDate = ConsoleReader.GetInput();
                IsValidDate = ValidationServices.ValidateDateInputs(ActionDate);
            }
            DateTime ParsedActionDate = default;
            DateTime.TryParse(ActionDate, out ParsedActionDate);
            return DateOnly.FromDateTime(ParsedActionDate);
        }

        public static int GetActionId()
        {
            bool IsValidActionId = false;
            string? ActionId = null;
            while (!IsValidActionId)
            {
                ConsoleWriter.GetActionInfoWriter(ConstantStrings.actionId);
                ActionId = ConsoleReader.GetInput();
                IsValidActionId = ValidationServices.ValidateNumericalInputs(ActionId);
            }
            int ParsedActionId = default;
            int.TryParse(ActionId, out ParsedActionId);
            return ParsedActionId;
        }

        public static int GetNumericalValue(string typeOfData)
        {
            Console.Write($"Enter Your {typeOfData}:");
            bool IsNumberValid = false;
            string? ValidNumber = null;
            while (!IsNumberValid)
            {
                ValidNumber = Console.ReadLine();
                IsNumberValid = ValidationServices.ValidateNumericalInputs(ValidNumber);
            }
            int ParsedValidNumber = default;
            int.TryParse(ValidNumber, out ParsedValidNumber);
            return ParsedValidNumber;
        }

        internal static string GetStringValue(string action)
        {
            bool IsValidStringValue = false;
            string? stringValue = string.Empty;
            while (!IsValidStringValue)
            {
                ConsoleWriter.GetActionInfoWriter(action + ConstantStrings.value);
                stringValue = ConsoleReader.GetInput();
                IsValidStringValue = ValidationServices.ValidateStringValue(stringValue);
            }
            return stringValue ?? string.Empty;
        }
    }

}