using System.Reflection;

namespace MainApplication.Helpers
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
            int userChoice;
            Console.Write("Enter your Choice: ");

            while (!int.TryParse(Console.ReadLine(), out userChoice))
            {
                Console.Write("Try Again -> ");
            }

            return userChoice;
        }

        public static Assembly? LoadAssembly(string folderPath)
        {
            string? dllName = UserInteraction.GetStringInput("dll Name");
            List<Assembly> assemblies = new List<Assembly>();
            assemblies = Directory.GetFiles(folderPath, "*.dll").Select(Assembly.LoadFrom).ToList();
            string assemblyName = UserInteraction.GetStringInput("Assembly Name"); 
            Assembly? assembly = assemblies.FirstOrDefault(assembly => assembly.GetName().Name == assemblyName);
            return assembly;
        }

        public static string GetStringInput(string typeOfData)
        {
            string? userInput;

            do
            {
            Console.Write($"Enter {typeOfData}: ");
                userInput = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(userInput));

            return userInput;
        }
    }
}
