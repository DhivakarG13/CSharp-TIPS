using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

List<ContactInfo> Contacts = new List<ContactInfo>();
List<ContactInfo> Recents = new List<ContactInfo>();
while (true)
{
    UserInteraction.PrintMenu();
    try
    {
        bool CloseApp = false;
        int UserChoice = int.Parse(Console.ReadLine());
        switch (UserChoice)
        {
            case 1:
                Contacts.Add(UserInteraction.GetDetails());
                Console.WriteLine("New Contact Added to your Contacts");
                break;

            case 2:
                Console.Clear();
                Console.Write("Enter Name          :");
                string? name = Console.ReadLine();
                Recents.AddRange(UserInteraction.FindContact(name, Contacts));
                break;

            case 3:
                UserInteraction.OperateInContact(0, Contacts);
                break;
            case 4:
                UserInteraction.OperateInContact(0, Recents);
                break;
            case 5:
                UserInteraction.OperateInContact(1, Contacts);
                break;
            case 6:
                CloseApp = true;
                break;
            default:
                Console.Clear();
                Console.WriteLine("Invalid Input, Enter a valid Option");
                break;

        }
        Console.WriteLine("-------------------------------------------------");
        if(CloseApp)
        {
            break;
        }
    }
    catch (InvalidCastException e)
    {
        Console.WriteLine("Enter 1/0 for Favorites");
    }
    catch
    {

        Console.Clear();
        Console.WriteLine("Invalid Input, Enter a valid Option/n");
        Console.WriteLine("----");
        Console.WriteLine("----");
    }

}
