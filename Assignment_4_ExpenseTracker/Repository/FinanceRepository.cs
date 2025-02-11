using Models;

namespace Repository
{
    public class FinanceRepository
    {
        private List<IFinance> _financeData;

        public FinanceRepository()
        {
            _financeData = new List<IFinance>();
        }

        public List<IFinance> GetFinanceData()
        {
            return _financeData;
        }

    }
}