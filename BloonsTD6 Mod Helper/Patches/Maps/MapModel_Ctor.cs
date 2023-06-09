using Il2CppAssets.Scripts.Models.Map;
using Il2CppAssets.Scripts.Models.Map.Gizmos;
using Il2CppAssets.Scripts.Models.Map.Spawners;
using Il2CppAssets.Scripts.Models.Map.Triggers;
namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(MapModel), MethodType.Constructor, typeof(string), typeof(Il2CppReferenceArray<AreaModel>),
    typeof(Il2CppReferenceArray<BlockerModel>), typeof(Il2CppReferenceArray<CoopAreaLayoutModel>),
    typeof(Il2CppReferenceArray<PathModel>), typeof(Il2CppReferenceArray<RemoveableModel>),
    typeof(Il2CppReferenceArray<MapGizmoModel>), typeof(int), typeof(PathSpawnerModel),
    typeof(Il2CppReferenceArray<MapEventModel>), typeof(float))]
internal static class MapModel_Ctor
{
    /*[HarmonyPrefix]
    private static bool Prefix(ref MapModel __instance)
    {
        
        var result = true;
        var unref__instance = __instance;
        //ModHelper.PerformHook(mod => result &=  mod.PreMapModelCreated(ref unref__instance));
        //__instance = unref__instance;
        return result;
    }*/
    /*[HarmonyPostfix]
    private static void Postfix(MapModel __instance)
    {
        ModHelper.PerformHook(mod => mod.PostMapModelCreated(__instance));
    }*/
}