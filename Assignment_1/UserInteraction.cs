public class UserInteraction
{
    public static void PrintMenu()
    {
        Console.WriteLine("[1] Create a new Contact");
        Console.WriteLine("[2] Search Contacts");
        Console.WriteLine("[3] View Directory");
        Console.WriteLine("[4] Recent Searches");
        Console.WriteLine("[5] Favorites");
        Console.WriteLine("[6] Exit");
        Console.WriteLine();

        Console.Write("Enter Your Choice: ");
    }
    /// <summary>
    /// Gets Details from User and stores in a object of type ContactInfo
    /// </summary>
    /// <returns> Object with Contact Details </returns>
    public static ContactInfo GetDetails()
    {
        try
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();

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

            ContactInfo contact = new ContactInfo
            {
                Name = name,
                MobileNumber = mobileNumber,
                EmailId = email,
                Notes = note,
                FavouriteStats = fav,
            };
            return contact;
        }
        catch (InvalidCastException e)
        {
            Console.WriteLine("Enter 1/0 for Favorites");
            return null;
        }
        catch
        {
            Console.WriteLine("Invalid Input, Enter a valid Option/n");
            return null;
        }
    }
        /// <summary>
        /// Search for the Contact in List
        /// </summary>
        /// <param name="name">Contact Name</param>
        /// <param name="Contacts">List of Contacts</param>
        public static List<ContactInfo> FindContact(string name, List<ContactInfo> Contacts)
        {
            int countOfMatches = 0;
            List<ContactInfo> recents = new List<ContactInfo>();
            foreach (ContactInfo contact in Contacts)
            {
                
                if (name == contact.Name)
                {
                    Console.WriteLine();
                    Console.WriteLine(contact.Name);
                    Console.WriteLine(contact.MobileNumber);
                    Console.WriteLine(contact.EmailId);
                    Console.WriteLine(contact.Notes);
                    Console.WriteLine();

                    countOfMatches++;
                    recents.Add(contact);
                }
            }
            if(countOfMatches==0)
            {
                Console.WriteLine("Your Contact List is Empty");
            }
            return recents;
        }

    /// <summary>
    /// Displays the Contacts
    /// </summary>
    /// <param name="choice">Users Choice</param>
    /// <param name="Contacts">List of Contacts</param>
    public static void OperateInContact(int choice, List<ContactInfo> Contacts)
    {
        Console.Clear();
        int countOfMatches = 0;
        foreach (ContactInfo contact in Contacts)
        {
            if (CommandValidation(choice, contact))
            {
                countOfMatches++;
                Console.WriteLine();
                Console.WriteLine(contact.Name);
                Console.WriteLine(contact.MobileNumber);
                Console.WriteLine(contact.EmailId);
                Console.WriteLine(contact.Notes);
                Console.WriteLine();
            }

        }
        if (countOfMatches == 0)
        {
            Console.WriteLine("Your List is Empty");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="choice">  </param>
        /// <param name="contact"></param>
        bool CommandValidation(int choice, ContactInfo contact)
        {
            if (choice == 0 || contact.FavouriteStats == 1)
            {
                return true;
            }
            return false;
        }
    }
}