
using System.Transactions;

public static class GetUserData
{
    public static string? GetNameValue(string? TypeOfData)
    {
        bool IsValid = false;
        string? UserName = null;

        while (!IsValid)
        {
            ConsoleWriter.GetUserInfoWriter($"Enter {TypeOfData} : ");
            UserName = ConsoleReader.GetInput();
            IsValid = UserDataValidators.ValidateUserName(UserName);
        }
        Console.Clear();
        return UserName;
    }

    internal static Income GetIncome(List<IFinance> FinancialRecord)
    {
        string? source = null;
        int Amount = 0;
        int transactionId = 0;
        ConsoleWriter.PrintIncomeDialog();
        source = GetIncomeSource();
        Amount = GetAmount();
        transactionId = IdGenerator.TransactionIdGenerator(FinancialRecord);
        return new Income(source , Amount, transactionId);
    }
    internal static Expense? GetExpense(List<IFinance> FinancialRecord)
    {
        string? source = null;
        int Amount = 0;
        int transactionId = 0;
        ConsoleWriter.PrintExpenseDialog();
        source = GetExpenseSource();
        Amount = GetAmount();
        transactionId = IdGenerator.TransactionIdGenerator(FinancialRecord);
        return new Expense(source, Amount, transactionId);
    }

    private static string? GetExpenseSource()
    {
        int ExpenseChoice = GetUserChoice.GetChoice(
            new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 });
        if (ExpenseChoice == 11)
        {
            string? source = GetUserData.GetNameValue("Source");
            return source;
        }
        return Enum.GetName(typeof(ExpenseOption), ExpenseChoice);
    }

    private static string? GetIncomeSource()
    {
        int IncomeChoice = GetUserChoice.GetChoice(
            new List<int> { 1, 2, 3, 4 });
        if (IncomeChoice == 4)
        {
            string? source = GetUserData.GetNameValue("Source");
            return source;
        }
        return Enum.GetName(typeof(IncomeOption), IncomeChoice);
    }

    internal static string GetSearchChoice()
    {
        ConsoleWriter.PrintSearchDialog();

       int SearchChoice = GetUserChoice.GetChoice(
            new List<int> { 1, 2 }); 
        return Enum.GetName(typeof(SearchOption), SearchChoice);
    }
public static int GetAmount()
    {
        bool IsValid = false;
        string? NumericalValue = null;

        while (!IsValid)
        {
            ConsoleWriter.GetUserInfoWriter("Amount :");
            NumericalValue = ConsoleReader.GetInput();
            IsValid = UserDataValidators.ValidateNumericalInputs(NumericalValue);
        }
        return int.Parse(NumericalValue);
    }

    internal static string GetSearchByActionChoice()
    {
        ConsoleWriter.PrintSearchByActionDialog();

        int SearchChoice = GetUserChoice.GetChoice(
             new List<int> { 1, 2 });
        return Enum.GetName(typeof(Actions), SearchChoice);
    }

    internal static int GetActionId()
    {
        bool IsValid = false;
        string? NumericalValue = null;

        while (!IsValid)
        {
            ConsoleWriter.GetUserInfoWriter("ActionId :");
            NumericalValue = ConsoleReader.GetInput();
            IsValid = UserDataValidators.ValidateNumericalInputs(NumericalValue);
        }
        return int.Parse(NumericalValue);
    }
}
