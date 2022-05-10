using System;

namespace BTD_Mod_Helper.Extensions
{
    public delegate void Function();
    public delegate T Function<T>();
    //public delegate void Function<T>(T t);


    public static class FunctionExt
    {
        public static Action ToAction(this Function func)
        {
            return new Action(() => func());
        }

        public static Action<T> ToAction<T>(this Function<T> func)
        {
            return new Action<T>((T t) => func());
        }
    }
}
