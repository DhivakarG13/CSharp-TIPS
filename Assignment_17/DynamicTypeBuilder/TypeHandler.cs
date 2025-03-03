using System.Reflection;
using System.Reflection.Emit;

namespace DynamicTypeBuilder
{
    public class TypeHandler
    {
        public void TypeBuilder()
        {


            AssemblyName newAssemblyName = new AssemblyName("NewDynamicAssembly");
            AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(newAssemblyName, AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("NewDynamicModule");
            TypeBuilder typeBuilder = moduleBuilder.DefineType("DynamicType", TypeAttributes.Public);

            PropertyBuilder propertyBuilderNumber = typeBuilder.DefineProperty("Number", PropertyAttributes.HasDefault, typeof(int), null);

            MethodBuilder methodBuilder = typeBuilder.DefineMethod("Multiply", MethodAttributes.Public, typeof(int), new Type[] { typeof(int), typeof(string) });

            ILGenerator methIL = methodBuilder.GetILGenerator();

            Type? t = typeBuilder.CreateType();

            MethodInfo? mi = t?.GetMethod("Multiply");
            PropertyInfo? pi1 = t?.GetProperty("Number");

            object? o1 = null;
            if (t is not null)
                o1 = Activator.CreateInstance(t);

            Console.WriteLine("o1.Number: {0}", pi1?.GetValue(o1, null));
            pi1?.SetValue(o1, 127, null);
            Console.WriteLine("o1.Number: {0}", pi1?.GetValue(o1, null));

            object[] arguments = { 22 };
            Console.WriteLine("o1.MyMethod(22): {0}",
                mi?.Invoke(o1, arguments));

        }
    }
}
