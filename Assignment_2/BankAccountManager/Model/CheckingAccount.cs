public class CheckingAccount : BankAccount
{
    public int MinimumBalance = 0;
    public void WithDraw(int Amount)
    {
        base.WithDraw(Amount, MinimumBalance);
    }

    public CheckingAccount(int balance) : base(balance) { }
}
