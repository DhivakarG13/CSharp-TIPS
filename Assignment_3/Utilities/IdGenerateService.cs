
namespace Inventory.Helpers
{
    public static class IdGenerateService
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
    }
}
