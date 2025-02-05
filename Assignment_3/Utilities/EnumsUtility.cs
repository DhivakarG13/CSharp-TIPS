public enum MainDialog
{
    Create_Product = 1,
    Search_Product,
    Edit_Product_Details,
    View_All_Products,
    Delete_Product,
    Exit_App
}
public enum SearchDialog
{
    Search_By_ProductName=1,
    Search_By_ProductId,
    Search_By_Product_Prize_Range,
    Search_By_ExpiryDate
}
public enum EditDialog
{
    Edit_ProductName=1,
    Edit_ProductId,
    Edit_ProductPrice,
    Edit_ProductQuantity,
    Edit_ExpiryDate
}
public enum SetProductIdDialog
{ 
    Set_Own_ID =1,
    App_GenerateD_ID
}
public enum SearchByDateDialog
{
    Search_By_Day =1,
    Search_By_Month ,
    Search_By_Year 
}
