using System.Reflection;

namespace MainApp.Helpers
{
    public static class UserInteraction
    {
        public static void PrintDialog(Enum dialogToPrint)
        {
            int index = 1;
            foreach (var optionToPrint in dialogToPrint.GetType().GetEnumNames())
            {
                Console.WriteLine($"{index++}. {optionToPrint}");
            }
        }

        public static int GetUserChoice()
        {

            int userChoice = default;
            Console.Write("Enter your Choice: ");
            while (!int.TryParse(Console.ReadLine(), out userChoice))
            {
                Console.Write("Try Again -> ");
            }
            return userChoice;
        }

        public static string? GetUserFolder()
        {
            Console.Write("Enter the path of the assembly file: ");
            string? path = Console.ReadLine();
            return path;
        }

        public static Assembly? LoadAssembly(string folderPath)
        {
            string? dllName = Console.ReadLine();
            List<Assembly> assemblies = new List<Assembly>();
            assemblies = Directory.GetFiles(folderPath, "*.dll").Select(Assembly.LoadFrom).ToList();
            Console.Write("Enter your Assembly Name:");
            string assemblyName = Console.ReadLine();
            Assembly? assembly = assemblies.FirstOrDefault(assembly => assembly.GetName().Name == assemblyName);
            return assembly;
        }

        public static string? GetMethodName()
        {
            Console.Write("Enter the name of method in Student class: ");
            string? methodName = Console.ReadLine();
            return methodName;
        }

        public static string GetStringInput(string typeOfData)
        {
            string? userInput = string.Empty;
            Console.Write($"Enter {typeOfData}: ");
            while (string.IsNullOrEmpty(userInput))
            {
                userInput = Console.ReadLine();
            }
            return userInput;
        }
    }
}
