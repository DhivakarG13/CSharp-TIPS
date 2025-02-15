namespace Models
{
    public interface IFinance
    {
        string GetSource();
        void SetSource((int, string) value);
        public int Amount { get; set; }
        public int TransactionId { get; set; }
        public DateOnly ActionDate { get; set; }
        public string GetType() => "Finance";
    }
}