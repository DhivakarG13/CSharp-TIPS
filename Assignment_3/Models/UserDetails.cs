using Inventory.Helpers;

public class UserDetails
{
    public string? UserName { get; }
    public int UserId { get; }

    public UserDetails(string userName, int userId)
    {
        UserName = userName;
        UserId = userId;
    }

    public void PrintUserDetails()
    {
        Console.WriteLine("\nUSER NAME           : " + UserName);
        Console.WriteLine("USER ID             : " + UserId);
    }
}
