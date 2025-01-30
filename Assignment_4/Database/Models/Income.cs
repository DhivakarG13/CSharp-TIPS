
public class Income : IFinance
{
    private IncomeOption _incomeType;
    private string _otherIncomeSource;
    private int _amount;
    private int _transactionId;

    int IFinance.Amount => _amount;
    string IFinance.Source
    {
        get
        {
            if (_incomeType == IncomeOption.Other)
            {
                return _otherIncomeSource;
            }
            else
            {
                return _incomeType.ToString();
            }
        }
    }
    int IFinance.TransactionId => _transactionId;

    public Income(List<IFinance> FinancialRecord)
    {
        SetSource();
        SetAmount();
        _transactionId = IdGenerator.TransactionIdGenerator(FinancialRecord);
    }

    public void SetAmount()
    {
        _amount = GetUserData.GetAmount();
    }
    public void SetSource()
    {
        (IncomeOption, string?) IncomeSource = GetUserData.GetIncomeSource();
        _incomeType = IncomeSource.Item1;
        _otherIncomeSource = IncomeSource.Item2 ?? string.Empty; 
    }

    public void PrintData()
    {
        if (_incomeType == IncomeOption.Other)
        {
            Console.WriteLine($"Income Type    : {_otherIncomeSource}");
        }
        else
        {
            Console.WriteLine($"Income Type    : {_incomeType}");
        }
        Console.WriteLine($"Amount         : {_amount}");
        Console.WriteLine($"Transaction Id : {_transactionId}");
    }
}
