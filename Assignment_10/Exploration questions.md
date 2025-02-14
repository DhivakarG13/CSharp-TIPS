# CSharp-TIPS
 
## 1) Explain what the .Net ptalform is s its primary Purpose?
### Net is a Frame work
* Framework provides standard way to build and deploy applications.
* It includes support programs, compilers, code Libraries and APIs
* The framework decides the program flow, memory management & etc.
 
### Dot Net
* Dot Net is a Frame work which helps a user to build application using C# / F# /Python
* These Language has their own compiler. which converts the code to CIL (common Intermediate Language)
 
### FCL - FrameWork Class Library 
* Includes: WPF, ASP.NET, Windows Forms, WF (Workflowe foundation), LINQ, WCF, data access, data base connectivity & network communication.
 
### CLR - Common Language RunTime
* provides services like memory management, exception handling, Garbage collection, Thread management, Type Safety.
* Net Framework provide language inter-operability
 code written in different languages is converted to CIL and all the codes are inter_operable now.
![image](https://github.com/user-attachments/assets/7f48fcfd-e3fd-444b-8ff9-578a94cb043f)


## 2) What are the key components of Net platform?
 
* CLI -> Common Language Infrastructure
* JIT compiler -> converts CIL to machine code
* FCL -> Framework Class Library

### Services:
- Memory management
- Type safety
- Exeption handliny
- Garbage collection
- Thread management

## 3) Differentiate between the Common Language Runtime (CLR) and the Common Type System (CTS) in .NET. 
 
#### Common Language Runtime
* It does mutiple operations with Compiled Intermediate Language.
* Memory management, GC, Just in time compilation, Thread management.

#### Common Type System
* Provides common data Types to all datas across Languages.
* Provides type safety.
* Defines rules regarding any operations with types.

## 4) What is the role of the Global Assembly Cache (GAC) in .NET? 

### Global Assembly Cache
* Provided by CLR
* Used to store assemblies.
* Act as central place for registering Assemblies.
* Assemblies are installed into GAC
* Improves performance
The CLR looks int GAC for Asenbly reference if it is not available it looks into application directory. 

## 5) Difference between value type & Refernce type
Common Type System decides which data should be a value type or reference type.

### Stack:
* One per thread.
* One satck is Reserved for each thread.
* Thread stores the temporary data, instructions, to execute.
* Small (1-4 MB).
* No gaps between data.
* Automatic removal of data.
* Fast

### Heap:
* One Heap is allocated per app.
* Large
* Initially a space is allocated & can be Resized later.
* Can be defragmented, Garbage collector is used.
* Slow

### Value types:
* Derived from System.ValueType (Derived from object).
* Eg : Int, decimal, date Time, bool, structs.
* Value type variables has the actual data.

### Reference Types:
* Derived from system.Objet.
* Eg : Array, object.
* Reference type variable has memory location of the data.

## 6) Describe the concept of Garbage collection.

* Heap's memory management mechanism is called Garbage collection.
* system-level service provided Common Language Runtime.
* The GC works behind the scenes to manage memory allocation and deallocation for .NET applications.
 
### Triggers of GC
1) When OS informs CLR only little memory left.
2) When amount of memory occupied by objects on heap surpasses a given threshold.
3) When a GC.collect() method is called.
 
* GC Runs on a seperate thread.
* Removes unused object from Heap.
* Executes memory defragmentation.
 
* Disadvantage : May freeze all other threads if called.

#### Memory defragmentation:
* While clearing a part of memory fragmentation of memory takes place.
* The process, of moving the objects in memory(grouping) to Create a bigger block of free memory for future use is called Memory defragmentation.

### Working of Garbage Collector.
##### Mark & sweep algorithm: 
* Marks the objects that can be removed (objects that does'nt have references)
 - Sweeps -
 * If there is no reference to the object it can be removed 
 
##### Ref Counting:
* Counts the references to objects.
* If the count reaches zero it is marked as removable.
* Disadvantage : objects with no longer in use but has Circular reference are considered active and not removed.
 
##### Tracing 
* Tracing the root object 
* From root object if the memory is not tracible the GC clears else it does'nt.
* Creates a graph of reachable objects.
* Static fields and Local Variables on the thread's Stack are Application roots.

### Generations of Garbage Collector:

Generation 0 : Most frequently checked
Generation 1
Generation 2 : Less frequently checked

Large object Heaps (size > 85,000) directly assigned to Generation 2.

## 7) What is the purpose of the Globalization and Localization features in .NET? 

* Globalization - Develop a application suitable for using all over the world.
* Example: A Multi_Lingual website.

* Localization - Develop a application suitable only for particular Region.

## 8) Explain the role of the Common Intermediate Language (CIL) and Just-In-Time (JIT) compilation in the .NET framework. 

* CIL -> Applications developed using C# or F# or other languages that supports .NET is first compiled into a intermediate stage called CIL.
* CIL is the same for all languages. this provides interoperability between the the codes.
* The just in time compiler compiles the CIL to Machine code . The process is called just in time compilation.
