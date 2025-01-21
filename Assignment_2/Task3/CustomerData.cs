public class CustomerData: IBankAccount
{
    private string? CustomerName = string.Empty; 
    private int AccountNumber = default(int);
    private int SavingsAccountBalance = default(int);
    private int CheckingAccountBalance = default(int);
    public CustomerData(string? customerName, int accountNumber, int savingsAccountDeposit,int checkingAccountDeposit)
    {
        CustomerName = customerName;
        AccountNumber = accountNumber;
        SavingsAccountBalance = savingsAccountDeposit;
        CheckingAccountBalance = checkingAccountDeposit;
    }

    public string? GetCustomerName() => CustomerName;
    public int GetAccountNumber() => AccountNumber;
    public int GetSavingsAccountBalance() => SavingsAccountBalance;
    public int GetCheckingAccountBalance() => CheckingAccountBalance;   
    public void SavingsAccountWithDrawl(int Amount ,int MinimumBalance)
    {
        if (SavingsAccountBalance - Amount >= MinimumBalance)
        {
            SavingsAccountBalance -= Amount;
            Console.WriteLine($"An amount of {Amount} is debited from your {this.GetType().Name}");
        }
        else
        {
            Console.WriteLine("Entered Amount is Exceeding the Limit");
            Console.WriteLine($"Available Balance : {SavingsAccountBalance}");
            Console.WriteLine($"With-drawable Amount : {SavingsAccountBalance - MinimumBalance}");
        }
    }
    public void CheckingAccountWithDrawl(int Amount)
    {
        if (CheckingAccountBalance - Amount >= 0)
        {
            CheckingAccountBalance -= Amount;
            Console.WriteLine($"An amount of {Amount} is debited from your {this.GetType().Name}");
        }
        else
        {
            Console.WriteLine("Entered Amount is Exceeding the Limit");
            Console.WriteLine($"Available Balance : {SavingsAccountBalance}");
            Console.WriteLine($"With-drawable Amount : {SavingsAccountBalance}");
        }
    }
    public void CheckingAccountDeposit(int Amount)
    {
        CheckingAccountBalance += Amount;
        Console.WriteLine($"CheckingAccount Balance : {this.CheckingAccountBalance}");
    }
    public void SavingsAccountDeposit(int Amount)
    {
        SavingsAccountBalance += Amount;
        Console.WriteLine($"SavingsAccount Balance : {this.SavingsAccountBalance}");

    }
}
