public class CustomerData: IBankAccount
{
    public string? CustomerName = string.Empty; 
    public int AccountNumber = default(int);
    public int SavingsAccountBalance = default(int);
    public int CheckingAccountBalance = default(int);
    public CustomerData(string? customerName, int accountNumber, int savingsAccountDeposit,int checkingAccountDeposit)
    {
        CustomerName = customerName;
        AccountNumber = accountNumber;
        SavingsAccountBalance = savingsAccountDeposit;
        CheckingAccountBalance = checkingAccountDeposit;
    }
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
