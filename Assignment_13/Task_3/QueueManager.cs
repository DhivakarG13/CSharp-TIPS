namespace Task_3
{
    public class QueueManager<T>
    {
        private Queue<T> _queueOfItems { get; set; }

        public QueueManager()
        {
            _queueOfItems = new Queue<T>();
        }

        public void AddItemToQueue(T item)
        {
            _queueOfItems.Enqueue(item);
        }

        public void RemoveItemFromQueue(int numberOfItemToRemove)
        {
            if (_queueOfItems.Count >= numberOfItemToRemove)
            {
                while (numberOfItemToRemove-- != 0)
                {
                    _queueOfItems.Dequeue();
                }
            }
            else
            {
                Console.WriteLine($"There are only {_queueOfItems.Count} item in the Queue");
                Console.WriteLine("Enter a valid count to remove from list\n");
            }
        }

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
