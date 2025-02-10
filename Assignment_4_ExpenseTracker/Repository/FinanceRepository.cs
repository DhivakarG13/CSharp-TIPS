using System.Text.Json;
using Models;

namespace Repository
{
    public class FinanceRepository
    {
        private List<Finance> _financeData = new List<Finance>();

        public FinanceRepository()
        {
            _financeData = new List<Finance>();
            LoadDatabase();
        }

        private void LoadDatabase()
        {
            string fileName = "FinanceData.json";
            if (File.Exists(fileName))
            {
                string jsonString = File.ReadAllText(fileName);
                _financeData = JsonSerializer.Deserialize<List<Finance>>(jsonString) ?? new List<Finance>();
            }
        }

        public List<Finance> GetFinanceData()
        {
            return _financeData;
        }

        internal void WriteToJson()
        {
            string json = JsonSerializer.Serialize(_financeData);
            File.WriteAllText("FinanceData.json", json);
        }
    }
}