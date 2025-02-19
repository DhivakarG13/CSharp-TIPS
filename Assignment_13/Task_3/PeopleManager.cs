namespace Task_3
{
    public class PeopleManager
    {
        public Queue<string> PeopleQueue { get; set; }

        public PeopleManager()
        {
            PeopleQueue = new Queue<string>();
        }

        public void AddPersonToQueue(string PersonName)
        {
            PeopleQueue.Enqueue(PersonName);
        }

        public void RemovePersonFromQueue(int numberOfPeopleToRemove)
        {
            if (PeopleQueue.Count >= numberOfPeopleToRemove)
            {
                while (numberOfPeopleToRemove-- != 0)
                {
                    PeopleQueue.Dequeue();
                }
            }
            else
            {
                Console.WriteLine($"There are only {PeopleQueue.Count} people in the Queue");
                Console.WriteLine("Enter a valid count to remove from list\n");
            }
        }

        public void PrintPeopleInQueue()
        {
            Console.WriteLine("People In Queue :");
            if (PeopleQueue.Count == 0)
            {
                Console.WriteLine("Queue Is Empty");
            }
            foreach (var person in PeopleQueue)
            {
                Console.Write(person + " ");
            }
            Console.WriteLine("\n");
        }
    }
}
