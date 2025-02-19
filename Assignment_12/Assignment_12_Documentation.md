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
## Task 3

### Memory Profiling

#### Task1 Observations

* The optimised Heap memory increases gradually which reaches a maximum limit of heap memory and throws an error.

#### Task2 Observations

* when the user asks for memory Allocation , The memory will be allocated.