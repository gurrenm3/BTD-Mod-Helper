using System;
using Assets.Scripts.Utils;
using MelonLoader;
using UnhollowerBaseLib;
using UnhollowerBaseLib.Runtime;

namespace BTD_Mod_Helper.Extensions.CollectionExtensions
{
    public static class ArrayExt
    {
        /// <summary>
        /// Not Tested
        /// </summary>
        public static SizedList<T> ToSizedList<T>(this T[] array)
        {
            var sizedList = new SizedList<T>();
            foreach (var item in array)
                sizedList.Add(item);

            return sizedList;
        }

        /// <summary>
        /// Version of TryCast without the generic restriction
        /// </summary>
        private static bool TryCast<T>(Il2CppObjectBase obj, out T t)
        {
            t = default;
            var nativeClassPtr = Il2CppClassPointerStore<T>.NativeClassPtr;
            if (nativeClassPtr == IntPtr.Zero)
            {
                MelonLogger.Warning($"{typeof(T)} is not an Il2Cpp reference type");
                return false;
            }

            var num = IL2CPP.il2cpp_object_get_class(obj.Pointer);
            if (!IL2CPP.il2cpp_class_is_assignable_from(nativeClassPtr, num))
            {
                MelonLogger.Warning($"{obj.GetType()} is not a {typeof(T)}");
                return false;
            }

            if (RuntimeSpecificsStore.IsInjected(num))
            {
                t = (T) ClassInjectorBase.GetMonoObjectFromIl2CppPointer(obj.Pointer);
                return true;
            }

            var type = Il2CppClassPointerStore<T>.CreatedTypeRedirect;
            if ((object) type == null)
            {
                type = typeof(T);
            }

            t = (T) Activator.CreateInstance(type, obj.Pointer);
            return true;
        }

        private static bool CheckType<T>(object obj, out T t)
        {
            switch (obj)
            {
                case Il2CppObjectBase il2CppObject:
                    return TryCast(il2CppObject, out t);
                case T o:
                    t = o;
                    return true;
            }
            
            MelonLogger.Warning($"{obj.GetType()} is not a {typeof(T)}");
            t = default;
            return false;
        }

        public static bool CheckTypes<T1>(this object[] parameters, out T1 param1)
        {
            param1 = default;
            if (parameters.Length < 1)
            {
                MelonLogger.Warning("Did not have at least 1 param");
                return false;
            }
            return CheckType(parameters[0], out param1);
        }

        public static bool CheckTypes<T1, T2>(this object[] parameters, out T1 param1, out T2 param2)
        {
            param1 = default;
            param2 = default;
            if (parameters.Length < 2)
            {
                MelonLogger.Warning("Did not have at least 2 params");
                return false;
            }

            return CheckType(parameters[1], out param2) &&
                   CheckTypes(parameters, out param1);
        }

        public static bool CheckTypes<T1, T2, T3>(this object[] parameters, out T1 param1, out T2 param2, out T3 param3)
        {
            param1 = default;
            param2 = default;
            param3 = default;
            if (parameters.Length < 3)
            {
                MelonLogger.Warning("Did not have at least 3 params");
                return false;
            }

            return CheckType(parameters[2], out param3) &&
                   CheckTypes(parameters, out param1, out param2);
        }

        public static bool CheckTypes<T1, T2, T3, T4>(this object[] parameters, out T1 param1, out T2 param2,
            out T3 param3, out T4 param4)
        {
            param1 = default;
            param2 = default;
            param3 = default;
            param4 = default;
            if (parameters.Length < 4)
            {
                MelonLogger.Warning("Did not have at least 4 params");
                return false;
            }

            return CheckType(parameters[3], out param4) &&
                   CheckTypes(parameters, out param1, out param2, out param3);
        }

        public static bool CheckTypes<T1, T2, T3, T4, T5>(this object[] parameters, out T1 param1, out T2 param2,
            out T3 param3, out T4 param4, out T5 param5)
        {
            param1 = default;
            param2 = default;
            param3 = default;
            param4 = default;
            param5 = default;
            if (parameters.Length < 5)
            {
                MelonLogger.Warning("Did not have at least 5 params");
                return false;
            }

            return CheckType(parameters[4], out param5) &&
                   CheckTypes(parameters, out param1, out param2, out param3, out param4);
        }

        public static bool CheckTypes<T1, T2, T3, T4, T5, T6>(this object[] parameters, out T1 param1, out T2 param2,
            out T3 param3, out T4 param4, out T5 param5, out T6 param6)
        {
            param1 = default;
            param2 = default;
            param3 = default;
            param4 = default;
            param5 = default;
            param6 = default;
            if (parameters.Length < 6)
            {
                MelonLogger.Warning("Did not have at least 6 params");
                return false;
            }

            return CheckType(parameters[5], out param6) &&
                   CheckTypes(parameters, out param1, out param2, out param3, out param4, out param5);
        }
    }
}