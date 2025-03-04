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
            Console.WriteLine("\n\nProperties: ");
            foreach (var type in assemblyToLoad.GetTypes())
            {
                Console.WriteLine(type.Name);
                foreach (var property in type.GetProperties())
                {
                    Console.WriteLine(property.Name);
                }
            }
            Console.WriteLine("\n\nFields: ");
            foreach (var type in assemblyToLoad.GetTypes())
            {
                Console.WriteLine(type.FullName);
                foreach (var field in type.GetFields())
                {
                    Console.WriteLine(field.Name);
                }
            }
            Console.WriteLine("\n\nEvents: ");
            foreach (var type in assemblyToLoad.GetTypes())
            {
                Console.WriteLine(type.FullName);
                foreach (var eventToPrint in type.GetEvents())
                {
                    Console.WriteLine(eventToPrint.Name);
                }
            }
            Console.WriteLine("\n\nMethods: ");
            foreach (var type in assemblyToLoad.GetTypes())
            {
                Console.WriteLine(type.FullName);
                foreach (var method in type.GetMethods())
                {
                    Console.WriteLine(method.Name);
                }
            }
        }
    }
}
