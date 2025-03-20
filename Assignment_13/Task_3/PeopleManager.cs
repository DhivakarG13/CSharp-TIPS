namespace Task_3
{
    public class PeopleManager
    {
        public Queue<string> PeopleQueue { get; set; }

        public PeopleManager()
        {
            PeopleQueue = new Queue<string>();
        }

        /// <summary>
        /// Gets the person name and adds it to the PeopleQueue.
        /// </summary>
        /// <param name="personName"></param>
        public void AddPersonToQueue(string personName)
        {
            PeopleQueue.Enqueue(personName);
            Console.WriteLine($"Enqueued {PeopleQueue.Last()}");
        }

        /// <summary>
        /// Gets the number of people to remove from PeopleQueue and removes.
        /// </summary>
        /// <param name="numberOfPeopleToRemove"></param>
        public void RemovePeopleFromQueue(int numberOfPeopleToRemove)
        {
            Console.WriteLine($"Requested People to remove {numberOfPeopleToRemove}\n");
            if (PeopleQueue.Count < numberOfPeopleToRemove)
            {
                numberOfPeopleToRemove = PeopleQueue.Count;
            }

            while (numberOfPeopleToRemove != 0)
            {
                PeopleQueue.TryDequeue(out string? removedPersonName);
                Console.WriteLine($"{removedPersonName} is DeQueued.");
                numberOfPeopleToRemove--;
            }
        }

        /// <summary>
        /// Prints the name of all person in the queue.
        /// </summary>
        public void PrintPeopleInQueue()
        {
            Console.WriteLine("\nPeople In Queue :");

            if (PeopleQueue.Count == 0)
            {
                Console.WriteLine("\nQueue Is Empty");
            }

            foreach (string person in PeopleQueue)
            {
                Console.Write(person + " ");
            }
            Console.WriteLine("\n");
        }
    }
}
