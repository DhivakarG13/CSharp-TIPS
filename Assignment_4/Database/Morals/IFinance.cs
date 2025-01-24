public interface IFinance
{
    public int Amount
    {
        get { return Amount; }
        private set { Amount = value; }
    }
    public int TransactionId { get; }
    public void PrintData();

}
