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
            library.RemoveBook("fence");
            library.PrintBooks();
            Console.WriteLine(":: Search Operations ::");
            library.FindBooks("Maths");
            library.FindBooks("Tamil");
            library.FindBooks("English");
            Console.ReadKey();
        }
    }
}
