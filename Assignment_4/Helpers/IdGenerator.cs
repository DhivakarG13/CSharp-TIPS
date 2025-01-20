
internal static class IdGenerator
{
    public static int TransactionIdGenerator(List<IFinance> FinancialRecord)
    {
        bool IsValid = false;
        Random NewRandom = new Random();
        int NewId = 0;
        while (!IsValid)
        {
            NewId = NewRandom.Next(10000, 100000);
            IsValid = UserDataValidators.ValidateNewTransactionId(NewId, FinancialRecord);
        }
        return NewId;
    }
}