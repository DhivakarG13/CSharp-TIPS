namespace Task_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sum Of List: " + SumOfElements(new List<int>() { 1, 2, 3 }));
            Console.WriteLine("Sum Of Array: " + SumOfElements(new int[] { 1, 2, 3 }));
            Queue<int> queueOfNUmbers = new Queue<int>();
            queueOfNUmbers.Enqueue(1);
            queueOfNUmbers.Enqueue(2);
            queueOfNUmbers.Enqueue(3);
            Console.WriteLine("Sum Of Queue: " + SumOfElements(queueOfNUmbers));
            Stack<int> stackOfNUmbers = new Stack<int>();
            stackOfNUmbers.Push(1);
            stackOfNUmbers.Push(2);
            stackOfNUmbers.Push(3);
            Console.WriteLine("Sum Of Stack: " + SumOfElements(stackOfNUmbers));
            IReadOnlyDictionary<string, int> readOnlyDictionary = GenerateDictionary();
            // readOnlyDictionary["Hello"] = 1; // Throws error because readOnlyDictionary is of IReadOnlyDictionary<string, int>
            DictionaryPrinter(readOnlyDictionary);
            Console.ReadKey();
           
            int SumOfElements(IEnumerable<int> numbersToAdd)
            {
                int sumOfNumbers = 0;
                foreach (int number in numbersToAdd)
                {
                    sumOfNumbers += number;
                }
                return sumOfNumbers;
            }

            IReadOnlyDictionary<string, int> GenerateDictionary()
            {
                Dictionary<string, int> numberData = new Dictionary<string, int>();
                numberData.Add("One", 1);
                numberData.Add("Two", 2);
                numberData.Add("Three", 3);

                return numberData;
            }
            
            void DictionaryPrinter<T1, T2>(IReadOnlyDictionary<T1, T2> DictionaryToPrint)
            {
                foreach(KeyValuePair<T1, T2> item in DictionaryToPrint)
                {
                    Console.WriteLine($"{item.Key} : {item.Value}");
                }
            }
        }
    }
}