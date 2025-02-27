# ExpenseTracker

## Add Action

### [1] Add Income
* User Can Add his Income to the repository.
* User will be asked to enter - Source Of Income, a list of predefined values will be listed ,
the user can add his own source too by choosing "other" option and entering the value.
* The Source has set of Instructions.
###### (Instructions to enter Name): 
* Name should not be null or empty.
* Length of the name of source should be minimum 5.
* No numerical values are allowed in name.
* No white space allowed in between

* User will be asked to enter the amount.
##### (Instructions to enter amount):
* The input must be a valid positive number, no other numerical values allowed.

* A transaction ID will be generated for the user.
* Transaction Id : Unique 5 digit number.

* User will be provided option to add the current Date or His own Date.
* By choosing add current date the date of transaction is set to the current date automatically.
#### (Instructions to enter date):
* If the user wants to enter his own date it should be in (DD/MM/YYYY) format.
* Invalid values will ask you to re enter the value.

### [2] Add Expense
* User Can Add his Expense to the repository.
* User will be asked to enter - Source Of Expense, a list of predefined values will be listed ,
the user can add his own source too by choosing "other" option and entering the value.
* The Source has set of Instructions.
###### (Instructions to enter name): 
* Name should not be null or empty.
* Length of the name of source should be minimum 5.
* No numerical values are allowed in name.
* No white space allowed in between

* User will be asked to enter the amount.
##### (Instructions to enter amount):
* The input must be a valid positive number, no other numerical values allowed.

* A transaction ID will be generated for the user.
* Transaction Id : Unique 5 digit number.

* User will be provided option to add the current Date or His own Date.
* By choosing add current date the date of transaction is set to the current date automatically.
#### (Instructions to enter date):
* If the user wants to enter his own date it should be in (DD/MM/YYYY) format.
* Invalid values will ask you to re enter the value.

### [3] SearchAction 
* User can search the actions using:

#### [i]Action Source:
* User should enter the name Of source
* Full name of the source is not expected . A part of name is enough for search.
###### (Instructions to enter name):
* At least 3 Characters are required.
* No space in between allowed.

#### [ii] Action :
* The user will be provided two choices [1]Income [2]Expense.
* List of Incomes or Expenses will be printed according to the choice.
##### (Instructions to choose Action):
* The user can only choose between two options.
* The valid inputs are 1 and 2.


#### [iii] Action Id:
* User should enter the transaction ID to get the action data.
##### (Instructions to enter Id):
* Numerical values expected, no other special characters allowed.
* Negative numbers not allowed.
* It should be a 5 digit number.

#### [iv] Action Date:
* User can search the action by date.
* User will be provided with three options [1]Day [2]Month [3]Year.
* [1] Day : If the user choose [1]Day The values of day, month and year will be asked.
* [2] Month : If the user choose [2]Month The values of month and year will be asked.
* [3] Year : If the user choose [3]Year The values of year will be asked.
* The actions on the particular date will be listed.
##### (Instructions to enter search inputs):
* The input value must be a valid number.
* no characters or spaces are allowed in between.
* The day,month and year must form a proper valid date.

### [4] Close Application
* User can close the application