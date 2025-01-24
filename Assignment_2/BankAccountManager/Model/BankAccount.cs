using System;

public abstract class BankAccount
{
    public int Balance { get; private set; }
    protected BankAccount(int balance)
    {
        Deposit(balance);
    }
    public void Deposit(int Amount)
    {
        Balance = Balance + Amount;
    }
    public void WithDraw(int Amount , int MinimumBalance)
    {
        if ((Balance - Amount) >= MinimumBalance)
        {
            Balance -= Amount;
        }
        else
        {
            Console.WriteLine("Entered Amount is Exceeding the Limit");
            Console.WriteLine($"Available Balance : {Balance}");
            Console.WriteLine($"With-drawable Amount : {Balance - MinimumBalance}");
        }
    }
}
