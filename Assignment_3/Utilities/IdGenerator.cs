
namespace Inventory.Helpers
{
    public static class IdGenerator
    {
        public static int ProductIdGenerator(List<Product> ExistingProducts)
        {
            bool IsValid = false;
            Random NewRandom = new Random();
            int NewId = 0;
            while (!IsValid)
            {
                NewId = NewRandom.Next(10000, 100000);
                IsValid = ValidationService.ValidateNewProductId(NewId, ExistingProducts);
            }
            return NewId;
        }

        public static int UserIdGenerator(List<StorageSlot> inventory)
        {
            bool IsValid = false;
            Random NewRandom = new Random();
            int NewId = 0;
            while (!IsValid)
            {
                NewId = NewRandom.Next(10000, 100000);
                IsValid = ValidationService.ValidateNewUserId(NewId, inventory);
            }
            return NewId;
        }
    }
}
