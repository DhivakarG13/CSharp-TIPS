using System.Reflection;

namespace AssemblyMetaDataFetcher
{
    public class AssemblyInfoLoader
    {
        public void PrintAssemblyData(Assembly assemblyToLoad)
        {
            Console.WriteLine("Types: ");
            foreach (Type type in assemblyToLoad.GetTypes())
            {
                Console.WriteLine(type.FullName);

                Console.WriteLine("\n\nProperties: ");
                foreach (PropertyInfo property in type.GetProperties())
                {
                    Console.WriteLine(property.Name);
                }

                Console.WriteLine("\n\nFields: ");
                foreach (FieldInfo field in type.GetFields())
                {
                    Console.WriteLine(field.Name);
                }

                Console.WriteLine("\n\nEvents: ");
                foreach (EventInfo eventToPrint in type.GetEvents())
                {
                    Console.WriteLine(eventToPrint.Name);
                }

                Console.WriteLine("\n\nMethods: ");
                foreach (MethodInfo method in type.GetMethods())
                {
                    Console.WriteLine(method.Name);
                }

                Console.WriteLine("--------------------------------\n\n");
            }
        }
    }
}