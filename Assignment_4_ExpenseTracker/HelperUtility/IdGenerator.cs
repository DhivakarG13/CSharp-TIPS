using Models;
namespace Assignment_4_ExpenseTracker.HelperUtility
{
    internal static class IdGenerator
    {
        public static int TransactionIdGenerator(List<Finance> FinancialRecord)
        {
            bool IsValid = false;
            Random NewRandom = new Random();
            int NewId = 0;
            while (!IsValid)
            {
                NewId = NewRandom.Next(10000, 100000);
                IsValid = ValidationServices.ValidateNewTransactionId(NewId, FinancialRecord);
            }
            return NewId;
        }
    }
}