# Assignment_12_Memory Optimization

## Task 1: Detecting and Diagnosing Memory Issues

### Detected Memory Issues:
* The Allocate method allocates a array of size 100000.
* size of int = 4 bytes. 4 x 100000 = 400000 bytes = 400 KB.
* memAlloc occupies space in Large Object Heap which is less frequently analyzed
and cleared.
* All the integer arrays have active references therefore the garbage collectors 
cant clear the memory even it checks LOH during the cycle.
* There is no break to while loop therefore the memory will be allocated infinitely.
* Thread.sleep(10) is less time provided for infinite memory allocation, it throws error.

--------------------------------------------------------
## Task 2

### Approach_1 Task_2
* The user will be asked to enter the number of arrays to add in list.
* There will be a limit for the number of Arrays to store in a list.
* If the number of lists reaches more than the limit list will be cleared and one array will be added to the List.
* The user is repeatedly asked to add the memory and he can't add more than 100 arrays and the maximum limit is 500,
after the limit is reached the memAlloc is cleared and set for new List<Array>().
* This makes the memory allocation smooth and memory is cleared properly.

--------------------------------------------------------
## Task 2

### Approach_2 Task_2_Alternate

* The Program runs an infinite loop.
* Thread sleep time was increased to throttle the rate of resource acquisition to avoid overwhelming the system.
* When the number of arrays reaches a limit the list is cleared Which removes the reference to lots of Objects now they are eligible for collection. 
* Then GC is triggered twice.
* First GC.Collect() initiates a garbage collection cycle, which may not immediately reclaim all eligible objects.
* The second call can help ensure that any objects that became eligible for collection during or after the first cycle are also collected.
* After calling GC.Collect() GC.WaitForPendingFinalizers() is called to ensure that all finalizers have completed before proceeding.

-------------------------------------------------------
## Task_3

### Memory Profiling

#### Task1 Observations
![image](https://github.com/user-attachments/assets/2f080133-a54c-42d7-bc4b-e70dd60238dd)
* The optimised Heap memory increases gradually which reaches a maximum limit of heap memory and throws an error.

#### Task2 Observations
![Task_2_Diognostics](https://github.com/user-attachments/assets/57153953-da0d-46dd-b6fd-7405d042f97b)
* when the user asks for memory Allocation , The memory will be allocated.

### Task2 alternate Observations
![image](https://github.com/user-attachments/assets/0f12529c-58dc-4e6a-9a1e-03614a2eebbd)
* The control enters an infinite allocation, but after it reaches the limit the memory is cleared and allocation starts from beginning.

------------------------------------------------------
## Task_4

## Learnings in this assignment:
### Memory Management Best Practices:
* Calling GC.COllect() frequently costs the application performance.
* Optimising your code properly so when the gc gets called by it's own clears those unused memory.
* Allocating a large amount of memory repeatedly in a while loop is not advisible, using thread.Sleep() is better.
* Large objects enters Gen2 after the first cycle, so when the reference to is made as null, we can call GC.Collect(2) to clear those, as the gen2 is not collected frequently.
* Calling GC.WaitForPendingFinalizers() is a good practice after calling  GC.Collect() as it waits till all the finalizers of the objects are executed

