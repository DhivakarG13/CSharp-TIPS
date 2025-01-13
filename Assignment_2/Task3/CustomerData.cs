public class CustomerData: BankAccount
{
    public string? CustomerName = string.Empty; 
    public int AccountNumber;
    public int SavingsAccountBalance = default(int);
    public int CheckingAccountBalance = default(int);
    public CustomerData(string? customerName, int accountNumber, int savingsAccountDeposit,int checkingAccountDeposit)
    {
        CustomerName = customerName;
        AccountNumber = accountNumber;
        SavingsAccountBalance = savingsAccountDeposit;
        CheckingAccountBalance = savingsAccountDeposit;
    }
    public void SavingsAccountWithDrawl(int Amount ,int MinimumBalance)
    {
        if (SavingsAccountBalance - Amount >= MinimumBalance)
        {
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
        SavingsAccountBalance += Amount;
    }
    public void SavingsAccountDeposit(int Amount)
    {
        CheckingAccountBalance += Amount;
    }
}
