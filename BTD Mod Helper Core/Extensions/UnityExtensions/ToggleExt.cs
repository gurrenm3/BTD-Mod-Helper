using System;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Extensions
{
    public static class ToggleExt
    {
        public static void AddOnValueChanged(this Toggle toggle, ToggleEventExt.Function funcToExecute)
        {
            toggle.onValueChanged.AddListener(funcToExecute);
        }
    }
}
