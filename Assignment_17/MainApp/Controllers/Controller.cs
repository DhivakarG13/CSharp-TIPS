using System.Diagnostics;
using System.Reflection;
using System.Text;
using AssemblyMetaDataFetcher;
using ClassProvider;
using Constants;
using DynamicMethodInvoker;
using DynamicObjectInspector;
using DynamicTypeBuilder;
using MainApp.Helpers;
using Plug_In_App;
using SerializeAPI;

namespace MainApp.Controllers
{
    public class Controller
    {
        AssemblyInfoLoader assemblyInfoLoader = new AssemblyMetaDataFetcher.AssemblyInfoLoader();
        Student student = new Student("Jack", 10, 8.1);
        TypeHandler typeHandler = new TypeHandler();
        AppsLoader appsLoader = new AppsLoader();
        ObjectPropertyHandler objectPropertyEditor = new ObjectPropertyHandler();
        MethodHandler methodHandler = new MethodHandler();

        public void RunMainApp(MainMenu userChoice)
        {
            Console.Clear();
            switch (userChoice)
            {
                case MainMenu.PrintAssemblyInfo:
                    string? path = UserInteraction.GetUserFolder();
                    Assembly? assembly = UserInteraction.LoadAssembly(path);
                    if (assembly != null)
                    {
                        assemblyInfoLoader.PrintAssemblyInfo(assembly);
                    }
                    else
                    {
                        Console.WriteLine("Assembly not found");
                    }
                    break;
                case MainMenu.ManipulateObject:
                    {
                        objectPropertyEditor.ManipulateObject(student);
                        student.PrintDetails();
                        break;
                    }
                case MainMenu.InvokeMethod:
                    {
                        string? methodName = UserInteraction.GetMethodName();
                        methodHandler.InvokeMethod(student, methodName);
                        student.PrintDetails();
                        break;
                    }
                case MainMenu.Create_A_Type:
                    {
                        typeHandler.TypeBuilder();
                        break;
                    }
                case MainMenu.Open_Plug_In_App:
                    {
                        appsLoader.Run();
                        break;
                    }
                case MainMenu.Serialize_A_Object:
                    {
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();
                        Console.WriteLine();
                       // List<Student> students = new List<Student> { student, student, student };
                        Console.WriteLine(Encoding.UTF8.GetString(SerializerUtility.SerializeToBytes(student)));
                        stopwatch.Stop();
                        Console.WriteLine($"Time taken when just reflection is used:{stopwatch.ElapsedMilliseconds}");
                        stopwatch.Reset();
                        stopwatch.Start();
                        Console.WriteLine();
                        Func<object, string> serializeObject = SerializerUtility.CreateDynamicSerializer(student.GetType());
                        string serializedData = serializeObject(student);
                        Console.WriteLine(serializedData);
                        stopwatch.Stop();
                        Console.WriteLine($"Time taken when Emit is used:{stopwatch.ElapsedMilliseconds}");
                        break;
                    }
            }
            Console.WriteLine("\n\nPress any Key to close.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
