namespace Task_1
{
    public class ListManager<T>

    {
        private List<T> _listOfItems;

        public ListManager()
        {
            _listOfItems = new List<T>();
        }

        public void AddItem(T itemToAdd)
        {
            _listOfItems.Add(itemToAdd);
        }

        public bool RemoveItem(T itemToDelete)
        {
            if(FindItem(itemToDelete))
            {
                _listOfItems.Remove(itemToDelete);
                Console.WriteLine($"{itemToDelete} is removed \n");
                return true;
            }
            return false;
        }

        public bool FindItem(T itemToFind)
        {
            if (_listOfItems.Contains(itemToFind))
            {
                Console.WriteLine($"{itemToFind} is in list\n");
                return true;
            }
            Console.WriteLine($"{itemToFind} is not in list\n");
            return false;
        }

        public void PrintItems()
        {
            Console.WriteLine("items In List :");
            foreach (var item in _listOfItems)
            {
                Console.WriteLine(item + " ");
            }
            Console.WriteLine();
        }
    }   
}
