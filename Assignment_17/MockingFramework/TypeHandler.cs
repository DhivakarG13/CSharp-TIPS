using System.Reflection;
using System.Reflection.Emit;

namespace MockingFramework
{
    public interface IMaths
    {
        public int Add(int x, int y);
    }

    public class TypeHandler
    {
        public Type CreateType()
        {
            AssemblyName assemblyName = new AssemblyName("Dynamic Assembly");
            AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyName.Name);
            TypeBuilder typeBuilder = moduleBuilder.DefineType("Calculator", TypeAttributes.Public);
            typeBuilder.AddInterfaceImplementation(typeof(IMaths));
            MethodInfo[] methodsInInterface = typeof(IMaths).GetMethods();

            foreach (MethodInfo method in methodsInInterface)
            {
                Type[] parameterList = method.GetParameters().Select(p => p.ParameterType).ToArray();
                MethodBuilder methodBuilder = typeBuilder.DefineMethod(method.Name, MethodAttributes.Public | MethodAttributes.Virtual, method.ReturnType, parameterList);
                ILGenerator methodBuilderIL = methodBuilder.GetILGenerator();
                methodBuilderIL.Emit(OpCodes.Ldarg_0);
                Type returnType = method.ReturnType;
                if (returnType.IsValueType)
                {
                    methodBuilderIL.Emit(OpCodes.Ldc_I4_0);
                }
                else
                {
                    methodBuilderIL.Emit(OpCodes.Ldnull);
                }

                methodBuilderIL.Emit(OpCodes.Ret);
            }

            Type newType = typeBuilder.CreateType();
            return newType;
        }
    }
}