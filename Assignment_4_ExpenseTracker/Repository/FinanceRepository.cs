using Models;

namespace Repository
{
    public class FinanceRepository
    {
        public List<IFinance> FinanceData;

        public FinanceRepository()
        {
            FinanceData = new List<IFinance>();
        }

    }
}