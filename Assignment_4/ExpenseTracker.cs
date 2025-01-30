public class ExpenseTracker
{
    private FinanceData _data;

    public ExpenseTracker()
    {
        _data = new FinanceData();
    }
    public void Run()
    {
        bool CloseAppFlag = false;

        while (!CloseAppFlag)
        {

            ConsoleWriter.PrintMainDialog();
            UserOptions MainDialogChoice = (UserOptions)GetUserChoice.GetChoice(
                new List<int> { 1, 2, 3, 4, 5, 6, 7 ,8});
            List<int> FoundIndexes = new List<int>();
            Console.Clear();
            switch (MainDialogChoice)
            {

                case UserOptions.Add_Income:
                    {
                        _data.AddAction(new Income(_data.FinancialRecord));
                        ConsoleWriter.PrintActionComplete("Income Added Successfully");
                        break;
                    }

                case UserOptions.Add_Expense:
                    {
                        _data.AddAction(new Expense(_data.FinancialRecord));
                        ConsoleWriter.PrintActionComplete("Expense Added Successfully");
                        break;
                    }

                case UserOptions.View_Balance:
                    {
                        _data.PrintBalance();
                        break;
                    }

                case UserOptions.Search:
                    {
                        _data.SearchActivity();
                        break;
                    }

                case UserOptions.Edit_Activity:
                    {
                        FoundIndexes.AddRange(_data.SearchActivity());
                        if (FoundIndexes.Count() > 0 || FoundIndexes[0] != -1)
                        {
                            int indexToEdit = GetUserChoice.GetChoice(FoundIndexes);
                            _data.EditActivity(indexToEdit);
                            ConsoleWriter.PrintActionComplete("Action Updated Successfully");
                        }
                        break;
                    }

                case UserOptions.Delete_Activity:
                    {
                        FoundIndexes.AddRange(_data.SearchActivity());
                        if (FoundIndexes.Count() > 0 || FoundIndexes[0] != -1)
                        {
                            int indexToDelete = GetUserChoice.GetChoice(FoundIndexes);
                            _data.DeleteAt(indexToDelete);
                            ConsoleWriter.PrintActionComplete("Deleted Successfully");
                        }
                        break;
                    }


                case UserOptions.View_Summary:
                    {
                        for (int index = 0; index < _data.FinancialRecord.Count; index++)
                        {
                            FoundIndexes.Add(index);
                        }
                        _data.PrintRecord(FoundIndexes);
                        break;
                    }

                case UserOptions.Close_App:
                    {
                        CloseAppFlag = true;
                        break;
                    }

            }
            Console.Clear();
        }
    }
}
