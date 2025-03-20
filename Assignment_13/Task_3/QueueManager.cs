namespace Task_3
{
    public class QueueManager<T>
    {
        private Queue<T> _queueOfItems { get; set; }

        public QueueManager()
        {
            _queueOfItems = new Queue<T>();
        }

        /// <summary>
        ///  Gets the item name and adds it to the PeopleQueue.
        /// </summary>
        /// <param name="item"></param>
        public void AddItemToQueue(T item)
        {
            _queueOfItems.Enqueue(item);
        }

        /// <summary>
        /// Gets the number of item to remove from PeopleQueue and removes.
        /// </summary>
        /// <param name="numberOfItemsToRemove"></param>
        public void RemoveItemsFromQueue(int numberOfItemsToRemove)
        {
            Console.WriteLine($"Requested People to remove {numberOfItemsToRemove}\n");

            if (_queueOfItems.Count < numberOfItemsToRemove)
            {
                numberOfItemsToRemove = _queueOfItems.Count;
            }

            while (numberOfItemsToRemove != 0)
            {
                _queueOfItems.TryDequeue(out T? removedItem);
                Console.WriteLine($"{removedItem} is DeQueued.");
                numberOfItemsToRemove--;
            }
        }

        /// <summary>
        /// Prints all items in the queue.
        /// </summary>
        public void PrintItemInQueue()
        {
            Console.WriteLine("Items In Queue :");

            if (_queueOfItems.Count == 0)
            {
                Console.WriteLine("Queue Is Empty");
            }

            foreach (T item in _queueOfItems)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");
        }
    }
}
