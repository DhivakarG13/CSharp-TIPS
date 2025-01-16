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
        int UserChoice = int.Parse(Console.ReadLine());
        Console.Clear();

        switch (UserChoice)
        {
            case 1:
                var newContact = UserInteraction.GetDetails();
                if (newContact != null)
                {
                    Contacts.Add(newContact);
                    Console.WriteLine("New Contact Added to your Contacts.");
                }
                else
                {
                    Console.WriteLine("Failed to add contact. Please try again.");
                }
                break;

            case 2:
                Console.Write("Enter Name: ");
                string? name = Console.ReadLine();
                Recents.AddRange(UserInteraction.FindContact(name, Contacts));
                break;

            case 3:
                Console.WriteLine("All Contacts:");
                UserInteraction.OperateInContact(0, Contacts);
                break;

            case 4:
                Console.WriteLine("Recent Searches:");
                UserInteraction.OperateInContact(0, Recents);
                break;

            case 5:
                Console.WriteLine("Favorite Contacts:");
                UserInteraction.OperateInContact(1, Contacts);
                break;

            case 6:
                Console.WriteLine("Exiting the application...");
                return;

            default:
                Console.Clear();
                Console.WriteLine("Invalid Input. Please enter a valid option.");
                break;
        }

        Console.WriteLine("-------------------------------------------------");
    }
    catch (FormatException)
    {
        Console.Clear();
        Console.WriteLine("Invalid input. Please enter a valid number.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
}
