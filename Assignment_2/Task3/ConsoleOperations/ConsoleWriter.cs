




public class ConsoleWriter
{
    public static void PrintMainDialouge()
    {
        Console.Clear();
        Console.WriteLine("------- XYZ Bank -------");
        Console.WriteLine();
        Console.WriteLine("[1] Create a New Account");
        Console.WriteLine("[2] Check Your Account Details");
        Console.WriteLine("[3] DepositCash");
        Console.WriteLine("[4] WithDraw Cash");
        Console.WriteLine("[5] DeleteBankAccount");
        Console.WriteLine("[6] CloseApp");
        Console.WriteLine();
    }
    public static void PrintUserDetailsFetcher(string TypeOfData)
    {
        Console.Write($"Enter Your {TypeOfData} : ");
    }

    internal static void PrintAccountTypeDialog()
    {
        Console.WriteLine("Choose Account To Handle");
        Console.WriteLine("[1]SavingsAccount [2]CheckingAccount ");
    }

    internal static void PrintSearchDialog()
    {
        Console.WriteLine("Search by [1]Name  [2]AccountNumber");
    }

    internal static void PrintUserData(CustomerData customer, int index = 0)
    {
        Console.WriteLine(":--------------------------");
        Console.WriteLine($":Index:{index}");
        Console.WriteLine(":--------------------------");
        Console.WriteLine($": Customer Name: {customer.GetCustomerName()}");
        Console.WriteLine($": AccountNumber: {customer.GetAccountNumber()}");
        Console.WriteLine($": Available amount in savings Account: {customer.GetSavingsAccountBalance()}");
        Console.WriteLine($": Available amount in Checking Account {customer.GetCheckingAccountBalance()}");
        Console.WriteLine();

    }
}
