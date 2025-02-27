# Inventory Manager:

## Features:
###   [1]  Create_Product
###   [2]  Search_Product
###   [3]  Edit_Product_Details
###   [4]  View_All_Products
###   [5]  Delete_Product
###   [6]  Exit_App

# User Directions

## [1] Create_Product:
In main page click 1 to create a new product.
### Inside Create_Product Page.

1. Enter name of the product,Click Enter.
2. Enter quantity of the product,Click Enter.
3. Enter Price of the product,Click Enter.
4. Choose Set Product ID option [1] | [2].
5. For [1]  Set_Own_ID - Enter your own ID (Range : 1000 - 9999).
6. For [2]  App_GenerateD_ID Your auto generated ID will be displayed.
7. Enter the Expiry Date Of the of the product.

## [2]  Search_Product:
In main page click 2 to search your product.
### Inside Search_Product Page.
####   [1]  Search_By_ProductName
####   [2]  Search_By_ProductId
####   [3]  Search_By_Product_Prize_Range
####   [4]  Search_By_ExpiryDate

##### [1] Search_By_ProductName:
- Press 1 to open to Search By ProductName tab.
- Enter at least 3 characters of the product in sequence to search your product.
- If the product is present the details will be viewed else search will be failed 
and you'll get back to main page.

##### [2]  Search_By_ProductId:
- Press 2 to open to Search By Product Id tab.
- Enter your product Id to search your product.
- If the product is present the details will be viewed else search will be failed 
and you'll get back to main page.

##### [3]  Search_By_Product_Prize_Range:
- Press 3 to open to Search By Product_Prize_Range tab.
- In Search_By_Product_Prize_Range page enter the minimum and maximum of the range value to search your product.
- If the product is present the details will be viewed else search will be failed 
and you'll get back to main page.

##### [4]  Search_By_ExpiryDate:
- Press 4 to open to Search By Product Expiry Date tab.
#### [1]  Search_By_Day
#### [2]  Search_By_Month
#### [3]  Search_By_Year

##### [1]  Search_By_Day
- Press 1 to open to Search By Day tab.
- Enter your Day number , Month number and Year number.
- If some of the products is expiring before the date will be viewed else search will be failed 
and you'll get back to main page.
##### [2]  Search_By_Month:
- Press 1 to open to Search By Day tab.
- Enter your Month number and Year number.
- If some of the products is expiring before the date will be viewed else search will be failed 
and you'll get back to main page.
##### [3]  Search_By_Year:
- Press 1 to open to Search By Day tab.
- Enter your Year number.
- If some of the products is expiring before the date will be viewed else search will be failed 
and you'll get back to main page.

## [3]  Edit_Product_Details:
In main page click 3 to search your product and if the product is found choose the index of product to edit.
### Edit Page options :
###  [1]  Edit_ProductName
###  [2]  Edit_ProductId
###  [3]  Edit_ProductPrice
###  [4]  Edit_ProductQuantity
###  [5]  Edit_ExpiryDate

Choose any option and Enter your new value to update the values.
- ::  [1] Yes  ::  [2] No  ::
- Choose 1 to edit another entity of the same product.
- Choose 2 to exit.

## [4]  View_All_Products:
In main page click 4 to View All Products in the Inventory.

## [5]  Delete_Product
- In main page click 4 to Delete Product from Inventory.
- Search your product to delete.
- Choose the index from search result to delete the product if the search is successful.

## [6]  Exit_App
In main page click 6 to Close the application.

## Input Instructions : 
1. For Dialogs Choose a valid Option(number in range) to continue.
2. For Product name - [1] At least 5 characters required, [2] Should Contain at least an Alphabet and [3] No Space is allowed InBetween.
3. For Product price - [1] Numerical values Expected and [2] Negative numbers NotAllowed.
4. For Product Id - [1] User ID should be a four digit positive Number.
5. Any numerical values should be positive.
6. For search product name input at least 3 letters long.
----------

# Testing for Inventory manager :

## Tested Classes:
### 1) SearchOperations:
#### Methods Tested : 
##### [1] SearchByProductId:
- Tested with giving product IDs in the list, output "product with the matching ID".
- Tested with giving product IDs not in the list, output "Empty List of products".
##### [2] SearchByProductPriceRange:
- Tested with giving minimum and maximum price range for which the product is available in the list, output "List of products in the range".
- Tested with giving minimum and maximum price range for which the product is not available in the list, output "Empty List of products".
##### [3] SearchByProductName:
- Tested with giving product Name in the list, output "list of products with the matching name".
- Tested with giving product Name not in the list, output "Empty List of products".
- Edge cases : Returned false for empty string input ans invalid inputs.

### 2) IdGenerateService
#### Methods Tested : 
##### [1] ProductIdGenerator:
- The method's role is to generate new ID which is not in the given list.
- Tested whether the new generated ID is in range.
- Tested whether the new generated ID is not in the List.
### 1) ValidationService

#### Methods Tested :
##### [1] ValidateChoice:
- Tested whether the method returns false for non numerical inputs and out of range values.
##### [2] ValidateNumericalInputs:
- Tested whether the method returns false for non numerical inputs and negative numbers.
##### [3] ValidatePrice:
- Tested whether the method returns false for non numerical inputs and out of range values.
##### [4] ValidateProductIndexChoice:
- Tested whether the method returns false for non numerical inputs and negative numbers.
##### [5] ValidateStringValue:
- Tested whether the method returns false for strings with no alphabets and has space in between.
##### [6] ValidateProductName:
- Tested whether the method returns false for strings with any number in it and has space in between.
##### [7] ValidateNewProductId:
- Tested whether the method returns a new Id that's not in the input list of products.
