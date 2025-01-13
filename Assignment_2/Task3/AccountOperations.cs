public static class AccountOperations
{
    internal static List<int> SearchName(List<CustomerData> customerList, string? CustomerName)
    {
        int index = 0;
        List<int> foundList = new List<int>();
        foreach (CustomerData customer in customerList)
        {
            if (customer.CustomerName.Contains(CustomerName))
            {
                foundList.Add(index);
                ConsoleWriter.PrintUserData(customer, index);
            }
            index++;
        }
        return foundList;
    }
    internal static List<int> SearchAccNumber(List<CustomerData> customerList, int AccountNumber)
    {
        int index = 0;
        List<int> foundList = new List<int>();
        foreach (CustomerData customer in customerList)
        {
            if(customer.AccountNumber == AccountNumber)
            {
                foundList.Add(index);
                ConsoleWriter.PrintUserData(customer, index);
            }
            index++;
        }
        return foundList;
        ;
    }
}