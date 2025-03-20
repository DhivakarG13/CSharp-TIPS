namespace Task_1
{
    public class Library
    {
        public List<string> LibraryBooks { get; set; }

        public Library()
        {
            LibraryBooks = new List<string>();
        }

        /// <summary>
        /// Gets a book and adds to Library Books.
        /// </summary>
        /// <param name="bookToAdd"></param>
        public void AddBook(string bookToAdd)
        {
            LibraryBooks.Add(bookToAdd);
        }

        /// <summary>
        /// Gets a book name and removes it from Library Books if Library Books contains book To Delete and prints the status message.
        /// </summary>
        /// <param name="bookToDelete"></param>
        /// <returns></returns>
        public bool RemoveBook(string bookToDelete)
        {
            if(LibraryBooks.Contains(bookToDelete))
            {
                LibraryBooks.Remove(bookToDelete);
                Console.WriteLine($"{bookToDelete} is removed \n");
                return true;
            }
            Console.WriteLine($"{bookToDelete} is not in library\n");
            return false;
        }

        /// <summary>
        /// Gets the book To Find and searches for the book in Library Books
        /// </summary>
        /// <param name="bookToFind"></param>
        /// <returns>true if book is found else false is returned</returns>
        public bool FindBook(string bookToFind)
        {
            if (LibraryBooks.Contains(bookToFind))
            {
                Console.WriteLine($"{bookToFind} is in library\n");
                return true;
            }
            Console.WriteLine($"{bookToFind} is not in library\n");
            return false;
        }

        /// <summary>
        /// Prints all the book in the Library Books.
        /// </summary>
        public void PrintAllBooks()
        {
            Console.WriteLine("Books In Library :");
            foreach (string book in LibraryBooks)
            {
                Console.WriteLine(book + " ");
            }
            Console.WriteLine();
        }
    }   
}
