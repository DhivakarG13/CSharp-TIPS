using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Helpers
{
    internal static class IdGenerator
    {
        public static  int ProductIdGenerator(List<Product> ExistingProducts)
        {
            bool IsValid = false;
            Random NewRandom = new Random();
            int NewId = 0;
            while (!IsValid)
            {
                NewId = NewRandom.Next(10000, 100000);
                IsValid = UserDataValidators.ValidateNewProductId(NewId, ExistingProducts);
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
                IsValid = UserDataValidators.ValidateNewUserId(NewId, inventory);
            }
            return NewId;
        }
    }
}
