namespace Task_4
{
    public class QueueManager<TKey,TValue>
    {
        private Dictionary<TKey, TValue> _queueOfItems;

        public QueueManager()
        {
            _queueOfItems = new Dictionary<TKey, TValue>();
        }

        public void AddItem(TKey keyItem, TValue valueItem)
        {
            if (_queueOfItems.ContainsKey(keyItem))
            {
                Console.WriteLine($"Student named {keyItem} is already in the StudentLog\n");
            }
            else
            {
                _queueOfItems.Add(keyItem, valueItem);
            }
        }

        public void RemoveItem(TKey keyItem) 
        {
            if (! _queueOfItems.ContainsKey(keyItem))
            {
                Console.WriteLine($"{keyItem} is not in the StudentLog\n");
            }
            else
            {
                Console.WriteLine($"Removed {keyItem} from StudentLog\n");
            }
            _queueOfItems.Remove(keyItem);
        }

        public void SearchItem(TKey keyItem)
        {
            if(_queueOfItems.ContainsKey(keyItem))
            {
                Console.WriteLine(_queueOfItems[keyItem]);
            }
            else
            {
                Console.WriteLine($"{keyItem} is not in the StudentLog\n");
            }
            Console.WriteLine();
        }

        public void PrintItemDetails()
        {
            Console.WriteLine("Items in Dictionary :");
            foreach(KeyValuePair<TKey, TValue> item in _queueOfItems)
            {
                Console.WriteLine(item.Key + " " + item.Value );
            }
            Console.WriteLine();
        }
    }
}