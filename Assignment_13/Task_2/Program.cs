namespace Task_2
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            string name = "Dhivakar";
            name = StringManager.ReverseString(name);
            Console.WriteLine(name);
            Console.ReadLine();
        }
    }
}
