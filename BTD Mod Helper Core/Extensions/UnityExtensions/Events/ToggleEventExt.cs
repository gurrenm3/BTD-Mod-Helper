using System;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Extensions
{
    public static class ToggleEventExt
    {
        public delegate void Function(bool value);

        public static void AddListener(this Toggle.ToggleEvent submitEvent, Function funcToExecute)
        {
            submitEvent.AddListener(new Action<bool>((b) => { funcToExecute(b); }));
        }
    }
}
