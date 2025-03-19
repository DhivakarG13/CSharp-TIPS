# CSharp-TIPS
 
## 1) Explain what the .Net platform is its primary Purpose?
### Net is a Frame work
* Framework provides standard way to build and deploy applications.
* It includes support programs, compilers, code Libraries and APIs
* The framework decides the program flow, memory management & etc.
 
### Dot Net
* Dot Net is a Frame work which helps a user to build application using C# / F# /Python
* These Language has their own compiler. which converts the code to CIL (common Intermediate Language)
 
### FCL - FrameWork Class Library 
* Includes: WPF, ASP.NET, Windows Forms, WF (Work flow foundation), LINQ, WCF, data access, data base
connectivity & network communication.
 
### CLR - Common Language RunTime
* provides services like memory management, exception handling, Garbage collection, Thread management, Type Safety.
* Net Framework provide language inter_operability
 code written in different languages is converted to CIL and all the codes are inter_operable now.
![image](https://github.com/user-attachments/assets/7f48fcfd-e3fd-444b-8ff9-578a94cb043f)


## 2) What are the key components of Net platform?

#### CLI -> Common Language Infrastructure
* Meta data :
	* Has information about all the classes and the class members defined in the assembly.
* Common Language Specification
	* CLS is a set of specifications that must be met by every language to be considered as .NET compliant.
* Common type system (CTS)
	* Provides common data Types to all data across Languages.
* Virtual Execution System (VES)
	* VES loads and runs the programs that are compatible with the CLI using meta data.

#### CLR -> Common Language Runtime
* CLR uses Just-In-Time (JIT) compiler to convert the IL code into machine-specific code while the program runs.
* CLR handles automatic memory management through Garbage Collection, preventing memory leaks.
* Provides Type Safety to code.
* Defines common rules so that code written in different languages can inter_operate.

#### JIT compiler -> converts CIL to machine code
##### Types:
* Standard JIT: Compiles methods as they are called during execution.
* Pre-JIT: Compiles the entire code at the time of application deployment.
* Econo-JIT: Compiles code in a way that minimizes memory usage, suitable for resource-constrained environments2.

##### Tiered Compilation:
 Compiling code in multiple stages or "tiers" to optimize both the speed of initial execution and the overall performance of the application.
* Quick JIT: Generates code quickly or loads pre-compiled code.
* Optimizing JIT: Generates optimized code in the background, improving performance over time3.


#### FCL -> Framework Class Library
* Contains predefined classes
	* includes various collection classes such as list, stack, queue, dictionary, etc.
	* include the classes for using the file system, the classes to handle the network features, 
	the classes to handle I/O for console applications
* Contains namespaces like System.Net,System.Linq etc.
* Includes: WPF, ASP.NET, Windows Forms, WF (Windows Forms), LINQ, WCF,
data access, data base connectivity & network communication.


#### ASP.NET Core:
* ASP.NET core is a part of the .NET framework, providing a robust platform for building dynamic web applications and services.
* It supports various development models like Web Forms, MVC (Model-View-Controller), and Razor Pages, giving developers flexibility in how they build their applications.
* we can develop applications that run on Windows, macOS, and Linux.

#### WF
* Windows Forms (WF) is a graphical user interface (GUI) framework within the .NET framework for building desktop applications. It provides a set of managed libraries for creating interactive user interfaces.
* It is particularly useful for applications that need to run on Windows operating systems and require direct interaction with the user.
* With a drag-and-drop designer in Visual Studio, developers can quickly create and design forms, reducing the amount of manual coding.
* Rich Controls: It offers a wide range of built-in controls (like buttons, text boxes, and grids) that can be easily customized.
* Integrates with other .NET components and libraries, allowing for flexible application development.
* 
#### WPF
* WPF is a vector graphics based UI presentation layer, being vector based, it allows the presentation layer to smoothly scale UI elements to any size without distortion.
* WPF is used to create applications with advanced graphics, animations, and media integration. It is particularly suitable for applications that require a modern, flexible, and visually appealing user interface.
* Data Binding: It offers powerful data binding capabilities, making it easier to connect UI elements to data sources and manage data flow within the application.
* WPF uses XAML (Extensible Application Markup Language) to define UI elements declaratively, making it easier to separate UI design from application logic.

### Services:
- Memory management
- Type safety
- Exception handling
- Garbage collection
- Thread management

## 3) Differentiate between the Common Language Runtime (CLR) and the Common Type System (CTS) in .NET. 
Both CLR and CTS work on interoperability of the system
 
#### Common Language Runtime
* It does multiple operations with Compiled Intermediate Language.
  * Memory management: The CLR handles memory allocation and deallocation for .NET applications,
   including garbage collection.
  *  Exception Handling: It provides a structured way to handle runtime errors through exception handling mechanisms.
  * Just-In-Time (JIT) Compilation: The CLR compiles Intermediate Language (IL) code into native machine code just before execution
  * Thread Management: It provides support for multi threading, allows applications to perform multiple operations simultaneously.


#### Common Type System
* Provides common data Types to all data across Languages.
* The CTS defines how types are declared, used, and managed in the .NET framework.
* Provides type safety.
* Defines rules regarding any operations with types.

## 4) What is the role of the Global Assembly Cache (GAC) in .NET? 

### Global Assembly Cache
* Provided by CLR
* Used to store assemblies.
* Act as central place for registering Assemblies.
* Assemblies are installed into GAC
* Improves Performance: By storing shared assemblies in a central location,
the GAC helps improve performance and reduces the need for multiple copies of the same assembly.

#### Assembly Lookup Process
When an application needs an assembly, the CLR follows a specific lookup process:

1) Check Application Directory: The CLR first looks for the assembly in the application's directory.
2) Check GAC: If the assembly is not found in the application directory, the CLR then checks the GAC for the required assembly.

This process ensures that the most appropriate and up-to-date version of the assembly is used, enhancing application stability and performance.

## 5) Difference between value type & Reference type
Common Type System decides which data should be a value type or reference type.

### Stack:
* One per thread.
* One stack is Reserved for each thread.
* Thread stores the temporary data, instructions, to execute.
* Small (1-4 MB).
* No gaps between data.
* Automatic removal of data.
* Fast

### Heap:
* One Heap is allocated per application.
* Large
* Initially a space is allocated & can be Resized later.
* Can be de_fragmented, Garbage collector is used.
* Slow

### Value types:
* Derived from System.ValueType (Derived from object).
* Eg : Int, decimal, date Time, bool, structs.
* Value type variables has the actual data.
* Stored in stack memory.

### Reference Types:
* Derived from system.Objet.
* Eg : Array, object.
* Reference type variable has memory location of the data.
* Data is stored in Heap memory.

## 6) Describe the concept of Garbage collection.

* Heap's memory management mechanism is called Garbage collection.
* system-level service provided Common Language Runtime.
* The GC works behind the scenes to manage memory allocation and deallocation for .NET applications.
 
### Triggers of GC
1) When OS informs CLR only little memory left.
2) When amount of memory occupied by objects on heap surpasses a given threshold.
3) When a GC.collect() method is called.
 
* GC Runs on a separate thread.
* Removes unused object from Heap.
* Executes memory de_fragmentation.
 
* Disadvantage : May freeze all other threads if called.

#### Memory de_fragmentation:
* While clearing a part of memory fragmentation of memory takes place.
* The process, of moving the objects in memory(grouping) to Create a bigger block of free memory 
for future use is called Memory defragmentation.

### Working of Garbage Collector.
##### Mark & sweep algorithm: 
* Marks the objects that can be removed (objects that doesn't have references)
 - Sweeps -
 * If there is no reference to the object it can be removed 
 
##### Ref Counting:
* Counts the references to objects.
* If the count reaches zero it is marked as removable.
* Disadvantage : objects with no longer in use but has Circular reference are considered active and not removed.
 
##### Tracing 
* Tracing the root object 
* From root object if the memory is not traceable the GC clears else it doesn't.
* Creates a graph of reachable objects.
* Static fields and Local Variables on the thread's Stack are Application roots.

### Generations of Garbage Collector:

Generation 0 : Most frequently checked contains short-lived objects
Generation 1 : Acts as platform between short-lived objects and long-lived objects
Generation 2 : Contains short-lived objects and Less frequently checked

Large object Heaps (size > 85,000) directly assigned to Generation 2.

## 7) What is the purpose of the Globalization and Localization features in .NET? 

* Globalization - Develop a application suitable for using all over the world.
* Example: A Multi_Lingual website.
* The core functionality of the application does not vary across the regions but the user can
use the app in his own language and the dates and currencies can be set to his regional values.

* Localization - Sub part of Globalization as it supports world wide usage.
* there will be changes in core functionality of the app according to the region.

## 8) Explain the role of the Common Intermediate Language (CIL) and Just-In-Time (JIT) compilation in the .NET framework. 

### CIL -> 
Applications developed using C# or F# or other languages that supports .NET is first compiled into a intermediate stage called CIL.
* CIL is the same for all languages. this provides interoperability between the codes.
* It can run on any environment that supports the .NET runtime.
* Along with CIL , metadata is generated, which contains information such as type definitions, signatures, and runtime information.
* The CIL is full of OpCodes (operation codes).

### JIT ->
* The just in time compiler compiles the CIL to Machine code .
* The process is called just in time compilation.

##### Types:
* Standard JIT: Compiles methods as they are called during execution.
* Pre-JIT: Compiles the entire code at the time of application deployment.
* Econo-JIT: Compiles code in a way that minimizes memory usage, suitable for resource-constrained environments2.

##### Tiered Compilation:
 Compiling code in multiple stages or "tiers" to optimize both the speed of initial execution and the overall performance of the application.
* Quick JIT: Generates code quickly or loads pre-compiled code.
* Optimizing JIT: Generates optimized code in the background, improving performance over time3.
