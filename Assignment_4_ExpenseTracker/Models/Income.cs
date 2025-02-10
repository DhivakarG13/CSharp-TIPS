using System.Text.Json.Serialization;
using Constants.Enumerations;
using Models;

namespace Assignment_4_ExpenseTracker.Models
{
    public class Income : Finance
    {
        [JsonConstructor]
        public Income(string sourceType, int amount, int transactionId, DateOnly actionDate) : base(sourceType ,amount, transactionId, actionDate)
        {
            SourceType = sourceType;
            Amount = amount;
            TransactionId = transactionId;
            ActionDate = actionDate;
        }
        public override string GetActionType()
        {
            return "Income";
        }

    }
}