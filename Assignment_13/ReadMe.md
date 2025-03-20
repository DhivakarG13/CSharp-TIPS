### Task-1 Lists:
* A class named "Library" with a property of type List of String is created.
* Add Operation: In the list a new string is added/appended using .Add() method.
* Remove Operation: Using .Remove() the given string is removed from the list of string. Alternate: get index and use .RemoveAt(indexToRemove);
* Search Operation: Using .Contains(stringToSearch) search operation is performed.
* Iterated through the existing list to print all strings.

### Task-2 Stack:
* Challenge: Reverse a string using stack.
* A stack of character type is declared.
* ![image](https://github.com/user-attachments/assets/7912c248-78d3-46aa-87e7-6cbeb619b910)
* Using .Push(character to add) the characters of the string to reverse is pushed into the stack.
* Using .Peek() the element in the top of the stack is obtained and printed.
* An object of string builder type is declared.
* The characters form the stack is popped using .Pop() and Appended to stringBuilder object using .Append();
* Now the string builder is exactly the reverse of string input.

### Task-3 Queue:
* Challenge: Add and remove people from Queue.
* A Class with a property of type Queue of string is declared.
* Add Operation: Using .Enqueue(string to add) a string is added to last of our queue.
* ![image](https://github.com/user-attachments/assets/fa589020-3adf-468f-9265-9ef749d198e3)
* Remove Operation: Number of strings to remove is obtained and using .TryDequeue(out string? RemovedPerson) the first element of the queue is removed . The TryDequeue returns the value of element enqueued if the operation is successful.
* By Iterating through the queue the values of queue is printed.

### Task-4 Dictionaries:
* A Dictionary of string type Key and integer type value is created.
* It represents a Student Name , Grade pair.
* Add Operation: Using .Add(Student Name , Grade) an new key value pair is added to the dictionary.
* If there's already a key in the dictionary matching the existing key an exception is thrown. Therefore before adding .ContainsKey(studentName) is done to check. If the Key already exists the existing key is updated with the new Grade by StudentLog[studentName] = studentGrade;
* Remove operation: using .Remove(Key to remove) the key is removed. The .Remove() Doesn't throw any error even there is no Key matching the key to remove.
  
