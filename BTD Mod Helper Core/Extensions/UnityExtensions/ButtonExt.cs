using UnityEngine.UI;
using static BTD_Mod_Helper.Extensions.ButtonClickedEventExt;

namespace BTD_Mod_Helper.Extensions
{
    public static class ButtonExt
    {
        public static void AddOnClick(this Button button, Function funcToExecute)
        {
            button.onClick.AddListener(funcToExecute);
        }

        public static void SetOnClick(this Button button, Function funcToExecute)
        {
            button.onClick.SetListener(funcToExecute);
        }

        public static void RemoveOnClickAction(this Button button, int actionIndex)
        {
            button.onClick.RemovePersistantCall(actionIndex);
        }
    }
}