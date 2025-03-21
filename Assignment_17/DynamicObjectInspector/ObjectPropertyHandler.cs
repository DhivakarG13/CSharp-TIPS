using System.Reflection;
using DynamicObjectInspector.Helpers;

namespace DynamicObjectInspector
{
    public class ObjectPropertyHandler
    {
        public void ManipulateObject(object objectToManipulate)
        {
            Type objectType = objectToManipulate.GetType();
            List<PropertyInfo> properties = objectType.GetProperties().ToList();

            foreach (PropertyInfo property in properties)
            {
                object? propertyValue = property.GetValue(objectToManipulate);
                Console.WriteLine($"Property name: {property}");
                Console.WriteLine($"Property value: {propertyValue}");
                dynamic newValue = UserInteraction.GetNewValue(property.PropertyType);
                property.SetValue(objectToManipulate, newValue);

                MethodInfo? printMethod = objectToManipulate.GetType().GetMethod("PrintDetails");
                if (printMethod != null)
                {
                    try
                    {
                        printMethod.Invoke(objectToManipulate, new Type[] { });
                    } 
                    catch (Exception ex) 
                    {
                        Console.WriteLine($"{ex} occurred.");
                    }
                }
            }
        }
    }
}