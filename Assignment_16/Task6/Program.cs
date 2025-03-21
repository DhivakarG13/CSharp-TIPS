using System.Buffers.Text;
using System;

namespace Task6
{
    public class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("Physics", "Jack", "1234");
            Book book2 = new Book("Chemistry", "Joe", "5678");
            Book book3 = new Book("English", "Jane", "9101");
            Book book4 = new Book("English", "Jane", "9101");
            Console.WriteLine(book3 == book4);
            // book1.Title = "Biology"; //Throws Error
            Book book5 = book2 with { Title = "History" };
            book5.DisplayBook();
            book2.DisplayBook();
            Console.ReadKey();
        }
    }
}