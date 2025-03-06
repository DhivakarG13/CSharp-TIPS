using System.Reflection;
using DynamicObjectInspector.Helpers;

namespace DynamicMethodInvoker
{
    public class MethodHandler
    {
        public void InvokeMethod(object objectToInvoke, string methodName)
        {
            MethodInfo? method = objectToInvoke.GetType().GetMethod(methodName);
            if (method == null)
            {
                return;
            }
            ParameterInfo[] parameters = method.GetParameters();
            object[] newParameters = new object[method.GetParameters().Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                Console.WriteLine($"{parameters[i]}");
                newParameters[i] = UserInteraction.GetNewValue(parameters[i].GetType());
            }
            method.Invoke(objectToInvoke, newParameters);
        }
    }
}
