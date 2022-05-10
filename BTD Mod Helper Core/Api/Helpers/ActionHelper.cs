using System;
using BTD_Mod_Helper.Extensions;

namespace BTD_Mod_Helper.Api.Helpers
{
    public static class ActionHelper
    {
        public static Action CreateFromOptionalFunction(Function funcToExecute)
        {
            return (funcToExecute is null) ? new Action(() => { }) : new Action(() => { funcToExecute(); });
        }

        public static Action<T> CreateFromOptionalFunction<T>(Function<T> funcToExecute)
        {
            return (funcToExecute is null) ? new Action<T>((T t) => { }) : new Action<T>((T t) => { funcToExecute(); });
        }
    }
}
