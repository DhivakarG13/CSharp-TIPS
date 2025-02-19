namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "Dhivakar";
            name = StringManager.ReverseString(name);
            Console.WriteLine(name);
            Console.ReadLine();
        }
        public class StringManager
        {
            public static string ReverseString(string stringToReverse)
            {
                Stack<char> stringContainerStack = new Stack<char>();
                foreach (char c in stringToReverse)
                {
                    stringContainerStack.Push(c);
                }
                string reversedName = string.Empty;
                foreach (char c in stringToReverse)
                {
                    reversedName += stringContainerStack.Pop();
                }
                return reversedName;
            }
        }
    }
}
