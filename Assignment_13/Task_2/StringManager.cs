namespace Task_2
{
    internal partial class Program
    {
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
