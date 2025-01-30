public interface IFinance
{
    public int Amount { get;}
    public string Source { get; }
    public int TransactionId { get; }
    public void SetAmount();
    public void SetSource();
    public void PrintData();

}
