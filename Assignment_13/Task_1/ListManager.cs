namespace Task_1
{
    public class ListManager<T>
    {
        private List<T> _listOfItems;

        public ListManager()
        {
            _listOfItems = new List<T>();
        }

        /// <summary>
        /// Gets an item of type T and adds to the List.
        /// </summary>
        /// <param name="itemToAdd"></param>
        public void AddItem(T itemToAdd)
        {
            _listOfItems.Add(itemToAdd);
        }

        /// <summary>
        /// Gets an item of type T and removes from the List.
        /// </summary>
        /// <param name="itemToDelete"></param>
        /// <returns></returns>
        public void RemoveItem(T itemToDelete)
        {
            if (_listOfItems.Remove(itemToDelete))
            {
                Console.WriteLine($"{itemToDelete} is removed ");
            }
            else
            {
                Console.WriteLine($"\n{itemToDelete} is not in List Of Items\n");
            }
        }

        /// <summary>
        /// Gets the item to find and searches for the book in Library Books
        /// </summary>
        /// <param name="itemToFind"></param>
        public void FindItem(T itemToFind)
        {
            if (_listOfItems.Contains(itemToFind))
            {
                Console.WriteLine($"{itemToFind} is in list\n");
            }
            else
            {
                Console.WriteLine($"{itemToFind} is not in list\n");
            }
        }

        /// <summary>
        /// Prints all the items in the list of items.
        /// </summary>
        public void PrintItems()
        {
            if(!_listOfItems.Any())
            {
                Console.WriteLine("\nThe List is Empty.\n");
                return;
            }

            Console.WriteLine("\nitems In List :");
            foreach (T? item in _listOfItems)
            {
                Console.WriteLine(item + " ");
            }
        }
    }   
}
