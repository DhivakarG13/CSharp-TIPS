using System.Diagnostics;
using System.Reflection;
using System.Text;
using AssemblyMetaDataFetcher;
using ClassProvider;
using Constants;
using DynamicMethodInvoker;
using DynamicObjectInspector;
using DynamicTypeBuilder;
using MainApplication.Helpers;
using Plug_In_App;
using SerializeAPI;

namespace MainApplication.Controllers
{
    public class Controller
    {
        AssemblyInfoLoader assemblyInfoLoader = new AssemblyInfoLoader();
        Student student = new Student("Jack", 10, 8.1);
        TypeHandler typeHandler = new TypeHandler();
        AppsLoader appsLoader = new AppsLoader();
        ObjectPropertyHandler objectPropertyEditor = new ObjectPropertyHandler();
        MethodHandler methodHandler = new MethodHandler();

        public void RunMainApplication(MainMenu userChoice)
        {
            Console.Clear();

            switch (userChoice)
            {
                case MainMenu.PrintAssemblyInfo:
                    PrintAssemblyInfo(assemblyInfoLoader);
                    break;

                case MainMenu.ManipulateObject:
                    objectPropertyEditor.ManipulateObject(student);
                    break;

                case MainMenu.InvokeMethod:
                    string methodName = UserInteraction.GetStringInput("Method Name");
                    methodHandler.InvokeMethod(student, methodName);
                    student.PrintDetails();
                    break;

                case MainMenu.CreateAType:
                    typeHandler.TypeBuilder();
                    break;

                case MainMenu.OpenPlugInApp:
                    appsLoader.Run();
                    break;

                case MainMenu.SerializeAObject:
                    SerializeAObject(student);
                    break;
            }

            Console.WriteLine("\n\nPress any Key to close.");
            Console.ReadKey();
            Console.Clear();
        }

        public static void PrintAssemblyInfo(AssemblyInfoLoader assemblyInfoLoader)
        {
            string? path = UserInteraction.GetStringInput("path of the Assembly file");
            Assembly? assembly = UserInteraction.LoadAssembly(path);
            if (assembly != null)
            {
                assemblyInfoLoader.PrintAssemblyData(assembly);
            }
            else
            {
                Console.WriteLine("Assembly not found");
            }
        }

        public static void SerializeAObject(Student student)
        {
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine();
            stopwatch.Start();
            Console.WriteLine(Encoding.UTF8.GetString(SerializerUtility.SerializeToBytes(student)));
            stopwatch.Stop();
            Console.WriteLine($"\nTime taken when just reflection is used:{stopwatch.ElapsedMilliseconds}");
            stopwatch.Reset();
            Console.WriteLine();
            Func<object, string> serializeObject = SerializerUtility.CreateDynamicSerializer(student.GetType());
            stopwatch.Start();
            string serializedData = serializeObject(student);
            stopwatch.Stop();
            Console.WriteLine(serializedData);
            Console.WriteLine($"Time taken when Emit is used:{stopwatch.ElapsedMilliseconds}");
        }
    }
}
