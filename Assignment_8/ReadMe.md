## Assignment_8

## Task 1: Understanding and Using try/catch/finally blocks :

### Try Block:
- The try block is used to enclose the code that might throw an exception.
- The try block must be followed by either catch or finally block or both.
### Catch Block:
- The catch block is used to handle the exception.
- It must be preceded by try block.
- You can have multiple catch blocks for a single try block.
- The catch block must be preceded by try block which means we can't use catch block alone.
- We can catch specific exceptions in the catch block.
- Example : OutOfRangeException, DivideByZeroException, etc.
- It is preferred to add the most specific exception first and the most general exception at the end.
- And a Global Exception should be added at the end to catch unexpected Exceptions.
### Finally Block:
- The finally block is used to execute important code such as closing a file or closing a database connection. 
- It is always executed even if an exception is not caught. 
- The finally block is optional and can be used only with the try-catch block.
- The finally block always executes after the try block and catch block executes. 
- The finally block also executes when an exception occurs. 
- The finally block is used to execute important code such as closing a file or closing a database connection.
- Finally block executes even if the catch block returns a value. 

#### Task Description:
- A simple application which gets two numbers from users, divide them and display the output.
- If the user enters the second number as 0 , the DivideNumbers method throws an error.
- If the user enters first number as 1 , the method intentionally throws a ArgumentOutOfRangeException.
- The application uses try/catch/finally blocks to handle the exceptions.
- a specific catch block is placed to catch Divide by Zero Exception.
- But there is no specific catch block for ArgumentOutOfRangeException.
- The ArgumentOutOfRangeException is caught by the general catch block / Global catch block.

##### ArgumentOutOfRangeException: 
- The ArgumentOutOfRangeException is thrown when the number of arguments provided in the list of object does not match the number of parameters expected by the method being invoked.
- This mismatch can occur if there are either too few or too many arguments in the newParameters list compared to what the method signature requires.

##### DivideByZeroException:
- The DivideByZeroException is thrown when an attempt is made to divide an integer or decimal number by zero.

## Task 2: Catching and Throwing Different Types of Exceptions :

- After Try block we can place several catch blocks to catch different types of exceptions.
- Different Types Of Exceptions:
  - DivideByZeroException
  - ArgumentOutOfRangeException
  - FormatException
  - NullReferenceException
  - IndexOutOfRangeException
  - FileNotFoundException
  - InvalidOperationException
  - InvalidCastException

#### Task Description:
- In Main method of the console app a list of integer is created and index of the element to print is taken from the user.
- If the user enters an index which is out of range, the application throws an IndexOutOfRangeException.
- A specific catch block is placed to catch IndexOutOfRangeException.

## Task 3: Defining and Using Custom Exception Classes :

### Custom Exception:
- Custom exceptions are user-defined exceptions.
- Custom exceptions are derived from the Exception class.

### Terminologies:
- #### StatusCode: 
  - The StatusCode is a property of the custom exception class.
  - Status codes can be used to identify the type of exception.
  - Example: 404 for Page Not Found, 500 for Internal Server Error, etc.
- #### Message: 
  - The Message is a property of the custom exception class.
  - The Message property is used to display the error message.
- #### InnerException: 
  - The InnerException is a property of the custom exception class.
  - The InnerException property is used to store the inner exception.

#### Task Description:
- A custom exception class called InvalidUserInputException is created which is derived from the exception class.
- If the user enters a any input which cannot be converted to an integer InvalidUserInputException thrown.

## Task 4: Handling Global Unhandled Exceptions using AppDomain's UnhandledException event :

### AppDomain:
- An AppDomain is a lightweight process that runs within a process.
- ![image](https://github.com/user-attachments/assets/7c633fa7-fa07-43cb-89c7-e54fbfa251a6)

- It is an Isolated container inside which .Net code runs, ,Net dlls and ,Net Objects execute.
- We can create several AppDomains in a single process.
- We can create a secured AppDomain load it by providing specific permissions to it and run untrusted code.
- ![image](https://github.com/user-attachments/assets/4c3ffa6e-d01f-4c4c-aa60-16d1360a0f7e)


### AppDomain's UnhandledException event:
- The AppDomain class has an event called UnhandledException.
- The UnhandledException event is raised when an exception is not caught in the application.

### DispatcherUnhandledException event:
- The Application class has an event called DispatcherUnhandledException.
- The DispatcherUnhandledException event is raised when an exception is not caught in the application.

#### Task Description:
- A console application is created which throws an error if the user enters 0 as input.
- Because the application is for getting a number from user and dividing 10 by the number. so 0 is not allowed.
- There is no try catch block to handle the exception.
- A method called GlobalExceptionHandler is created which handles the unhandled exception.
- The GlobalExceptionHandler method is subscribed to the AppDomain's UnhandledException event.
- The GlobalExceptionHandler method is called when an unhandled exception occurs.
- The GlobalExceptionHandler method displays a message "An Unexpected error occurred". 

## Task 5: Using and global exception handler console application:

- A console application is created which throws an error if the user enters 0 as input.
- The instance of the class which has method which throws error is declared with in a Using block.
- There is no catch block inside the Using block.
- A global exception handler is created which handles the unhandled exception.
- The global exception handler is subscribed to the AppDomain's UnhandledException event.
- Inside the global exception handler, the exception is caught and the stack trace is displayed.

#### Stack Trace:
- The stack trace is a report of the active stack frames at a particular point in time during the execution of a program.
- The stack trace is a snapshot of the call stack at the time of the exception.
- The stack trace is used to identify the sequence of method calls that led to the exception.


