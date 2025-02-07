using Models;

namespace Repository
{
    public class FinanceRepository
    {
        private List<IFinance> _financeData;

        public List<IFinance> FinanceData {  get { return _financeData; } }
        public FinanceRepository()
        {
            _financeData = new List<IFinance>();
        }

    }
}