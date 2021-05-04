using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BTD_Mod_Helper.Extensions
{
    public static class TypeExt
    {
        public static MethodInfo[] GetMethods(this Type type, string name)
        {
            return type.GetMethods().FindAll(method => method.Name == name);
        }
    }
}
