namespace Task_2
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            string name = "Dhivakar";
            Console.WriteLine("\nString to reverse: " + name);
            name = StringManager.ReverseString(name);
            Console.WriteLine("\nReversed String: " + name);
            Console.ReadLine();
        }
    }
}
