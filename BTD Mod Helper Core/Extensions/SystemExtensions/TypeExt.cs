using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BTD_Mod_Helper.Extensions
{
    public static class TypeExt
    {
        /// <summary>
        /// (Cross-Game compatible) Get all methods with the specified method name
        /// </summary>
        /// <param name="type"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        public static MethodInfo[] GetMethods(this Type type, string methodName)
        {
            return type.GetMethods().FindAll(method => method.Name == methodName);
        }
    }
}
