using System.Reflection;
using System.Reflection.Emit;

namespace DynamicTypeBuilder
{
    public class TypeHandler
    {
        public void TypeBuilder()
        {
            AssemblyName aName = new AssemblyName("DynamicAssembly");
            AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(aName, AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(aName.Name ?? "DynamicAssembly");
            TypeBuilder typeBuilder = moduleBuilder.DefineType("SimpleCalculator", TypeAttributes.Public);
            FieldBuilder fieldBuilderNumber = typeBuilder.DefineField("_number", typeof(int), FieldAttributes.Private);

            Type[] parameterTypes = { typeof(int) };
            ConstructorBuilder constructor1 = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, parameterTypes);
            ILGenerator constructor1IL = constructor1.GetILGenerator();
            constructor1IL.Emit(OpCodes.Ldarg_0);
            ConstructorInfo? constructorInfo = typeof(object).GetConstructor(Type.EmptyTypes);
            constructor1IL.Emit(OpCodes.Call, constructorInfo!);
            constructor1IL.Emit(OpCodes.Ldarg_0);
            constructor1IL.Emit(OpCodes.Ldarg_1);
            constructor1IL.Emit(OpCodes.Stfld, fieldBuilderNumber);
            constructor1IL.Emit(OpCodes.Ret);

            ConstructorBuilder constructor0 = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, Type.EmptyTypes);
            ILGenerator constructor0IL = constructor0.GetILGenerator();
            constructor0IL.Emit(OpCodes.Ldarg_0);
            constructor0IL.Emit(OpCodes.Ldc_I4_S, 0);
            constructor0IL.Emit(OpCodes.Call, constructor1);
            constructor0IL.Emit(OpCodes.Ret);

            PropertyBuilder propertyBuilderNumber = typeBuilder.DefineProperty("Number", PropertyAttributes.HasDefault, typeof(int), null);

            MethodAttributes getSetAttr = MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig;

            MethodBuilder mbNumberGetAccessor = typeBuilder.DefineMethod("get_Number", getSetAttr, typeof(int), Type.EmptyTypes);
            ILGenerator numberGetIL = mbNumberGetAccessor.GetILGenerator();
            numberGetIL.Emit(OpCodes.Ldarg_0);
            numberGetIL.Emit(OpCodes.Ldfld, fieldBuilderNumber);
            numberGetIL.Emit(OpCodes.Ret);

            MethodBuilder mbNumberSetAccessor = typeBuilder.DefineMethod("set_Number", getSetAttr, null, new Type[] { typeof(int) });
            ILGenerator numberSetIL = mbNumberSetAccessor.GetILGenerator();
            numberSetIL.Emit(OpCodes.Ldarg_0);
            numberSetIL.Emit(OpCodes.Ldarg_1);
            numberSetIL.Emit(OpCodes.Stfld, fieldBuilderNumber);
            numberSetIL.Emit(OpCodes.Ret);

            propertyBuilderNumber.SetGetMethod(mbNumberGetAccessor);
            propertyBuilderNumber.SetSetMethod(mbNumberSetAccessor);

            MethodBuilder addByMethodBuilder = typeBuilder.DefineMethod("AddBy", MethodAttributes.Public, typeof(int), new Type[] { typeof(int) });

            ILGenerator addByMethodBuilderIL = addByMethodBuilder.GetILGenerator();
            addByMethodBuilderIL.Emit(OpCodes.Ldarg_0);
            addByMethodBuilderIL.Emit(OpCodes.Ldfld, fieldBuilderNumber);
            addByMethodBuilderIL.Emit(OpCodes.Ldarg_1);
            addByMethodBuilderIL.Emit(OpCodes.Add);
            addByMethodBuilderIL.Emit(OpCodes.Ret);

            Type? newType = typeBuilder.CreateType();

            MethodInfo? methodInfo = newType?.GetMethod("AddBy");
            PropertyInfo? propertyInfo = newType?.GetProperty("Number");

            object? simpleCalculator = null;
            if (newType is not null)
                simpleCalculator = Activator.CreateInstance(newType);

            Console.WriteLine($"simpleCalculator.Number: {propertyInfo?.GetValue(simpleCalculator, null)}");
            propertyInfo?.SetValue(simpleCalculator, 100, null);
            Console.WriteLine($"simpleCalculator.Number: {propertyInfo?.GetValue(simpleCalculator, null)}");

            object[] arguments = { 22 };
            Console.WriteLine("simpleCalculator.AddBy(22): {0}", methodInfo?.Invoke(simpleCalculator, arguments));
        }
    }
}

