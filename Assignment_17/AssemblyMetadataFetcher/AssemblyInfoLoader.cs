using System.Reflection;

namespace AssemblyMetaDataFetcher
{
    public class AssemblyInfoLoader
    {
        public void PrintAssemblyInfo(Assembly assemblyToLoad)
        {
            Console.WriteLine("Types: ");
            foreach (Type type in assemblyToLoad.GetTypes())
            {
                Console.WriteLine(type.FullName);
            }
            Console.WriteLine("\n\nProperties: ");
            foreach (Type type in assemblyToLoad.GetTypes())
            {
                Console.WriteLine(type.Name);
                foreach (PropertyInfo property in type.GetProperties())
                {
                    Console.WriteLine(property.Name);
                }
            }
            Console.WriteLine("\n\nFields: ");
            foreach (Type type in assemblyToLoad.GetTypes())
            {
                Console.WriteLine(type.FullName);
                foreach (FieldInfo field in type.GetFields())
                {
                    Console.WriteLine(field.Name);
                }
            }
            Console.WriteLine("\n\nEvents: ");
            foreach (Type type in assemblyToLoad.GetTypes())
            {
                Console.WriteLine(type.FullName);
                foreach (EventInfo eventToPrint in type.GetEvents())
                {
                    Console.WriteLine(eventToPrint.Name);
                }
            }
            Console.WriteLine("\n\nMethods: ");
            foreach (Type type in assemblyToLoad.GetTypes())
            {
                Console.WriteLine(type.FullName);
                foreach (MethodInfo method in type.GetMethods())
                {
                    Console.WriteLine(method.Name);
                }
            }
        }
    }
}
