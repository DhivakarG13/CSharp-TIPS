
using System.Collections.Generic;
using Inventory.Helpers;

public class UserData
{
    private string _userName;
    private int _userId;

    public UserData(string userName , List<StorageSlot> inventory)
    {
        _userName = userName;
        _userId = IdGenerator.UserIdGenerator(inventory);
    }

    internal string? GetName() => _userName;
    internal int GetId() => _userId;


}
