namespace Constants
{
    namespace Enumerations
    {
        public enum ExpenseOptions
        {
            Food = 1,
            Travel,
            Electricity,
            Stay,
            Education,
            Clothing,
            Gadgets,
            Grocery,
            Invest,
            Grooming,
            Other
        }

        public enum IncomeOptions
        {
            Salary = 1,
            FreeLancing,
            Loan,
            Other
        }

        public enum MainMenu
        {
            Add_Income = 1,
            Add_Expense,
            Search,
            View_All_Actions,
            Edit_Activity,
            View_Summary,
            Close_App
        }

        public enum SearchOptions
        {
            Source = 1,
            Action,
            ActionId,
            ActionDate
        }

        public enum SetDateOptions
        {
            Current_Date = 1,
            Own_Date
        }

        public enum SearchByActionDateOptions
        {
            Day = 1,
            Month,
            Year
        }

        public enum Actions
        {
            Income = 1,
            Expense
        }
        public enum EditOptions
        {
            Edit_Source = 1,
            Edit_Amount,
            Edit_Time,
        }
    }
}