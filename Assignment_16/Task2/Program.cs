namespace Task2
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var numbers = new List<int>() { 1, 2, 3, 4, 5 };
            //numbers.Append(6);
            ////numbers.Add("a");// Throws compile time error
            ////numbers = new List<string>(); // This will not compile

            //dynamic letters = new List<char>();
            //letters.Add('a');
            //letters.Add("a");//Throws Runtime Exception
            //letters.Add(10);// Throws Runtime Exception
            ////letters = new List<int>(); // This will compile

            //foreach (var letter in letters)
            //{
            //    Console.WriteLine(letter);
            //}

            List<object> items = new List<object>();
            items.Add('a');
            items.Add("a");
            items.Add(10);

            foreach (dynamic item in items) //Type of item varies according to the operation and it's type
            {
                Console.WriteLine(item+1);
            }

            Console.ReadKey();
        }
    }
}
