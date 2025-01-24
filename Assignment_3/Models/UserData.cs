using Inventory.Helpers;

public class UserData
{
    public string UserName { get; }
    public int UserId { get; }

    public UserData(string userName, List<StorageSlot> inventory)
    {
        UserName = userName;
        UserId = IdGenerator.UserIdGenerator(inventory);
    }

    public void PrintUserData()
    {
        Console.WriteLine("\nUSER NAME           : " + UserName);
        Console.WriteLine("USER ID             : " + UserId);
    }
}
