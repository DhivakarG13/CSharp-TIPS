public class UserInteraction
{
    public static void PrintMenu()
    {
        Console.WriteLine("[1] Create a new Contact");
        Console.WriteLine("[2] Search Contacts");
        Console.WriteLine("[3] View Dierectory");
        Console.WriteLine("[4] Recent Searches");
        Console.WriteLine("[5] Favourites");
        Console.WriteLine("[6] Exit");
        Console.WriteLine();

        Console.Write("Enter Your Choice: ");
    }
    public static ContactInfo GetDetails()
    {
        Console.Write("Enter Name:");
        string name = Console.ReadLine();
        Console.WriteLine(name);

        Console.Write("Enter Mobile Number :");
        string? mobileNumber = Console.ReadLine();
        Console.WriteLine(mobileNumber);

        Console.Write("Enter EmailID       :");
        string? email = Console.ReadLine();
        Console.WriteLine(email);

        Console.Write("Enter a Note        :");
        string? note = Console.ReadLine();
        Console.WriteLine(note);

        Console.WriteLine("Add toFavourites(1/0):");
        int fav = int.Parse(Console.ReadLine());
        Console.WriteLine();

        ContactInfo cls = new ContactInfo
        {
            Name = name,
            MobileNumber = mobileNumber,
            EmailId = email,
            Notes = note,
            FavouriteStats = fav,
        };
        return cls;
    }
    public static List<ContactInfo> FindContact(string name, List<ContactInfo> callLog)
    {
        List<ContactInfo> recents = new List<ContactInfo>();
        foreach (ContactInfo cls in callLog)
        {
            if (name == cls.Name)
            {
                Console.WriteLine();
                Console.WriteLine(cls.Name);
                Console.WriteLine(cls.MobileNumber);
                Console.WriteLine(cls.EmailId);
                Console.WriteLine(cls.Notes);
                Console.WriteLine();

                recents.Add(cls);
            }
        }
        return recents;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="choice"></param>
    /// <param name="callLog"></param>
    public static void OperateInContact(int choice, List<ContactInfo> callLog)
    {
        foreach (ContactInfo cls in callLog)
        {
            if (CommandValidation(choice, cls))
            {
                Console.WriteLine();
                Console.WriteLine(cls.Name);
                Console.WriteLine(cls.MobileNumber);
                Console.WriteLine(cls.EmailId);
                Console.WriteLine(cls.Notes);
                Console.WriteLine();
            }
        }
        bool CommandValidation(int choice, ContactInfo cls)
        {
            if (choice == 0)
            {
                return true;
            }
            else if (cls.FavouriteStats == 1)
            {
                return true;
            }
            return false;
        }
    }
}