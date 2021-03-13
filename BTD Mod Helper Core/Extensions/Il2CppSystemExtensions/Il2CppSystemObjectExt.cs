using Object = Il2CppSystem.Object;

namespace BTD_Mod_Helper.Extensions
{
    public static class Il2CppSystemObjectExt
    {
        public static bool ReferenceEquals(this Object instance, Object to)
        {
            return ReferenceEquals(instance, (object)to);
        }

        /// <summary>
        /// Check if object is the same type as T
        /// </summary>
        /// <typeparam name="T">Type to check</typeparam>
        public static bool IsType<T>(this Object instance) where T : Object
        {
            return instance.TryCast<T>() != null;
        }

        /// <summary>
        /// Check if object is the same type as T
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="castObject">The casted object if this is of type T</param>
        /// <typeparam name="T">Type to check</typeparam>
        public static bool IsType<T>(this Object instance, out T castObject) where T : Object
        {
            castObject = instance.TryCast<T>();
            return castObject != null;
        }
    }
}
