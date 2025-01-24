
public class Income : IFinance
{
    public string IncomeType { get; }

    public int Amount
    {
        get { return Amount; }
        private set { Amount = value; }
    }

    public int TransactionId { get; set; }

    public Income(string? IncomeType, int amount, int transactionId)
    {
        this.IncomeType = IncomeType;
        Amount = amount;
        this.TransactionId = transactionId;
    }

    public int GetAmount() => Amount;

    public int GetTransactionId() => TransactionId;

    public void PrintData()
    {
        ConsoleWriter.ActionWriter("Income Type :" + IncomeType  , Amount ,TransactionId);
    }
}
