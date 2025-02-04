using System.Collections.Generic;

public static class InventoryOperations
{

    public static List<Product> SearchInventory(List<Product> products)
    {


        Console.WriteLine("----------------------------------");
        Console.WriteLine("\n\n         -- Searching Your Product -- \n\n");
        Console.WriteLine("----------------------------------");

        List<Product> matchingProductIndexes = new List<Product>();

        Console.Clear();
        MessageService.DialogWriter(new SearchDialog());
        SearchDialog searchDialogChoice = (SearchDialog)UserInputService.GetUserChoice(new List<int> { 1, 2, 3, 4 });

        switch (searchDialogChoice)
        {
            case SearchDialog.Search_By_ProductName:
                string? productName = UserInputService.GetStringInput("Product Name");
                matchingProductIndexes = SearchByProductName(products , productName);
                break;
            case SearchDialog.Search_By_ProductId:

                int productId = UserInputService.GetNumericalValue("Product ID");
                matchingProductIndexes = SearchByProductId(products , productId);
                break;
            case SearchDialog.Search_By_Product_Prize_Range:

                int minPrice = UserInputService.GetNumericalValue("Minimum Value");
                int maxPrice = UserInputService.GetNumericalValue("Maximum Value");

                while (minPrice > maxPrice)
                {
                    MessageService.PrintWarning("Minimum value must be Lesser than or equal to MaximumValue");
                    minPrice = UserInputService.GetNumericalValue("Minimum Value");
                    maxPrice = UserInputService.GetNumericalValue("Maximum Value");
                }

                matchingProductIndexes = SearchByProductPrizeRange(products, minPrice, maxPrice);
                break;
            case SearchDialog.Search_By_ExpiryDate:
                matchingProductIndexes = SearchByExpiryDate(products);
                break;
        }

        if (matchingProductIndexes.Count == 0)
        {
            Console.Clear();
            MessageService.PrintError("\n\nNo results Match Your Search\n\n");
            MessageService.PrintActionFailed("Search Failed");
        }
        return matchingProductIndexes;
    }

    public static List<Product> SearchByProductName(List<Product> products , string? productName)
    {
        List<Product> matchingProducts = new List<Product>();

        foreach (Product product in products)
        {
            if (productName != null && product.ProductName != null && product.ProductName.Contains(productName))
            {
                matchingProducts.Add(product);
            }
        }
        return matchingProducts;
    }
    public static List<Product> SearchByProductPrizeRange(List<Product> products , int minPrice,int maxPrice)
    {
        List<Product> matchingProducts = new List<Product>();

        foreach (Product product in products)
        {
            if (product.ProductPrice >= minPrice && product.ProductPrice <= maxPrice)
            {
                matchingProducts.Add(product);
            }
        }
        return matchingProducts;
    }

    public static List<Product> SearchByProductId(List<Product> products , int productId)
    {
        List<Product> matchingProducts = new List<Product>();

        for (int productIndex = 0; productIndex < products.Count; productIndex++)
        {
            Product product = products[productIndex];
            if (product.ProductId == productId)
            {
                matchingProducts.Add(product);
                return matchingProducts;
            }
        }

        return matchingProducts;
    }
    public static List<Product> SearchByExpiryDate(List<Product> products)
    {
        List<Product> matchingProducts = new List<Product>();

        int dayNumber = 1;
        int monthNumber = 1;
        int yearNumber;

        DateOnly LastDate = new DateOnly();

        Console.WriteLine("Search by date Option");
        MessageService.DialogWriter(new SearchByDateDialog());
        SearchByDateDialog SearchByDateChoice = (SearchByDateDialog)UserInputService.GetUserChoice(new List<int>() { 1, 2, 3 });
        switch (SearchByDateChoice)
        {
            case SearchByDateDialog.Search_By_Day:
                {
                     dayNumber = UserInputService.GetNumericalValue("Day");
                    goto case SearchByDateDialog.Search_By_Month;
                }
            case SearchByDateDialog.Search_By_Month:
                {
                     monthNumber = UserInputService.GetNumericalValue("Month");
                    goto case SearchByDateDialog.Search_By_Year;
                }
            case SearchByDateDialog.Search_By_Year:
                {
                     yearNumber = UserInputService.GetNumericalValue("Year");

                    string toBeParsedLastDate = $"{dayNumber}/{monthNumber}/{yearNumber}";

                    bool isValidLastDate = DateOnly.TryParse(toBeParsedLastDate, out LastDate);

                    if( isValidLastDate )
                    {
                        foreach (Product product in products)
                        {
                            if (product.ExpiryDate <= LastDate)
                            {
                                matchingProducts.Add(product);
                            }
                        }
                    }
                    else
                    {
                        MessageService.PrintWarning("Wrong format of Date Entered");
                    }

                    break;
                }
        }
        return matchingProducts;
    }
    public static void PrintProducts(List<Product> productsToPrint)
    {
        if (productsToPrint.Count() == 1)
        {
            Console.Write(("\n Index : [0]"),15);
            MessageService.PrintProductDetails(productsToPrint[0]);
        }

        if (productsToPrint.Count() > 1)
        {
            Console.WriteLine($":: {productsToPrint.Count()} Products Matches Your Search");
            Console.WriteLine("[1]Continue [2]Print All Matching Product");
            int printDialogChoice = UserInputService.GetUserChoice(new List<int> { 1, 2 });
            if (printDialogChoice == 2)
            {
                PrintAllProducts(productsToPrint);
            }
        }
    }
    public static void PrintAllProducts(List<Product> productsToPrint)
    {
        int maxPrintLimit = 3;
        for (int productIndex = 0; productIndex < productsToPrint.Count; productIndex++)
        {
            Product product = productsToPrint[productIndex];
            Console.Write($"Index : {productIndex,15}");
            MessageService.PrintProductDetails(product);
            maxPrintLimit--;
            if (maxPrintLimit == 0 && productIndex != productsToPrint.Count - 1)
            {
                Console.WriteLine("\n ----- Print More? ----- \n");
                Console.WriteLine("  [1]Yes || [2]No  \n");
                int printMoreChoice = UserInputService.GetUserChoice(new
                        List<int> { 1, 2 });
                if (printMoreChoice == 2)
                {
                    break;
                }
                else
                {
                    maxPrintLimit = 3;
                }
            }
        }
    }
}
