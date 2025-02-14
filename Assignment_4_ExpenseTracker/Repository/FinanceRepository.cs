using Models;

namespace Repository
{
    public class FinanceRepository
    {
        private List<IFinance> FinanceData;

        public FinanceRepository()
        {
            FinanceData = new List<IFinance>();
        }

        public List<IFinance> GetFinanceData()
        {
            return FinanceData;
        }

    }
}