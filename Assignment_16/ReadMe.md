# Assignment 16
## Task1

* In main method of the application a object of class Notifier is created which has an event OnAction.
* The method in Program class ConsoleWriter which matches the delegate signature of the event is subscribed two times to the event.
* A method in notifier class which invokes the OnAction event is called.
* In console the message is printed two times as the ConsoleWriter method is subscribed two times to the event.
---
## Task2
* Declared a variable "numbers" of type var .
* Defined it as a type of List<int> and initialized it with a list of integers.
* Tried To add a character -> It shows compile time error.
---
* Declared a variable "letters" of type dynamic.
* Defined it as a type of List<char>.
* Attempted to add strings and numbers to the list.
* But it only throws run time exception.
---
* Declared a list of objects and added data of various types.
* Tried to access the data using foreach loop.
* Used dynamic key word in foreach loop so that the data can be processed accordingly.
---
## Task3
* Declare a integer array.
* In the Array.Sort method passed the array and a lambda expression which sorts the array in ascending order.
---
## Task4
* Used Lambda expressions in the linq query to filter the data and select and modify data in array.
---
## Task5
* Created a class with three fields and three methods with same signature which compares two objects according to a field and returns the result of compare to method.
* in main class created a list of object and a delegate of similar signature to those methods is created.
* The list is sorted using the delegate three different times and printed.
---
## Task6	
* Explored Record types in c#.
* Used with keyword to create a new record object with modified fields of old.
* Tried to edit the record object fields which throws error.
* Two different records with same fields are compared and printed, they both have same reference.
---
## Task7
* created a list of base class which has 3 sub classes.
* In a foreach loop to access the methods in the objects of the list "is" key word is used.
* This checks the type of object and calls the method and returns true if the object is of parent or the child class of that object.