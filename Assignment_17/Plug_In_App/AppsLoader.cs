using System.Reflection;

namespace Plug_In_App
{
    public class AppsLoader
    {
        string DirectoryPath = "C:\\Users\\Dhivakar.gopi\\Desktop\\PluginsDirectory";
        public void Run()
        {
            string[] dllFiles = Directory.GetFiles(DirectoryPath, "*.dll");
            int optionIndex = 1;
            foreach (string dllFile in dllFiles)
            {
                Console.WriteLine($"[{optionIndex++}] {dllFile}");
            }
            Console.Write("\nEnter Your Choice:");
            string? userChoice = Console.ReadLine();
            while (string.IsNullOrEmpty(userChoice) || !int.TryParse(userChoice, out _))
            {
                Console.Write("\nEnter valid Choice:");
                userChoice = Console.ReadLine();
            }
            int parsedChoice = int.Parse(userChoice);
            if (parsedChoice > dllFiles.Length || parsedChoice <= 0)
            {
                Console.WriteLine("Option Not Available");
                return;
            }
            Console.Clear();
            Assembly assembly = Assembly.LoadFrom(dllFiles[parsedChoice - 1]);
            Type? enumType = assembly.GetTypes().FirstOrDefault(t => t.IsEnum && t.Name.Contains("AppOptions"));
            Console.WriteLine($"{enumType.Name}");
            optionIndex = 1;
            foreach (var value in Enum.GetValues(enumType))
            {
                Console.WriteLine($"{optionIndex++} " + value);
            }
            Console.Write("\nEnter Your Choice : ");
            userChoice = Console.ReadLine();
            while (string.IsNullOrEmpty(userChoice) || !int.TryParse(userChoice, out _))
            {
                Console.Write("\nEnter valid Choice : ");
                userChoice = Console.ReadLine();
            }
            parsedChoice = int.Parse(userChoice);
            if (parsedChoice > Enum.GetValues(enumType).Length || parsedChoice <= 0)
            {
                Console.WriteLine("Option Not Available");
                return;
            }
            Console.WriteLine();

            Type? implementingType = assembly.GetTypes().FirstOrDefault(type => type.GetInterface("IManager", true) != null && !type.IsInterface && !type.IsAbstract);

            if (implementingType != null)
            {
                dynamic? instance = Activator.CreateInstance(implementingType);

                MethodInfo? methodInfo1 = instance.GetType().GetMethod("Description");
                MethodInfo? methodInfo2 = instance.GetType().GetMethod("Run");
                if (methodInfo1 != null)
                {
                    string description = methodInfo1.Invoke(instance, null);
                    Console.WriteLine($"\n{description}\n");
                }
                Console.Write("Enter the first value :");
                string? Value1 = Console.ReadLine();
                Console.Write("Enter the second value :");
                string? Value2 = Console.ReadLine();
                object[] parameters = new object[] { parsedChoice, Value1, Value2 };
                if (methodInfo2 != null)
                {
                    string? result = (string?)methodInfo2.Invoke(instance, parameters);
                    Console.WriteLine(result);
                }
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
