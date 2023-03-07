namespace BTD_Mod_Helper.Patches.Resources;
/*
/// <summary>
/// This makes the first GameModel loaded always be the one returned, even if another GameModel load tries to happen
/// </summary>
[HarmonyPatch(typeof(GameModelUtil._LoadGameModelAsync_d__9),
    nameof(GameModelUtil._LoadGameModelAsync_d__9.MoveNext))]
internal static class LoadGameModelAsync_MoveNext
{
    private static GameModel gameModel;
        
    [HarmonyPrefix]
    private static bool Prefix(GameModelUtil._LoadGameModelAsync_d__9 __instance)
    {
        if (gameModel != null)
        {
            __instance.__t__builder.SetResult(gameModel);
            return false;
        }

        return true;
    }
        
    [HarmonyPostfix]
    private static void Postfix(GameModelUtil._LoadGameModelAsync_d__9 __instance)
    {
        if (__instance.__1__state == -2)
        {
            gameModel ??= __instance.__t__builder.Task.Result;
        }
            
    }
}*/