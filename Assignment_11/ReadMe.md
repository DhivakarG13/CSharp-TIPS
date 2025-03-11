## Assignment_11 

### Task_1 :
#### Understandings:
* The reference types passes the reference of the Data to any method,
so any changes made to that reference in the method will reflect in the main data.
* Whereas the value type passes the copy of the data to the method,
therefore a new copy of the data will be created and those changes made in the copy will not be reflected in the main data
* A object to class and a struct variable is created and are passed to
the methods that edit them, but the changes were made to the main data in the class object and there is no change in the data of the value type data.

#### Experiments : 
* A struct method is declared inside the structure , which modifies the fields in the structure.
If that method is called the data of the struct is modified even though struct is a value type.

### Task_2:
* Two methods are declared one creates a integer array of size 1,00,00,000 and
another created 1,00,00,000 local variables , both adds all those data they had created.
#### Observations :
* When the large array is generated the heap memory is occupied more.
* But there is no change in heap memory when those large number of integer arrays are declared.
* This is because integer is a value type and the memory is occupied in stack.

### Task_3:
* A method which creates a list of large integer arrays is initialized.
* In a for loop large integer arrays are added to the list.
* The Large amount of heap memory is occupied.
* After the for loop the list is cleared and set to null.
* GC,Collect is called two times as the objects will be set as can be cleared in first cycle and may be missed out to collect,
Therefore the second GC collect is called so those left out objects can be cleared.
#### Observation :
After the Gc.Collect is called for the first time the diagnostic tools denote a lot of heap memory is cleared.
In the second GC.Collect some more memory in the heap is cleared.

### Task_4:
* Two classes called file reader and file writer is created.
* These classes has method to open a file to read content and write respectively.
* Error will be thrown if we try to make changes in the file if its already opened.
* So both of these classes implements the IDisposable Interface and method Dispose is created according to contract.
* The dispose method calls the dispose method of stream reader and stream writer respectively.
* The instances of file reader and writer classes are created and the operations are done inside a using statement.
* This ensures that the file is closed after the Using block is closed.

### Observation Videos:
### Task 2:
[Recording-20250311_084554.webm](https://github.com/user-attachments/assets/c6123e75-56db-4876-86b4-efff72e3eb39)
### Task 3:
[Recording-20250311_085244.webm](https://github.com/user-attachments/assets/68d92716-c3bf-4dbb-8b51-287d4373c378)
