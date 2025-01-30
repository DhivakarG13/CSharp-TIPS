
using System;
using System.Transactions;

public static class GetUserData
{

    public static string? GetSource(string Action)
    {
        bool IsValidSource = false;
        string? Source = "";

        while (!IsValidSource)
        {
            ConsoleWriter.GetActionInfoWriter(Action + " Source :");
            Source = ConsoleReader.GetInput();
            IsValidSource = UserDataValidateUtility.ValidateSource(Source);
        }
        return Source;
    }

    public static (ExpenseOption,string?) GetExpenseSource()
    {
        ConsoleWriter.PrintExpenseDialog();
        int ExpenseChoice = GetUserChoice.GetChoice(
            new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 });
        string? source = "";
        if (ExpenseChoice == 11)
        {
            source = GetUserData.GetSource("Source");
        }
        (ExpenseOption, string?) ExpenseSource = ((ExpenseOption)ExpenseChoice,source);
        return ExpenseSource;
    }

    public static (IncomeOption, string?) GetIncomeSource()
    {
        ConsoleWriter.PrintIncomeDialog(new IncomeOption());
        int IncomeChoice = GetUserChoice.GetChoice(
            new List<int> { 1, 2, 3, 4 });
        string? source = "";
        if (IncomeChoice == 4)
        {
            source = GetUserData.GetSource("Source");
        }
        (IncomeOption, string ?) IncomeSource = ((IncomeOption)IncomeChoice, source);

        return IncomeSource;
    }

    public static int GetAmount()
    {
        bool IsValid = false;
        string? Amount = null;

        while (!IsValid)
        {
            ConsoleWriter.GetActionInfoWriter("Amount :");
            Amount = ConsoleReader.GetInput();
            IsValid = UserDataValidateUtility.ValidateNumericalInputs(Amount);
        }

        int ParsedAmount = default;
        int.TryParse(Amount, out ParsedAmount);

        return ParsedAmount;
    }

    public static int GetActionId()
    {
        bool IsValidActionId = false;
        string? ActionId = null;

        while (!IsValidActionId)
        {
            ConsoleWriter.GetActionInfoWriter("ActionId :");
            ActionId = ConsoleReader.GetInput();
            IsValidActionId = UserDataValidateUtility.ValidateNumericalInputs(ActionId);
        }
        int ParsedActionId = default;
        int.TryParse(ActionId, out ParsedActionId);

        return ParsedActionId;
    }

    public static DateOnly GetActivityTime()
    {
        bool IsValidDate = false;
        string? ActionDate = null;

        while (!IsValidDate)
        {
            ConsoleWriter.GetActionInfoWriter("Action Date :");
            ActionDate = ConsoleReader.GetInput();
            IsValidDate = UserDataValidateUtility.ValidateDateInputs(ActionDate);
        }
        DateTime ParsedActionDate = default;
        DateTime.TryParse(ActionDate, out ParsedActionDate);

        return DateOnly.FromDateTime(ParsedActionDate);
    }

    public static SearchOption GetSearchChoice()
    {
        ConsoleWriter.PrintSearchDialog();

        int  SearchChoice = GetUserChoice.GetChoice(new List<int> { 1, 2, 3 ,4});

        return (SearchOption)SearchChoice;
    }

    public static Actions GetSearchByActionChoice()
    {
        ConsoleWriter.PrintSearchByActionDialog();

        int SearchChoice = GetUserChoice.GetChoice(new List<int> { 1, 2 });

        return (Actions)SearchChoice;
    }

    public static SetTimeOption GetSetTimeChoice()
    {
        ConsoleWriter.PrintSetTimeDialog();

        int SearchChoice = GetUserChoice.GetChoice(new List<int> { 1, 2 });

        return (SetTimeOption)SearchChoice;
    }

    public static EditOptions GetTaskEditChoice()
    {
        ConsoleWriter.PrintEditChoiceDialog();

        int TaskEditChoice = GetUserChoice.GetChoice(new List<int> { 1, 2 ,3});

        return (EditOptions)TaskEditChoice;
    }

    public static int GetNumber(string typeOfData)
    {
        Console.Write($"Enter Your {typeOfData}:");
        bool IsNumberValid = false;
        string? ValidNumber = null;
        while (!IsNumberValid)
        {
            ValidNumber = Console.ReadLine();
            IsNumberValid = UserDataValidateUtility.ValidateNumericalInputs(ValidNumber);
        }

        int ParsedValidNumber = default;
        int.TryParse(ValidNumber, out ParsedValidNumber);

        return ParsedValidNumber;
    }
}
