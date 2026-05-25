using System;
namespace BTD_Mod_Helper.Extensions;

internal static class CreateModelExtTypeExt
{
    extension(Type type)
    {
        internal string RealFullName
        {
            get
            {
                if (type.IsGenericType)
                {
                    var baseName = type.Name;
                    if (baseName.Contains('`')) baseName = baseName[..baseName.IndexOf('`')];
                    return $"{type.Namespace}.{baseName}<{type.GetGenericArguments().Join(t => t.RealFullName)}>";
                }

                if (type.IsNested)
                {
                    return $"{type.DeclaringType!.RealFullName}.{type.Name}";
                }

                if (type.IsArray)
                {
                    return $"{type.GetElementType()!.RealFullName}[{new string(',', type.GetArrayRank() - 1)}]";
                }

                if (Nullable.GetUnderlyingType(type) is Type underlying)
                    return $"{underlying.RealFullName}?";

                return type switch
                {
                    _ when type == typeof(int) => "int",
                    _ when type == typeof(string) => "string",
                    _ when type == typeof(bool) => "bool",
                    _ when type == typeof(void) => "void",
                    _ when type == typeof(object) => "object",
                    _ when type == typeof(byte) => "byte",
                    _ when type == typeof(sbyte) => "sbyte",
                    _ when type == typeof(short) => "short",
                    _ when type == typeof(ushort) => "ushort",
                    _ when type == typeof(long) => "long",
                    _ when type == typeof(ulong) => "ulong",
                    _ when type == typeof(char) => "char",
                    _ when type == typeof(float) => "float",
                    _ when type == typeof(double) => "double",
                    _ when type == typeof(decimal) => "decimal",
                    _ => type.FullName ?? type.Name
                };
            }
        }
    }
}