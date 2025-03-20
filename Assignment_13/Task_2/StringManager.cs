namespace Task_2
{
    internal partial class Program
    {
        public class StringManager 
        {
            public static string? ReverseString(string stringToReverse)
            {
                List<char> listToReverse = stringToReverse.ToCharArray().ToList();
                listToReverse = ReverseArray<char>(listToReverse);
                return new string(listToReverse.ToArray());
            }

            private static List<T> ReverseArray<T>(List<T> listToReverse) 
            {
                Console.WriteLine("\n :: Reversing Using Stack ::\n");
                Stack<T> containerStack = new Stack<T>();

                foreach (T item in listToReverse)
                {
                    containerStack.Push(item);
                    Console.WriteLine($"Pushed {containerStack.Peek()} into a stack");
                }

                List<T> reversedList = new List<T>();
                int stringToReverseLength = containerStack.Count;
                while (stringToReverseLength != 0)
                {
                    Console.WriteLine($"Popping {containerStack.Peek()} from stack and adding it to a temporary list.");
                    reversedList.Add(containerStack.Pop());
                    stringToReverseLength--;
                }

                return reversedList;
            }
        }
    }
}
