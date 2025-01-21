
public class Expense : IFinance
{
    private string? _expenceType;
    public int Amount { get; set; }
    private int transactionId;
    public Expense(string? ExpenceType, int amount, int transactionId)
    {
        _expenceType = ExpenceType;
        Amount = amount;
        this.transactionId = transactionId;
    }
    public int GetAmount() => -1 * Amount;
    public int GetTransactionId() => transactionId;
    public void PrintData()
    {
        ConsoleWriter.ActionWriter("Expense Type :" + _expenceType, Amount, transactionId);
    }
}

//public static int UserIdGenerator(List<StorageSlot> inventory)
//{
//    bool IsValid = false;
//    Random NewRandom = new Random();
//    int NewId = 0;
//    while (!IsValid)
//    {
//        NewId = NewRandom.Next(10000, 100000);
//        IsValid = UserDataValidators.ValidateNewUserId(NewId, inventory);
//    }
//    return NewId;
//}