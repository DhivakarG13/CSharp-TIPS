namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            library.AddBook("Tamil");
            library.AddBook("Maths");
            library.AddBook("Science");
            library.AddBook("English");
            library.PrintBooks();
            library.RemoveBook("English");
            library.RemoveBook("ence");
            library.PrintBooks();
            Console.WriteLine(":: Search Operations ::");
            library.FindBooks("Maths");
            library.FindBooks("Tamil");
            library.FindBooks("English");
            Console.ReadKey();
        }
    }
    public class Library
    {
        public List<string> Books { get; set; }

        public Library()
        {
            Books = new List<string>();
        }

        public void AddBook(string bookToAdd)
        {
            Books.Add(bookToAdd);
        }

        public bool RemoveBook(string bookToDelete)
        {
            if(FindBooks(bookToDelete))
            {
                Books.Remove(bookToDelete);
                Console.WriteLine($"{bookToDelete} is removed \n");
                return true;
            }
            return false;
        }

        public bool FindBooks(string bookToFind)
        {
            if (Books.Contains(bookToFind))
            {
                Console.WriteLine($"{bookToFind} is in library\n");
                return true;
            }
            Console.WriteLine($"{bookToFind} is not in library\n");
            return false;
        }

        public void PrintBooks()
        {
            Console.WriteLine("Boooks In Library :");
            foreach (var book in Books)
            {
                Console.WriteLine(book + " ");
            }
            Console.WriteLine();
        }
    }   
}
