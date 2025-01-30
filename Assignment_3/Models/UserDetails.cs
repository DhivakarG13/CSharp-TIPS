using Inventory.Helpers;

public class UserDetails
{
    public string? UserName { get; }
    public int UserId { get; }

    public UserDetails(string userName, List<StorageSlot> inventory)
    {
        UserName = userName;
        UserId = IdGenerateService.UserIdGenerator(inventory);
    }

    public void PrintUserDetails()
    {
        Console.WriteLine("\nUSER NAME           : " + UserName);
        Console.WriteLine("USER ID             : " + UserId);
    }
}
