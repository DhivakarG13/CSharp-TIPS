public static class AccountOperations
{
    public static List<int> SearchName(List<CustomerData> customerList, string? CustomerName)
    {
        int index = 0;
        List<int> foundList = new List<int>();
        foreach (CustomerData customer in customerList)
        {
            if (customer.GetCustomerName().Contains(CustomerName))
            {
                foundList.Add(index);
                //ConsoleWriter.PrintUserData(customer, index);
            }
            index++;
        }
        if(foundList.Count > 1)
        {
            Console.WriteLine();
            Console.WriteLine("There are more than 1 matches For Users privacy please Enter your Account Number.");
            UserInteraction.SearchByAccountNumber(customerList);
        }
        else
        {
            ConsoleWriter.PrintUserData(customerList[foundList[0]], index);
        }
        return foundList;
    }
    public static List<int> SearchAccNumber(List<CustomerData> customerList, int AccountNumber)
    {
        int index = 0;
        List<int> foundList = new List<int>();
        foreach (CustomerData customer in customerList)
        {
            if(customer.GetAccountNumber() == AccountNumber)
            {
                foundList.Add(index);
                ConsoleWriter.PrintUserData(customer, index);
            }
            index++;
        }
        return foundList;
    }
}