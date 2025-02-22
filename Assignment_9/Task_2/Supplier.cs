namespace Task_2
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int SupplierProductId { get; set; }

        public Supplier(int supplierId , string supplierName, int productId)
        {
            SupplierId = supplierId;
            SupplierName = supplierName;
            SupplierProductId = productId;
        }
    }

}
//With the same List<Product> 

//Group products by category and count the products in each category. Each group should also have the most expensive product in that category. 

//Perform an inner join with a List<Supplier>, where Supplier is a class with properties SupplierId, SupplierName, and ProductId, to match products with their suppliers. 