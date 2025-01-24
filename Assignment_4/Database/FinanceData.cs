public class FinanceData
{
    private List<IFinance> FinancialRecord;

    private List<DateTime> ActivityTime;

    private int _balance = 0;

    public FinanceData()
    {
        FinancialRecord = new List<IFinance>();
        ActivityTime = new List<DateTime>();

    }

    public List<IFinance> GetFinancialRecord() => FinancialRecord;
    public int GetBalance() => _balance;

    internal void AddAction(IFinance newAction)
    {
        FinancialRecord.Add(newAction);
        ActivityTime.Add(DateTime.Now);
        _balance += newAction.Amount;
    }

    internal List<int> SearchActivity()
    {
        List<int> FoundIndeces = new List<int>();
        FoundIndeces.AddRange(SearchOperations.GetSearchResults(FinancialRecord));
        return FoundIndeces;
    }

    internal void PrintRecord(List<int> foundIndeces)
    {
        foreach(int index in foundIndeces)
        {
            Console.WriteLine($"Index: [{index}]");
            FinancialRecord[index].PrintData();
            Console.WriteLine(ActivityTime[index]);
        }
    }

    internal void DeleteAt(int indexToDelete)
    {
        FinancialRecord.RemoveAt(indexToDelete);
        ActivityTime.RemoveAt(indexToDelete);
    }
}
