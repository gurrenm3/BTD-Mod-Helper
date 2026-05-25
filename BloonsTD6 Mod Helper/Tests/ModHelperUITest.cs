using System.Collections;
using BTD_Mod_Helper.Api.Testing;
using BTD_Mod_Helper.UI.Menus;
using UnityEngine;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Tests;

internal class ModHelperUITest : ModTest
{
    public override IEnumerator Test()
    {
        yield return EnsureOnMainMenuWithNoPopUps();

        var modsButtonRect = AssertComponentExists<RectTransform>("Mods");

        modsButtonRect.GetComponentInChildren<Button>().onClick.Invoke();

        yield return new WaitForSecondsRealtime(1f);

        Assert(GetInstance<ModsMenu>().IsOpen);
    }
}