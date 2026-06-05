using BTD_Mod_Helper.Api.Internal;
using Il2CppTMPro;
using UnityEngine;

namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(TMP_InputField), nameof(TMP_InputField.KeyPressed))]
internal static class TMP_InputField_KeyPressed
{
    [HarmonyPrefix]
    private static bool Prefix(TMP_InputField __instance, Event evt, ref TMP_InputField.EditState __result)
    {
        if (__instance != ConsoleHandler.Console?.input?.InputField) return true;

        var mods = evt.modifiers;
        if ((mods & (EventModifiers.Control | EventModifiers.Alt)) == 0) return true;

        switch (evt.keyCode)
        {
            case KeyCode.Backspace:
                DeleteWord(__instance, forward: false);
                __result = TMP_InputField.EditState.Continue;
                return false;
            case KeyCode.Delete:
                DeleteWord(__instance, forward: true);
                __result = TMP_InputField.EditState.Continue;
                return false;
        }
        return true;
    }

    private static void DeleteWord(TMP_InputField field, bool forward)
    {
        var text = field.text ?? "";
        var caret = field.caretPosition;
        int from, to;

        if (forward)
        {
            if (caret >= text.Length) return;
            from = caret;
            to = caret;
            while (to < text.Length && char.IsWhiteSpace(text[to])) to++;
            while (to < text.Length && !char.IsWhiteSpace(text[to])) to++;
        }
        else
        {
            if (caret == 0) return;
            to = caret;
            from = caret - 1;
            while (from > 0 && char.IsWhiteSpace(text[from])) from--;
            while (from > 0 && !char.IsWhiteSpace(text[from - 1])) from--;
        }

        field.text = text.Remove(from, to - from);
        field.caretPosition = from;
    }
}