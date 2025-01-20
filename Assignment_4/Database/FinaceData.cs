

public class FinaceData
{
    private List<IFinance> FinancialRecord;
    private List<DateTime> ActivityTime;
    private int _balance = 0;
    public FinaceData()
    {
        FinancialRecord = new List<IFinance>();
        ActivityTime = new List<DateTime>();

    }
    public List<IFinance> GetFinancialRecord() => FinancialRecord;
    internal void AddAction(IFinance newAction)
    {
        FinancialRecord.Add(newAction);
        ActivityTime.Add(DateTime.Now);
        _balance += newAction.GetAmount();
    }
    public int GetBalance() =>_balance;

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
