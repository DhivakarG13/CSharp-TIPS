namespace Task_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            library.AddBook("Tamil");
            library.AddBook("Maths");
            library.AddBook("Science");
            library.AddBook("English");
            library.AddBook("Electronics");
            library.PrintAllBooks();
            library.RemoveBook("English");
            library.RemoveBook("fence");
            library.PrintAllBooks();
            Console.WriteLine(":: Search Operations ::");
            library.FindBook("Maths");
            library.FindBook("Tamil");
            library.FindBook("English");
            Console.ReadKey();
        }
    }
}
