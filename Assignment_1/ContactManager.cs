using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

List<ContactInfo> CallLog = new List<ContactInfo>();
List<ContactInfo> Recents = new List<ContactInfo>();
while (true)
{
    UserInteraction.PrintMenu();
    int UserChoice = int.Parse(Console.ReadLine());
    if (UserChoice == 1) // create contact
    {
        CallLog.Add(UserInteraction.GetDetails());
    }
    else if (UserChoice == 2)// Search contact
    {
        Console.Write("Enter Name          :");
        string? name = Console.ReadLine();
        Recents.AddRange(UserInteraction.FindContact(name, CallLog));
    }
    else if (UserChoice == 3)// View Dierectory
    {
        UserInteraction.OperateInContact(0, CallLog);
    }
    else if (UserChoice == 4)//Recent Searches
    {
        UserInteraction.OperateInContact(0, Recents);
    }
    else if (UserChoice == 5) //Favourites
    {
        UserInteraction.OperateInContact(1, CallLog);
    }
    else if (UserChoice == 6)
    {
        break;
    }
    else
    {
        Console.WriteLine("Invalid Input, Enter a valid Option");
    }
    Console.WriteLine("-------------------------------------------------");
}
