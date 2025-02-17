﻿

using Assignment_4_ExpenseTracker.HelperUtility;
using Constants;
using Constants.Enumerations;

public static class GetUserData
{
    public static int GetChoice(int TotalProducts)
    {
        string? Choice = null;
        bool IsValidChoice = false;
        while (!IsValidChoice)
        {
            Console.Write("Enter Your Choice:");
            Choice = ConsoleReader.GetInput();
            IsValidChoice = ValidationServices.ValidateChoice(Choice, TotalProducts);
            Console.WriteLine();
        }
        IsValidChoice = int.TryParse(Choice, out int ParsedChoice);
        return ParsedChoice;
    }

    public static (IncomeOptions, string) GetIncomeSource()
    {
        ConsoleWriter.PrintDialog(new IncomeOptions());
        IncomeOptions IncomeChoice = (IncomeOptions)GetUserData.GetChoice(Enum.GetNames(typeof(IncomeOptions)).Length);
        string source = "";
        if (IncomeChoice == IncomeOptions.Other)
        {
            source = GetUserData.GetOtherSource(ConstantStrings.income);
        }
        (IncomeOptions, string) IncomeSource = ((IncomeOptions)IncomeChoice, source);

            return IncomeSource;
        }

    public static (ExpenseOptions, string) GetExpenseSource()
    {
        ConsoleWriter.PrintDialog(new ExpenseOptions());
        ExpenseOptions ExpenseChoice = (ExpenseOptions)GetUserData.GetChoice(Enum.GetNames(typeof(ExpenseOptions)).Length);
        string source = "";
        if (ExpenseChoice == ExpenseOptions.Other)
        {
            source = GetUserData.GetOtherSource(ConstantStrings.expense);
        }
        (ExpenseOptions, string) ExpenseSource = ((ExpenseOptions)ExpenseChoice, source);
        return ExpenseSource;
    }

    public static string GetOtherSource(string action)
    {
        bool isValidSource = false;
        string? Source = "";

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

    public static DateOnly GetActivityDate()
    {
        ConsoleWriter.PrintDialog(new SetDateOptions());

        SetDateOptions UserSetDateChoice = (SetDateOptions)GetChoice(Enum.GetNames(typeof(SetDateOptions)).Length);

        switch (UserSetDateChoice)
        {
            case SetDateOptions.Own_Date:
                return GetUserDateInput();
            case SetDateOptions.Current_Date:
                return DateOnly.FromDateTime(DateTime.Now);
            default:
                return DateOnly.FromDateTime(DateTime.Now);
        }
    }

    public static DateOnly GetUserDateInput()
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
            ConsoleWriter.GetActionInfoWriter("ActionId :");
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
        string? stringValue = "";

        while (!IsValidStringValue)
        {
            ConsoleWriter.GetActionInfoWriter(action + ConstantStrings.value);
            stringValue = ConsoleReader.GetInput();
            IsValidStringValue = ValidationServices.ValidateStringValue(stringValue);
        }
        return stringValue ?? "";
    }
}
