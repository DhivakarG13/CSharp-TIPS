using Models;

namespace Repository
{
    public class FinanceRepository
    {
        public List<IFinance> FinanceData { get; set; }

        public FinanceRepository()
        {
            FinanceData = new List<IFinance>();
        }
    }
}