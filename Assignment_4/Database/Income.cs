
public class Income : IFinance
{
    private string? _incomeType;
    public int Amount {get; set;}
    private int transactionId;

    public Income(string? IncomeType, int amount, int transactionId)
    {
        _incomeType = IncomeType;
        Amount = amount;
        this.transactionId = transactionId;
    }
    public int GetAmount() => Amount;
    public int GetTransactionId() => transactionId;
    public void PrintData()
    {
        ConsoleWriter.ActionWriter("Income Type :" + _incomeType  , Amount ,transactionId);
    }
}
