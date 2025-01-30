
namespace Inventory.Helpers
{
    public static class IdGenerator
    {
        public static int ProductIdGenerator(List<Product> ExistingProducts)
        {
            bool isValidId = false;
            Random newRandom = new Random();
            int newId = 0;
            while (!isValidId)
            {
                newId = newRandom.Next(10000, 100000);
                isValidId = ValidationService.ValidateNewProductId(newId, ExistingProducts);
            }
            return newId;
        }

        public static int UserIdGenerator(List<StorageSlot> inventory)
        {
            bool isValidUserId = false;
            Random newRandom = new Random();
            int newId = 0;
            while (!isValidUserId)
            {
                newId = newRandom.Next(10000, 100000);
                isValidUserId = ValidationService.ValidateNewUserId(newId, inventory);
            }
            return newId;
        }
    }
}
