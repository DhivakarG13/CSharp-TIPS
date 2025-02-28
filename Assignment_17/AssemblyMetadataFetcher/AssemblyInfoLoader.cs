using System.Reflection;

namespace AssemblyMetadataFetcher
{
    public class AssemblyInfoLoader
    {
        public void PrintAssemblyInfo(Assembly assemblyToLoad)
        {
            Console.WriteLine("Types: ");
            foreach (var type in assemblyToLoad.GetTypes())
            {
                Console.WriteLine(type.FullName);
            }
            Console.WriteLine("Modules: ");
            foreach (var module in assemblyToLoad.GetModules())
            {
                Console.WriteLine(module.FullyQualifiedName);
            }
            Console.WriteLine("Properties: ");
            foreach (var type in assemblyToLoad.GetTypes())
            {
                Console.WriteLine(type.Name);
                foreach (var property in type.GetProperties())
                {
                    Console.WriteLine(property.Name);
                }
            }
            Console.WriteLine("Fields: ");
            foreach (var type in assemblyToLoad.GetTypes())
            {
                Console.WriteLine(type.FullName);
                foreach (var field in type.GetFields())
                {
                    Console.WriteLine(field.Name);
                }
            }
            Console.WriteLine("Methods: ");
            foreach (var type in assemblyToLoad.GetTypes())
            {
                Console.WriteLine(type.FullName);
                foreach (var method in type.GetMethods())
                {
                    Console.WriteLine(method.Name);
                }
            }
            Console.WriteLine("Events: ");
            foreach (var type in assemblyToLoad.GetTypes())
            {
                Console.WriteLine(type.FullName);
                foreach (var eventToPrint in type.GetEvents())
                {
                    Console.WriteLine(eventToPrint.Name);
                }
            }
        }
    }
}
