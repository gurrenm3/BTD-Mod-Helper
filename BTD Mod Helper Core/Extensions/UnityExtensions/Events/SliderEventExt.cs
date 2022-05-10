using System;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Extensions
{
    public static class SliderEventExt
    {
        public delegate void Function(float value);

        public static void AddListener(this Slider.SliderEvent clickEvent, Function funcToExecute)
        {
            clickEvent.AddListener(new Action<float>((f) => funcToExecute(f)));
        }
    }
}
