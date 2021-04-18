using System;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Extensions
{
    public static class InputFieldSubmitEvent
    {
        public delegate void Function(string value);

        public static void AddListener(this InputField.SubmitEvent submitEvent, Function funcToExecute)
        {
            submitEvent.AddListener(new Action<string>((str) => { funcToExecute(str); }));
        }
    }
}
