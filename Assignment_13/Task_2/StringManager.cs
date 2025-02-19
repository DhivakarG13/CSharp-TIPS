using System.Text;

namespace Task_2
{
    internal partial class Program
    {
        public class StringManager
        {
            public static string? ReverseString(string stringToReverse)
            {
                char[] arrayToReverse = stringToReverse.ToCharArray();
                ReverseArray(arrayToReverse);
                return new string(arrayToReverse);
            }
            private static void ReverseArray<T>(T[] arrayToReverse)
            {
                Stack<T> stringContainerStack = new Stack<T>();
                foreach (T c in arrayToReverse)
                {
                    stringContainerStack.Push(c);
                    Console.WriteLine($"Pushed {stringContainerStack.Peek()} into a stack");
                }
                int index = 0;
                foreach (T c in arrayToReverse)
                {
                    arrayToReverse[index] = stringContainerStack.Pop();
                    ++index;
                }
            }
        }
    }
}
