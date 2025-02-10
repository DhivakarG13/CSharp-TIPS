using System.Text.Json.Serialization;
using Constants.Enumerations;

namespace Models
{
    public class Finance
    {
        public string SourceType {  get; set; }
        public int Amount {  get; set; }
        public int TransactionId {  get; set; }
        public DateOnly ActionDate {get; set; }

        [JsonConstructor]
        protected Finance(string sourceType,int amount,int transactionId,DateOnly actionDate)
        {
            SourceType = sourceType;
            Amount = amount;
            TransactionId = transactionId;
            ActionDate = actionDate;
        }
        public virtual string GetActionType()
        {
            return "Finance";
        }
    }
}