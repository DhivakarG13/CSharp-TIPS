
public class SavingsAccount : BankAccount
{
    public int MinimumBalance = 500;
    public void WithDraw(int Amount)
    {
        base.WithDraw(Amount, MinimumBalance);
    }
    public SavingsAccount(int balance) : base(balance) { }

}
