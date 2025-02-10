Console.WriteLine("Checking Priority of Constructor calling : \n");

Employee E1 = new Developer("Dhiva", 10000);
Console.WriteLine();
Employee E2 = new Developer("Hemanth", 20000);
Console.WriteLine();
Employee E3 = new Manager("Shri Ram", 30000);
Console.WriteLine();
Employee E4 = new Manager("Kaiser", 40000);
Console.WriteLine();
Console.ReadKey();

Console.WriteLine("Printing Details :");

E1.PrintDetails();
E2.PrintDetails();
E3.PrintDetails();
E4.PrintDetails();

Console.ReadKey();

Console.WriteLine("Checking Priority of Constructor calling : \n");
Console.WriteLine();
Console.WriteLine(new Manager("Prasanna", 10000)); // Experiment
Console.WriteLine();
Console.WriteLine();

Console.ReadKey();
Console.WriteLine("Checking Priority of Constructor calling : \n");
Employee E5 = new Manager("Pirai", 40000);
Console.WriteLine();
Manager E6 = new Manager("Sudhan", 40000);
Console.WriteLine();

Console.ReadKey();
