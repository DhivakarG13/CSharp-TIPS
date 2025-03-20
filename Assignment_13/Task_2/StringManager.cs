using System.Text;

namespace Task_2
{
    internal partial class Program
    {
        public class StringManager
        {
            public static string ReverseString(string stringToReverse)
            {
                Stack<char> stringContainerStack = new Stack<char>();
                Console.WriteLine("\n :: Reversing String ::");
                Console.WriteLine("\n :: Pushing characters in string to a stack ::");
                foreach (char c in stringToReverse)
                {
                    stringContainerStack.Push(c);
                    Console.WriteLine($"Pushed {stringContainerStack.Peek()} into a stack");
                }

                Console.WriteLine("\n :: Popping characters from stack and appending to string builder::");
                StringBuilder reversedString = new StringBuilder();
                int stringToReverseLength = stringToReverse.Length;
                while (stringToReverseLength != 0)
                {
                    Console.WriteLine($"Popping {stringContainerStack.Peek()} from stack and appending it to string builder");
                    reversedString.Append(stringContainerStack.Pop());
                    stringToReverseLength--;
                }

                return reversedString.ToString();
            }
        }
    }
}
