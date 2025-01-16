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

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.WriteLine(name);

            string mobileNumber;
            while (true)
            {
                Console.Write("Enter Mobile Number (10 digits): ");
                string? mobileInput = Console.ReadLine();

                // Validate mobile number
                if (!string.IsNullOrEmpty(mobileInput) &&
                    mobileInput.Length == 10 &&
                    long.TryParse(mobileInput, out _))
                {
                    mobileNumber = mobileInput;
                    break; // Exit loop if valid
                }

                Console.WriteLine("Invalid input. Please enter a 10-digit number.");
            }

            Console.Write("Enter Email ID: ");
            string? email = Console.ReadLine();
            Console.WriteLine(email);

            Console.Write("Enter a Note: ");
            string? note = Console.ReadLine();
            Console.WriteLine(note);

            int fav;
            while (true)
            {
                Console.Write("Add to Favorites (1 for Yes, 0 for No): ");
                string favInput = Console.ReadLine();

                // Validate input
                if (int.TryParse(favInput, out fav) && (fav == 1 || fav == 0))
                {
                    break; // Exit loop if input is valid
                }

                Console.WriteLine("Invalid input. Please enter 1 for Yes or 0 for No.");
            }

            ContactInfo contact = new ContactInfo
            {
                Name = name,
                MobileNumber = mobileNumber,
                EmailId = email,
                Notes = note,
                FavoriteStats = fav,
            };
            return contact;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
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
                Console.WriteLine("Your Search Doesn't match any contacts");
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
        /// Validates whether you are searching for favorite or recent.
        /// </summary>
        /// <param name="choice">  </param>
        /// <param name="contact"></param>
        bool CommandValidation(int choice, ContactInfo contact)
        {
            if (choice == 0 || contact.FavoriteStats == 1)
            {
                return true;
            }
            return false;
        }
    }
}