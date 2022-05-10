using Il2CppSystem;
using Object = Il2CppSystem.Object;

namespace BTD_Mod_Helper.Extensions
{
    public static class Il2CppSystemObjectExt
    {
        /// <summary>
        /// (Cross-Game compatible) Is this Reference equal to another Object's Reference?
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="to">Object to compare to</param>
        /// <returns></returns>
        public static bool ReferenceEquals(this Object instance, Object to)
        {
            return ReferenceEquals(instance, (object)to);
        }

        /// <summary>
        /// (Cross-Game compatible) Check if object is the same type as T
        /// </summary>
        /// <typeparam name="T">Type to check</typeparam>
        public static bool IsType<T>(this Object instance) where T : Object
        {
            return instance?.TryCast<T>() != null;
        }

        /// <summary>
        /// (Cross-Game compatible) Check if object is the same type as T
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="castObject">The casted object if this is of type T</param>
        /// <typeparam name="T">Type to check</typeparam>
        public static bool IsType<T>(this Object instance, out T castObject) where T : Object
        {
            castObject = instance?.TryCast<T>();
            return castObject != null;
        }
        
        public static Object ToIl2Cpp(this float f)
        {
            return new Single { m_value = f }.BoxIl2CppObject();
        }
        
        public static Object ToIl2Cpp(this int i)
        {
            return new Int32 { m_value = i }.BoxIl2CppObject();
        }
        
        public static Object ToIl2Cpp(this bool b)
        {
            return new Boolean { m_value = b }.BoxIl2CppObject();
        }
    }
}
