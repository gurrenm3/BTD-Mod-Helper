using System;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Extensions
{
    public static class InputFieldOnValueChanged
    {
        public delegate void Function(string value);

        public static void AddListener(this InputField.OnChangeEvent valueChangedEvent, Function funcToExecute)
        {
            valueChangedEvent.AddListener(new Action<string>((str) => { funcToExecute(str); }));
        }
    }
}