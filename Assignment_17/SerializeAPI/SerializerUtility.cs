using System.Collections;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace SerializeAPI
{
    public delegate byte[] SerializeToBytesDelegate(object obj);
    public class SerializerUtility
    {
        public static byte[] SerializeToBytes(object obj)
        {
            Type type = obj.GetType();

            if (obj == null)
            {
                return Encoding.UTF8.GetBytes("null");
            }

            if (type.IsPrimitive || obj is string)
            {
                return Encoding.UTF8.GetBytes(obj.ToString());
            }

            if (obj is IEnumerable enumerable)
            {
                StringBuilder listSb = new StringBuilder();
                foreach (var item in enumerable)
                {
                    listSb.Append(Encoding.UTF8.GetString(SerializeToBytes(item)) + "\n");
                }
                if (listSb.Length > 0)
                    listSb.Length--;
                return Encoding.UTF8.GetBytes(listSb.ToString());
            }

            StringBuilder sb = new StringBuilder();
            foreach (PropertyInfo prop in type.GetProperties())
            {
                object value = prop.GetValue(obj) ?? "null";
                sb.Append(value.ToString() + ",");
            }

            if (sb.Length > 0)
            {
                sb.Length--;
            }
            return Encoding.UTF8.GetBytes(sb.ToString());
        }

        public static Func<object, string> CreateDynamicSerializer(Type type)
        {
            DynamicMethod method = new DynamicMethod("Serialize", typeof(string), new[] { typeof(object) }, type);
            ILGenerator il = method.GetILGenerator();

            LocalBuilder localString = il.DeclareLocal(typeof(StringBuilder));
            il.Emit(OpCodes.Newobj, typeof(StringBuilder).GetConstructor(Type.EmptyTypes));
            il.Emit(OpCodes.Stloc, localString);

            il.Emit(OpCodes.Ldloc, localString);
            il.Emit(OpCodes.Ldstr, $"{type.Name} {{\n");
            il.Emit(OpCodes.Call, typeof(StringBuilder).GetMethod("Append", new[] { typeof(string) }));
            il.Emit(OpCodes.Pop);

            foreach (PropertyInfo property in type.GetProperties())
            {
                il.Emit(OpCodes.Ldloc, localString);
                il.Emit(OpCodes.Ldstr, $"{property.Name}: ");
                il.Emit(OpCodes.Call, typeof(StringBuilder).GetMethod("Append", new[] { typeof(string) }));
                il.Emit(OpCodes.Pop);

                il.Emit(OpCodes.Ldloc, localString);
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Callvirt, property.GetGetMethod());


                if (property.PropertyType.IsValueType)
                {
                    il.Emit(OpCodes.Box, property.PropertyType);
                    il.Emit(OpCodes.Call, typeof(StringBuilder).GetMethod("Append", new[] { typeof(object) }));
                }
                else if (property.PropertyType == typeof(string))
                {
                    il.Emit(OpCodes.Call, typeof(StringBuilder).GetMethod("Append", new[] { typeof(object) }));
                }
                else
                {
                    var nestedSerializer = CreateDynamicSerializer(property.PropertyType);
                    il.Emit(OpCodes.Call, nestedSerializer.Method);
                    il.Emit(OpCodes.Call, typeof(StringBuilder).GetMethod("Append", new[] { typeof(string) }));
                }
                il.Emit(OpCodes.Pop);

                il.Emit(OpCodes.Ldloc, localString);
                il.Emit(OpCodes.Ldstr, "\n");
                il.Emit(OpCodes.Call, typeof(StringBuilder).GetMethod("Append", new[] { typeof(string) }));
                il.Emit(OpCodes.Pop);
            }

            il.Emit(OpCodes.Ldloc, localString);
            il.Emit(OpCodes.Ldstr, "}");
            il.Emit(OpCodes.Call, typeof(StringBuilder).GetMethod("Append", new[] { typeof(string) }));
            il.Emit(OpCodes.Pop);

            il.Emit(OpCodes.Ldloc, localString);
            il.Emit(OpCodes.Call, typeof(StringBuilder).GetMethod("ToString", Type.EmptyTypes));
            il.Emit(OpCodes.Ret);

            return (Func<object, string>)method.CreateDelegate(typeof(Func<object, string>));
        }
    }
}






