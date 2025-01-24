public class Expense : IFinance
{
    public string? ExpenseType { get; }

    public int Amount 
    { 
        get { return -Amount; } 
        private set { Amount = value; }
    }

    public int TransactionId { get; }

    public Expense(string? ExpenseType, int amount, int transactionId)
    {
        this.ExpenseType = ExpenseType;
        Amount = amount;
        this.TransactionId = transactionId;
    }

    public int GetAmount() => -1 * Amount;

    public int GetTransactionId() => TransactionId;

    public void PrintData()
    {
        ConsoleWriter.ActionWriter("Expense Type :" + ExpenseType, Amount, TransactionId);
    }

}