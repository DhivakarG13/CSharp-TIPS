using System;

public class CustomerData
{
    public string? CustomerName { get; }

    public int AccountNumber { get; }

    public SavingsAccount SavingsAccount { get; set; }

    public CheckingAccount CheckingAccount { get; set; }

    public CustomerData(string? customerName, int accountNumber, int savingsAccountDeposit,int checkingAccountDeposit)
    {
        CustomerName = customerName;
        AccountNumber = accountNumber;
        SavingsAccount = new SavingsAccount(savingsAccountDeposit);
        CheckingAccount = new CheckingAccount(checkingAccountDeposit);
    }

    public static void PrintUserData(CustomerData customer)
    {
        Console.WriteLine(":--------------------------");
        Console.WriteLine("---- YOUR ACCOUNT INFO ----");
        Console.WriteLine(":--------------------------");
        Console.WriteLine($": Customer Name: {customer.CustomerName}");
        Console.WriteLine($": AccountNumber: {customer.AccountNumber}");
        Console.WriteLine($": Available amount in savings Account: {customer.SavingsAccount.Balance}");
        Console.WriteLine($": Available amount in Checking Account {customer.CheckingAccount.Balance}");
        Console.WriteLine();

    }
}
