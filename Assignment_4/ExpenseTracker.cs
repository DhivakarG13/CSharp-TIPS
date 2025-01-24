public class ExpenseTracker
{
    private string? _userName;
    private FinanceData _data;

    public ExpenseTracker()
    {
        _data = new FinanceData();
    }
    public void Run()
    {
        _userName = GetUserData.GetNameValue("User Name");
        bool CloseAppFlag = false;

        while (!CloseAppFlag)
        {

            List<int> FoundIndeces = new List<int>();
            ConsoleWriter.PrintMainDialog();
            UserOptions MainDialogChoice = (UserOptions)GetUserChoice.GetChoice(
                new List<int> { 1, 2, 3, 4, 5, 6, 7 });

            switch (MainDialogChoice)
            {
                case UserOptions.Add_Income:
                    Income? newIncome = GetUserData.GetIncome(_data.GetFinancialRecord());
                    _data.AddAction(newIncome);
                    break;
                case UserOptions.Add_Expense:
                    Expense? newExpense = GetUserData.GetExpense(_data.GetFinancialRecord());
                    _data.AddAction(newExpense);
                    break;
                case UserOptions.View_Balance:
                    ConsoleWriter.PrintBalance(_data.GetBalance());
                    break;
                case UserOptions.Search:
                case UserOptions.Edit_Activity:
                    FoundIndeces.AddRange(_data.SearchActivity());
                    if (FoundIndeces.Count == 0 || FoundIndeces[0] == -1)
                    {
                        Console.WriteLine("Search Failed");
                        Console.WriteLine("Press a key to continue");
                        Console.ReadKey();
                        break;
                    }
                    _data.PrintRecord(FoundIndeces);
                    if (MainDialogChoice == UserOptions.Edit_Activity)
                    {
                        int indexToDelete = GetUserChoice.GetChoice(FoundIndeces);
                        _data.DeleteAt(indexToDelete);
                    }
                    break;
                case UserOptions.View_Summary:
                    for (int index = 0; index < _data.GetFinancialRecord().Count; index++)
                    {
                        FoundIndeces.Add(index);
                    }
                    if (FoundIndeces.Count == 0 || FoundIndeces[0] == -1)
                    {
                        Console.WriteLine("No Summary to display");
                        Console.WriteLine("Press a key to continue");
                        Console.ReadKey();
                        break;
                    }
                    _data.PrintRecord(FoundIndeces);
                    break;
                case UserOptions.Close_App:
                    CloseAppFlag = true;
                    break;
            }
        }
    }
}
