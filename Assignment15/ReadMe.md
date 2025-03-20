# Working with Files and Streams in C# [Assignment 15]

## Task 1: Implement a File Data Processor :

### Streams:
* Stream is a sequence of bytes that we can use to read from and write to a backing store.
* ![image](https://github.com/user-attachments/assets/c7756510-c17c-40ee-897d-a54692f0be51)
* Streams are used to read and write data to and from different sources like files, memory, network connections, etc.
* Streams are used to read and write data in a sequential manner.
* Stream is a abstract base class in C#. It is defined in the System.IO namespace.
---
### Backing Store
* A backing store is a storage medium that holds data until it is read or processed.
* A backing store can be a file, disk or memory, network connection, etc.
* Streams are used to read and write data to and from backing stores.
---
### Types of Streams:
* FileStream
* MemoryStream
* BufferedStream
* NetworkStream
* PipeStream
* CryptoStream

#### FileStream: 
* Used to read and write data to and from a file.
* Backing store -> File.
* It is derived from the Stream class.
* FileStream class provides synchronous and asynchronous methods to read and write data to and from a file too.
* FileStream class provides constructors to create and open a file in different modes like read, write, read/write, etc.

#### MemoryStream:
* Used to read and write data to and from memory.
* Backing store -> Memory.
* MemoryStream class is derived from the Stream class.
* MemoryStream class provides synchronous and asynchronous methods to read and write data to and from memory.
* MemoryStream class provides constructors to create and open a memory stream.
* Reads in the form of bytes.

#### BufferedStream:
* BufferedStream class is derived from the Stream class.
* Used to read and write data to and from a buffer.
* Backing store -> BufferedStream.
* ![image](https://github.com/user-attachments/assets/63572913-4efe-4c52-b720-1a3bc2c335bd)
* Can be used to improve the performance of reading and writing data to and from a stream.
* It wraps around another stream and stores data in a buffer.
* It uses an internal buffer to temporarily store data before writing it to or reading it from the underlying stream. 
* ##### Write:
    * When you write data to the BufferedStream,
    * It first writes the data to its internal buffer.
    * Once the buffer is full or when you explicitly flush the buffer,
    * The data is then written to the underlying stream.
* ##### Read: 
    * When you read data from the BufferedStream,
    * It first checks if the data is available in its internal buffer.
    * If not, it reads a larger chunk of data from the underlying stream into the buffer
    * And then serves the requested data from the buffer.

* NetworkStream: Used to read and write data to and from a network connection.
* PipeStream: Used to read and write data to and from a pipe.
---
### Task Description:

* A new 1 GB file is created using a method CreateOrWriteFile, which gets the file path and creates a 1 GB File.
* A file read operation is performed using ReadFileUsingFileStream method. Which gets the file path and reads using File Stream and Stream reader.
* A file read operation is performed using ReadFileUsingBufferedStream method. Which gets the file path and reads using File Stream, which is wrapped by Buffered Stream and Stream reader.
* ProcessFileData is a method which gets the path of old and new file, then it reads the data using Stream reader, then converts it to Upper case letters and appends it to memory stream.
* Then the data in memory stream is written to the new File.
---
### Observations :
* The method which uses buffered stream consumes less time while reading the file.
---
### Readers and Writers
* These are Types used for reading encoded characters from streams and writing them to streams.
* The reader and writer types handle the conversion of the encoded characters to and from bytes so the stream can complete the operation.
* commonly used reader and writer classes:
    * TextReader and TextWriter – serve as the abstract base classes for other readers and writers that read and write characters and strings, but not binary data.
    * BinaryReader and BinaryWriter – for reading and writing primitive data types as binary values.
    * StreamReader and StreamWriter – for reading and writing characters by using an encoding value to convert the characters to and from bytes.
    * StringReader and StringWriter – for reading and writing characters to and from strings.
---
## Task 2: Implement a File Data Processor with Asynchronous Methods

#### Asynchronous Methods Example:
* CopyToAsync()
* FlushAsync()
* ReadAsync()
* WriteAsync()
* ReadLineAsync()
* ReadToEndAsync()
* And many more ......
---

* Asynchronous Methods helps us to Perform resource intensive I/O without blocking the main thread.
* Async -> Modifier which is used to mark a method that contains an asynchronous operation.
* Await -> Operator, applied to result of asynchronous method.
* Reference : https://learn.microsoft.com/en-us/dotnet/standard/io/

### Task Description:
* The Task1 code is modified to run Asynchronously.
* The Asynchronous version of code runs faster than the synchronous version.

## Task 3: Investigate Issues in Basic File usage.

#### Causes of inefficiency in given code:
* The given data is a string which should be written to the file.
* In the give code they used memory stream . The string was converted to byte array and written to memory stream.
* Then the data in memory stream is written to the File Stream.
* While reading the file the a byte array of large size to read a small data is used.
* Then it is converted to string and printed.

### Modification done to improve the efficiency.
* The Code uses single FileStream to access the File.
* Within the file stream using , a Stream Writer is used first to write all the data to the stream.
* The stream writer s flushed to make sure all data is written to the  Stream.
* Another File Stream is opened to read data.
* A stream reader is used and stream reader.ReadLine() is called till all the data is printed to the console.


## Task 4: Analyze and Resolve Performance Issues with Logging System for Multiple Users.

### Subtask 1: Identifying Issues:
* When multiple users try to Log in the same File asynchronously error will be thrown, because already the file being accessed and it is not closed properly.
* We can use File Stream and Stream writer instead of memory stream.
* The data is not flushed before closing the stream.

### Subtask 2: Improving File Writing:
* File Stream and Stream reader is used instead of Memory Stream.

### Subtask 3: Thread-Safe Logging:
* Lock is used to make the code thread safe and now asynchrony can be performed.
* Asynchrony is used therefore the main page does not freeze.

### Subtask 4: Independent Error Files:
* A new file is created when a new user signs up.
* The logging is done in respective file of the user .
* This makes the code even more efficient.

### Subtask 5: Performance Testing:
* Load Testing is done By creating a file and logging it Four times. and logging 4 different users in their respective files.
* A time difference is observed.
* Logging into respective files is quicker than logging error of multiple user into a same file.

---
