using System.Reflection;
using AssemblyMetadataFetcher;
using ClassProvider;
using Constants;
using DynamicMethodInvoker;
using DynamicObjectInspector;
using MainApp.Helpers;

namespace MainApp.Controllers
{
    public class Controller
    {
        AssemblyInfoLoader assemblyInfoLoader = new AssemblyMetadataFetcher.AssemblyInfoLoader();
        Student student = new Student("Jack", 10, 8.1);

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
                        ObjectPropertyEditor objectPropertyEditor = new ObjectPropertyEditor();
                        objectPropertyEditor.ManipulateObject(student);
                        student.PrintDetails();
                        break;
                    }
                case MainMenu.InvokeMethod:
                    {
                        MethodHandler methodHandler = new MethodHandler();
                        string? methodName = UserInteraction.GetMethodName();
                        methodHandler.InvokeMethod(student, methodName);
                        student.PrintDetails();
                        break;
                    }
                default:
                    Console.WriteLine("Feature not implemented");
                    break;
            }
        }
    }
}
