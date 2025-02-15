namespace Models
{
    public interface IFinance
    {
        public int Amount { get; set; }

        public int TransactionId { get; set; }

        public DateOnly ActionDate { get; set; }

        string? GetSource();

        void SetSource((int, string) value);
    }
}