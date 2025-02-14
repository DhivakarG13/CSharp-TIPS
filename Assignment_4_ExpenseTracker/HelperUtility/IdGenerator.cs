using Models;
namespace Assignment_4_ExpenseTracker.HelperUtility
{
    public static class IdGenerator
    {
        public static int TransactionIdGenerator(List<IFinance> financialRecord)
        {
            bool isValid = false;
            Random newRandom = new Random();
            int newId = 0;
            while (!isValid)
            {
                newId = newRandom.Next(10000, 100000);
                isValid = ValidationServices.ValidateNewTransactionId(newId, financialRecord);
            }
            return newId;
        }
    }
}